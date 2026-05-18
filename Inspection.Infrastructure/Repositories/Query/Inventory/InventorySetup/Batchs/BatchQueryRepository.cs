using Inspection.Application.Contracts.Dto.Inventory.InventorySetup.Batchs;
using Inspection.Application.Contracts.Repositories.Query.Inventory.InventorySetup.Batchs;
using Inspection.Domain.Models.Inventory.InventorySetup.Batchs;
using Inspection.Infrastructure.QueryObjects.Inventory.InventorySetup.Batchs;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.Repositories.Query.Inventory.InventorySetup.Batchs
{

    public class BatchQueryRepository : QueryRepositoryBase<Batch>, IBatchQueryRepository
    {
        public BatchQueryRepository(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(queryBuilder, dapper, context, tenantResolver, exceptionManager)
        {

        }



        public async Task<Batch?> GetById(long id)
        {
            return await _dbSet
                 .FirstOrDefaultAsync(c => c.Id == id);
        }




        public async Task<IEnumerable<Batch>> GetList(SqlQueryOptions sqlQueryOptions = null)
        {
            return await _dbSet
                         .ToListAsync();
        }



        public async Task<ReturnBase<IEnumerable<BatchReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions)
        {
            try
            {
                var TaxQueryRepository = new BatchQuery(
                    _queryBuilder,
                    _dapper,
                    _tenantResolver,
                    _exceptionManager
                );

                var queryResult = await TaxQueryRepository.Query(sqlQueryOptions);

                if (!queryResult.Succeeded)
                    return ReturnBase<IEnumerable<BatchReturnSearchDto>>.Fail(queryResult.Errors);

                return ReturnBase<IEnumerable<BatchReturnSearchDto>>.Success(queryResult.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<BatchReturnSearchDto>>.Fail(ex, _exceptionManager);
            }
        }





    }

}
