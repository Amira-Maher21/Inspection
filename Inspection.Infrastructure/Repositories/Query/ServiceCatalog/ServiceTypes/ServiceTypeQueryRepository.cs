  using Inspection.Application.Contracts.Dto.ServiceCatalog.ServiceTypes;
 using Inspection.Application.Contracts.Repositories.Query.ServiceCatalog.ServiceTypes;
 using Inspection.Domain.Models.ServiceCatalog.ServiceTypes;
 using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.Repositories.Query.InspectionManagement.ServiceTypes
{
    public class ServiceTypeQueryRepository : QueryRepositoryBase<ServiceType>, IServiceTypeQueryRepository
    {
        public ServiceTypeQueryRepository(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(queryBuilder, dapper, context, tenantResolver, exceptionManager)
        {
        }



        public async Task<ServiceType?> GetByIdAsync(long id)
        {
            return await _context.Set<ServiceType>().Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<ReturnBase<IEnumerable<ServiceTypeDtoByInclude>>> GetListAsync(SqlQueryOptions sqlQueryOptions)
        {
            var ServiceTypeQueryRepository = new ServiceTypeQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);
            return await ServiceTypeQueryRepository.Query(sqlQueryOptions);//Query(ServiceTypeDto, sqlQueryOptions);
        }

        public async Task<ReturnBase<IEnumerable<ServiceTypeDtoByInclude>>> GetListIncludeNameAsync(SqlQueryOptions sqlQueryOptions)
        {

            var ServiceTypeQuery = new ServiceTypeQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);
            return await Query(ServiceTypeQuery, sqlQueryOptions);

        }

        public async Task<ReturnBase<IEnumerable<ServiceTypeDtoByInclude>>> GetLookUpServiceTypeForNamesAsync(SqlQueryOptions queryOptions)
        {
            var ServiceTypeQueryRepository = new ServiceTypeQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);

            return await ServiceTypeQueryRepository.Query(queryOptions);


        }

        //public async Task<ReturnBase<IEnumerable<ServiceTypeDto>>> GetListAsync(SqlQueryOptions sqlQueryOptions)
        //{
        //    //var ServiceTypeQueryRepository = new ServiceTypeQueryRepository(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);
        //    //return await Query(ServiceTypeQueryRepository, sqlQueryOptions);
        //}
    }

}
