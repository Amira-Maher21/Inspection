using Inspection.Application.Contracts.Dto.SalesManagment.Setup.SalesPerson;
using Inspection.Application.Contracts.Repositories.Query.SalesManagment.Setup.SalesPersons;
using Inspection.Domain.Models.SalesManagment.Setup.SalesPersons;
using Inspection.Infrastructure.QueryObjects.SalesManagment.Setup;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.Repositories.Query.SalesManagment.Setup
{
    internal class SalesPersonQueryRepository
        : QueryRepositoryBase<SalesPerson>, ISalesPersonQueryRepository
    {
        public SalesPersonQueryRepository(
            ISqlQueryBuilder queryBuilder,
            DapperDbContext dapper,
            DbContext context,
            ITenantResolver tenantResolver,
            IExceptionManager exceptionManager)
            : base(queryBuilder, dapper, context, tenantResolver, exceptionManager)
        {
        }

        public async Task<SalesPerson?> GetById(long id)
        {
            return await _dbSet.FirstOrDefaultAsync(x =>
                x.Id == id &&
                x.Tenant_ID == _tenantResolver.GetTenantName());
        }


        public async Task<ReturnBase<IEnumerable<SalesPersonSearchDto>>> Search(
            SqlQueryOptions sqlQueryOptions)
        {
            var salesPersonQuery =
                new SalesPersonQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);

            return await salesPersonQuery.Query(sqlQueryOptions);
        }


        public async Task<SalesPerson?> GetByCode(string code)
        {
            return await _context.Set<SalesPerson>().Where(x => x.Code == code).FirstOrDefaultAsync();
        }
    }
}
