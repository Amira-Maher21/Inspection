
using Inspection.Application.Contracts.Dto.MenuManagement.User_Codes;
using Inspection.Application.Contracts.Repositories.Query.MenuManagement.User_Codes;
using Inspection.Domain.Models.MenuManagement;
using Inspection.Infrastructure.QueryObjects.MenuManagement.User_Codes;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.Repositories.Query.MenuManagement.User_Codes
{
    public class User_CodeQueryRepository
        : QueryRepositoryBase<User_Code>, IUser_CodeQueryRepository
    {
        public User_CodeQueryRepository(
            ISqlQueryBuilder sqlQueryBuilder,
            DapperDbContext dapperDbContext,
            DbContext context,
            ITenantResolver tenantResolver,
            IExceptionManager exceptionManager)
            : base(sqlQueryBuilder, dapperDbContext, context, tenantResolver, exceptionManager)
        {
        }

        #region Get By Id

        public async Task<User_Code?> GetById(long id)
        {
            return await _dbSet
                 .Include(x => x.User_Code_dGroups)
                 .FirstOrDefaultAsync(x => x.Id == id);
        }


        public async Task<User_Code?> GetByCode(string code)
        {
            return await _context.Set<User_Code>().Where(x => x.User_ID == code).FirstOrDefaultAsync();
        }
        #endregion

        #region Search

        public async Task<ReturnBase<IEnumerable<User_CodeReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions)
        {
            try
            {
                var User_CodeQuery = new User_CodeQuery(
                    _queryBuilder,
                    _dapper,
                    _tenantResolver,
                    _exceptionManager
                );

                var queryResult = await User_CodeQuery.Query(sqlQueryOptions);

                if (!queryResult.Succeeded)
                    return ReturnBase<IEnumerable<User_CodeReturnSearchDto>>
                        .Fail(queryResult.Errors);

                return ReturnBase<IEnumerable<User_CodeReturnSearchDto>>
                    .Success(queryResult.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<User_CodeReturnSearchDto>>
                    .Fail(ex, _exceptionManager);
            }
        }

        #endregion
    }
}