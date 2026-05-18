using Inspection.Application.Contracts.Repositories.Query.Accounting.AR.MasterData;
using Inspection.Domain.Models.Accounting.AR.MasterData;
using Inspection.Infrastructure.QueryObjects.Accounting.AR.MasterData;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.Repositories.Query.Accounting.AR.MasterData
{
    public class CustomerQueryRepository : QueryRepositoryBase<Customer>, ICustomerQueryRepository
    {

        public CustomerQueryRepository(ISqlQueryBuilder sqlQueryBuilder, DapperDbContext dapperDbContext, DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(sqlQueryBuilder, dapperDbContext, context, tenantResolver, exceptionManager)
        {
        }


        public async Task<Customer?> GetById(long id)
        {
            return await _dbSet
                .Include(c => c.CustomerContact)
                .Include(c => c.CustomerLocation)
                .Include(c => c.CustomerProject)
                .FirstOrDefaultAsync(c => c.Id == id);
        }


        public async Task<Customer?> GetByCode(string code)
        {
            return await _context.Set<Customer>()
                .FirstOrDefaultAsync(x => x.Code == code);
        }



        public async Task<ReturnBase<IEnumerable<CustomerReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions)
        {
            try
            {
                var customerQuery = new CustomerQuery(
                    _queryBuilder,
                    _dapper,
                    _tenantResolver,
                    _exceptionManager
                );

                var queryResult = await customerQuery.Query(sqlQueryOptions);

                if (!queryResult.Succeeded)
                    return ReturnBase<IEnumerable<CustomerReturnSearchDto>>.Fail(queryResult.Errors);

                return ReturnBase<IEnumerable<CustomerReturnSearchDto>>.Success(queryResult.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<CustomerReturnSearchDto>>.Fail(ex, _exceptionManager);
            }
        }



    }

}

