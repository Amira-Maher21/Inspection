using Inspection.Application.Contracts.Dto.InspectionManagement.CustomerProjects;
using Inspection.Application.Contracts.Repositories.Query.InspectionManagement.CustomerProjects;
using Inspection.Domain.Models.InspectionManagement.CustomerProjects;
using Inspection.Infrastructure.QueryObjects.InspectionManagement.CustomerProject;

using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.Repositories.Query.InspectionManagement.CustomerProjects
{
    public class CustomerProjectQueryRepository : QueryRepositoryBase<CustomerProject>, ICustomerProjectQueryRepository
    {
        public CustomerProjectQueryRepository(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(queryBuilder, dapper, context, tenantResolver, exceptionManager)
        {
        }

        public async Task<CustomerProject?> GetByIdAsync(long id)
        {
            return await _context.Set<CustomerProject>().Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<ReturnBase<IEnumerable<CustomerProjectDtoByInclude>>> GetListAsync(SqlQueryOptions sqlQueryOptions)
        {
            var CustomerProjectQueryRepository = new CustomerProjectQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);
            return await CustomerProjectQueryRepository.Query(sqlQueryOptions);//Query(CustomerProjectDto, sqlQueryOptions);
        }
        public async Task<ReturnBase<IEnumerable<CustomerProjectDtoByInclude>>> GetListIncldeNameAsync(SqlQueryOptions sqlQueryOptions)
        {

            var CustomerProjectQuery = new CustomerProjectQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);
            return await Query(CustomerProjectQuery, sqlQueryOptions);

        }
        public async Task<ReturnBase<IEnumerable<CustomerProjectDtoByInclude>>> GetLookUpCustomerProjectForNamesAsync(SqlQueryOptions queryOptions)
        {
            var CustomerProjectQueryRepository = new CustomerProjectQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);

            return await CustomerProjectQueryRepository.Query(queryOptions);


        }
        //public async Task<ReturnBase<IEnumerable<CustomerProjectDto>>> GetListAsync(SqlQueryOptions sqlQueryOptions)
        //{
        //    //var CustomerProjectQueryRepository = new CustomerProjectQueryRepository(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);
        //    //return await Query(CustomerProjectQueryRepository, sqlQueryOptions);
        //}
    }

}
