using Inspection.Application.Contracts.Dto.SalesManagment.sales.Transactions.SalesQuotationDTOs;
using Inspection.Application.Contracts.Repositories.Query.SalesManagment.Transactions.SalesQuotations;
using Inspection.Domain.Models.SalesManagment.Transaction.SalesQuotations;
using Inspection.Infrastructure.QueryObjects.SalesManagment.Transactions.SalesQuotations;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.Repositories.Query.SalesManagment.Transactions.SalesQuotations
{
    public class SalesQuotationQueryRepository : QueryRepositoryBase<SalesQuotation>, ISalesQuotationQueryRepository
    {
        public SalesQuotationQueryRepository(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(queryBuilder, dapper, context, tenantResolver, exceptionManager)
        {
        }

        public async Task<ReturnBase<List<SalesQuotation>>> GetAll()
        {
            var result = await _context.Set<SalesQuotation>()
                .Include(x => x.SalesQuotationLines)

                .AsNoTracking().ToListAsync();
            return ReturnBase<List<SalesQuotation>>.Success(result);
        }

        public async Task<SalesQuotation?> GetById(long id)
        {
            return await _context.Set<SalesQuotation>()
                .Include(x => x.SalesQuotationLines)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ReturnBase<IEnumerable<SalesQuotationReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions)
        {
            var salesQuotationRepository = new SalesQuotationQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);
            return await salesQuotationRepository.Query(sqlQueryOptions);
        }
        public async Task<SalesQuotation?> GetByInspectionRequestId(long inspectionRequestId)
        {
            return await _context.Set<SalesQuotation>()
                .Include(s => s.SalesQuotationLines)
                .FirstOrDefaultAsync(x => x.InspectionRequestId == inspectionRequestId);
        }
    }
}