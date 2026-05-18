using Inspection.Application.Contracts.Dto.InspectionManagement.InspectionRequests;
using Inspection.Application.Contracts.Repositories.Query.InspectionManagement.InspectionRequests;
using Inspection.Domain.Models.InspectionManagement.InspectionRequests;
using Inspection.Infrastructure.QueryObjects.InspectionManagement.InspectionRequest;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.Repositories.Query.InspectionManagement.InspectionRequests
{
    public class InspectionRequestQueryRepository : QueryRepositoryBase<InspectionRequest>, IInspectionRequestQueryRepository
    {
        public InspectionRequestQueryRepository(ISqlQueryBuilder sqlQueryBuilder, DapperDbContext dapperDbContext, DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(sqlQueryBuilder, dapperDbContext, context, tenantResolver, exceptionManager)
        {
        }

        public async Task<InspectionRequest?> GetByIdAsync(long id)
        {
            return await _context.Set<InspectionRequest>().Include(x => x.InspectionRequestLines).FirstOrDefaultAsync(x => x.Id == id);
        }



        public async Task<List<InspectionRequestDtoLookUpForRequestDetails>> GetRequestDetailsAsync(long id)
        {
            var data = await _context.Set<InspectionRequest>()
                .Where(x => x.Id == id)
                .Select(x => new
                {
                    x.Id,
                    //FullRequestNumber = x.series + x.RequestNumber,
                    RequestNumber = x.RequestNumber,

                    Details = x.InspectionRequestLines
                        .Select(d => new InspectionRequestUnifiedDetailDto
                        {
                            Id = d.Id,
                            ItemId = d.ItemId,
                            Quantity = d.Quantity,
                            InspectionMethodId = d.InspectionMethodId,
                            InspectionRequestId = d.InspectionRequestId,
                            IsSubcontractor = false,
                        })
                        .ToList(),

                })
                .ToListAsync();

            return data.Select(x => new InspectionRequestDtoLookUpForRequestDetails
            {
                Id = x.Id,
                RequestNumber = x.RequestNumber,
                Details = x.Details
                    .ToList()
            }).ToList();
        }

        public async Task<ReturnBase<IEnumerable<InspectionRequestDtoByInclude>>> GetListAsync(SqlQueryOptions sqlQueryOptions)
        {
            var InspectionRequestQuery = new InspectionRequestQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);
            return await Query(InspectionRequestQuery, sqlQueryOptions);
        }


        public async Task<ReturnBase<IEnumerable<InspectionRequestDtoByInclude>>> GetListIncldeNameAsync(SqlQueryOptions sqlQueryOptions)
        {

            var InspectionRequestQuery = new InspectionRequestQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);
            return await Query(InspectionRequestQuery, sqlQueryOptions);

        }
        public async Task<ReturnBase<IEnumerable<InspectionRequestDtoByInclude>>> GetLookUpInspectionRequestForNamesAsync(SqlQueryOptions sqlQueryOptions)
        {

            var InspectionRequestQuery = new InspectionRequestQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);
            return await Query(InspectionRequestQuery, sqlQueryOptions);

        }

        public async Task<ReturnBase<List<InspectionRequestLookupDto>>> GetRequestNumbersForDropdownAsync()
        {
            try
            {
                var result = await _dbSet
                    .Include(r => r.Customers)
                    .Select(r => new InspectionRequestLookupDto
                    {
                        Id = r.Id,
                        //RequestNumber = r.series + r.RequestNumber,
                        RequestNumber = r.RequestNumber,
                        //DisplayText = r.series + r.RequestNumber,
                        DisplayText = r.RequestNumber,
                        CustomerId = r.CustomerId,
                        CustomerName = r.Customers.Name
                    })
                    .ToListAsync();

                return ReturnBase<List<InspectionRequestLookupDto>>.Success(result);
            }
            catch (Exception ex)
            {
                return ReturnBase<List<InspectionRequestLookupDto>>.Fail(ex, _exceptionManager);
            }
        }


    }

}
