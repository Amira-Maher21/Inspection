using Inspection.Application.Contracts.Dto.MenuManagement.User_Groups;
using Inspection.Application.Contracts.Repositories.Query.MenuManagement.User_Groups;
using Inspection.Domain.Models.MenuManagement;
using Inspection.Infrastructure.QueryObjects.MenuManagement.User_Groups;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.Repositories.Query.MenuManagement.User_Groups
{
    public class User_GroupQueryRepository
        : QueryRepositoryBase<User_Group>, IUser_GroupQueryRepository
    {
        public User_GroupQueryRepository(
            ISqlQueryBuilder sqlQueryBuilder,
            DapperDbContext dapperDbContext,
            DbContext context,
            ITenantResolver tenantResolver,
            IExceptionManager exceptionManager)
            : base(sqlQueryBuilder, dapperDbContext, context, tenantResolver, exceptionManager)
        {
        }








        #region Get By Id

        public async Task<User_Group?> GetById(long id)
        {
            return await _dbSet
                .Include(x => x.Screen_permissions)
                .Include(x => x.User_Code_dGroups)
                 .FirstOrDefaultAsync(x => x.User_group_ID == id);
        }


        #endregion

        #region Get List

        public async Task<IEnumerable<User_Group>> GetList(SqlQueryOptions sqlQueryOptions = null)
        {
            return await _dbSet
                .Include(x => x.Screen_permissions)
                .Include(x => x.User_Code_dGroups)
                .ToListAsync();
        }

        #endregion

        #region Search

        public async Task<ReturnBase<IEnumerable<User_GroupReturnSearchDto>>> Search(
            SqlQueryOptions sqlQueryOptions)
        {
            try
            {
                var User_GroupsQuery = new User_GroupsQuery(
                    _queryBuilder,
                    _dapper,
                    _tenantResolver,
                    _exceptionManager
                );

                var queryResult = await User_GroupsQuery.Query(sqlQueryOptions);

                if (!queryResult.Succeeded)
                    return ReturnBase<IEnumerable<User_GroupReturnSearchDto>>
                        .Fail(queryResult.Errors);

                return ReturnBase<IEnumerable<User_GroupReturnSearchDto>>
                    .Success(queryResult.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<User_GroupReturnSearchDto>>
                    .Fail(ex, _exceptionManager);
            }
        }



        #endregion
    }
}


