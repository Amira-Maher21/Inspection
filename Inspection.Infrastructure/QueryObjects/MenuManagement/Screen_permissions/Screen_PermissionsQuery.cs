using Inspection.Application.Contracts.Dto.MenuManagement.Screen_permissions;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.QueryObjects.MenuManagement.Screen_permissions
{
    internal class Screen_PermissionsQuery
        : QueryObjectBase<Screen_permissionReturnSearchDto>
    {
        public Screen_PermissionsQuery(
            ISqlQueryBuilder queryBuilder,
            DapperDbContext dapper,
            ITenantResolver tenantResolver,
            IExceptionManager exceptionManager,
            string? fiscalYear = null)
            : base(queryBuilder, dapper, tenantResolver, exceptionManager, fiscalYear)
        {
        }

        public override async Task<ReturnBase<IEnumerable<Screen_permissionReturnSearchDto>>> Query(
            SqlQueryOptions queryOptions)
        {
            try
            {
                // ================= MASTER + JOIN =================
                string tableName = "Sec.Screen_permission";

                var selectFields = new[]
                {
                    "Tenant_ID",
                    "User_group_ID",
                    "Screen_ID",
                    "CanAdd",
                    "CanUpdate",
                    "CanDelete",
                    "CanPrice",
                    "CanPost",
                    "CanPrint",
                    "CanAttachment"
                };

                var userGroupJoin = new JoinTable(
                    "Sec.User_Group",
                    "User_group_Name",
                    "User_group_ID User_group_ID"
                );

                var queryData = await _queryBuilder.GetQueryStringDataAsync(
                    tableName,
                    string.Join(", ", selectFields),
                    new List<JoinTable> { userGroupJoin },
                    queryOptions);

                var result = await _dapper.QueryList<Screen_permissionReturnSearchDto>(
                    queryData.QueryString!,
                    queryData.Parameters!.ToDictionary());

                if (!result.Succeeded)
                    return ReturnBase<IEnumerable<Screen_permissionReturnSearchDto>>
                        .Fail(result.Errors);

                return ReturnBase<IEnumerable<Screen_permissionReturnSearchDto>>
                    .Success(result.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<Screen_permissionReturnSearchDto>>
                    .Fail(ex, _exceptionManager);
            }
        }

        public override Task<ReturnBase<IEnumerable<Screen_permissionReturnSearchDto>>> Query(
            SqlQueryOptions queryOptions,
            string functionParameter)
        {
            throw new NotImplementedException();
        }

        public override Task<ReturnBase<IEnumerable<Screen_permissionReturnSearchDto>>> Query(
            SqlQueryOptions queryOptions,
            object[] functionParameters)
        {
            throw new NotImplementedException();
        }
    }
}
