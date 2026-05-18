using Inspection.Application.Contracts.Dto.InspectionManagement.CustomerLocations;
using Inspection.Application.Contracts.Repositories.Query.InspectionManagement.CustomerLocations;
using Inspection.Domain.Models.InspectionManagement.CustomerLocations;
using Inspection.Infrastructure.QueryObjects.InspectionManagement.CustomerLocation;

using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.Repositories.Query.InspectionManagement.CustomerLocations
{
    public class CustomerLocationQueryRepository : QueryRepositoryBase<CustomerLocation>, ICustomerLocationQueryRepository
    {
        public CustomerLocationQueryRepository(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(queryBuilder, dapper, context, tenantResolver, exceptionManager)
        {
        }

        public async Task<CustomerLocation?> GetByIdAsync(long id)
        {
            return await _context.Set<CustomerLocation>().Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<ReturnBase<IEnumerable<CustomerLocationDtoByInclude>>> GetListAsync(SqlQueryOptions sqlQueryOptions)
        {
            var CustomerLocationQueryRepository = new CustomerLocationQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);
            return await CustomerLocationQueryRepository.Query(sqlQueryOptions);
        }
        public async Task<ReturnBase<IEnumerable<CustomerLocationDtoByInclude>>> GetLookUpCustomerLocationForNamesAsync(SqlQueryOptions queryOptions)
        {
            var CustomerLocationQueryRepository = new CustomerLocationQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);

            return await CustomerLocationQueryRepository.Query(queryOptions);


        }
        public async Task<ReturnBase<IEnumerable<CustomerLocationDtoByInclude>>> GetListIncludeNameAsync(SqlQueryOptions sqlQueryOptions)
        {

            var CustomerLocationQuery = new CustomerLocationQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);
            return await Query(CustomerLocationQuery, sqlQueryOptions);

        }

        //public async Task<ReturnBase<IEnumerable<CustomerLocationDto>>> GetListAsync(SqlQueryOptions sqlQueryOptions)
        //{
        //    //var CustomerLocationQueryRepository = new CustomerLocationQueryRepository(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);
        //    //return await Query(CustomerLocationQueryRepository, sqlQueryOptions);
        //}
    }

}
