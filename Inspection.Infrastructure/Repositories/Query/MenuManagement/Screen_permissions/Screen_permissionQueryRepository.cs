using Inspection.Application.Contracts.Dto.MenuManagement.Screen_permissions;
using Inspection.Application.Contracts.Repositories.Query.MenuManagement.Screen_permissions;
using Inspection.Domain.Models.MenuManagement;
using Inspection.Infrastructure.QueryObjects.MenuManagement.Screen_permissions;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.Repositories.Query.MenuManagement.Screen_permissions
{

    public class Screen_permissionQueryRepository : QueryRepositoryBase<Screen_permission>, IScreen_permissionQueryRepository
    {
        public Screen_permissionQueryRepository(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(queryBuilder, dapper, context, tenantResolver, exceptionManager)
        {
        }

        public async Task<Screen_permission?> GetByIdAsync(string id)//, string Screen_ID
        {
            return await _context.Set<Screen_permission>().Where(x => x.Screen_ID == id).FirstOrDefaultAsync();//&& x.Screen_ID == Screen_ID
        }

        public async Task<ReturnBase<IEnumerable<Screen_permissionDtoByInclude>>> GetListAsync(SqlQueryOptions sqlQueryOptions)
        {
            var Screen_permissionQueryRepository = new Screen_PermissionQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);
            return await Screen_permissionQueryRepository.Query(sqlQueryOptions);//Query(Screen_permissionDto, sqlQueryOptions);
        }




        public async Task<ReturnBase<IEnumerable<Screen_permissionReturnSearchDto>>> GetListIncldeNameAsync(SqlQueryOptions sqlQueryOptions)
        {

            var Screen_permissionQuery = new Screen_PermissionsQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);
            return await Query(Screen_permissionQuery, sqlQueryOptions);

        }




        public async Task<ReturnBase<IEnumerable<Screen_permissionDtoByInclude>>> GetLookUpScreen_permissionForNamesAsync(SqlQueryOptions queryOptions)
        {
            var Screen_permissionQueryRepository = new Screen_PermissionQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);

            return await Screen_permissionQueryRepository.Query(queryOptions);


        }
        //public async Task<ReturnBase<IEnumerable<Screen_permissionDto>>> GetListAsync(SqlQueryOptions sqlQueryOptions)
        //{
        //    //var Screen_permissionQueryRepository = new Screen_permissionQueryRepository(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);
        //    //return await Query(Screen_permissionQueryRepository, sqlQueryOptions);
        //}
    }

}

