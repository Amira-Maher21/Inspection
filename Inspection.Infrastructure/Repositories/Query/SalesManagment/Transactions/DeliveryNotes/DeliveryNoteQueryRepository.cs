using Inspection.Application.Contracts.Dto.SalesManagment.sales.Transactions.DeliveryNotes;
using Inspection.Application.Contracts.Repositories.Query.SalesManagment.Transactions.DeliveryNotes;
using Inspection.Domain.Models.SalesManagment.Transaction.DeliveryNotes;
using Inspection.Infrastructure.QueryObjects.SalesManagment.Sales.DeliveryNotes;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.Repositories.Query.SalesManagment.Transactions.DeliveryNotes
{

    public class DeliveryNoteQueryRepository : QueryRepositoryBase<DeliveryNote>, IDeliveryNoteQueryRepository
    {

        public DeliveryNoteQueryRepository(ISqlQueryBuilder sqlQueryBuilder, DapperDbContext dapperDbContext, DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(sqlQueryBuilder, dapperDbContext, context, tenantResolver, exceptionManager)
        {
        }

        public async Task<DeliveryNote?> GetByCode(string code)
        {
            return await _context.Set<DeliveryNote>()
                .FirstOrDefaultAsync(x => x.DeliveryNoteNo == code);
        }



        public async Task<DeliveryNote?> GetById(long id)
        {
            return await _dbSet
                .Include(c => c.DeliveryNoteLines)

                .FirstOrDefaultAsync(c => c.Id == id);
        }





        public async Task<ReturnBase<IEnumerable<DeliveryNoteReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions)

        {
            try
            {
                var customerQuery = new DeliveryNoteQuery(
                    _queryBuilder,
                    _dapper,
                    _tenantResolver,
                    _exceptionManager
                );

                var queryResult = await customerQuery.Query(sqlQueryOptions);

                if (!queryResult.Succeeded)
                    return ReturnBase<IEnumerable<DeliveryNoteReturnSearchDto>>.Fail(queryResult.Errors);

                return ReturnBase<IEnumerable<DeliveryNoteReturnSearchDto>>.Success(queryResult.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<DeliveryNoteReturnSearchDto>>.Fail(ex, _exceptionManager);
            }
        }


    }
}
