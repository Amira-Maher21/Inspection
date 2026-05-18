using Inspection.Application.Contracts.Dto.MenuManagement.Screen_permissions;
using Inspection.Application.Contracts.Dto.MenuManagement.User_Code_dGroups;
using Inspection.Application.Contracts.Dto.MenuManagement.User_Groups;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.QueryObjects.MenuManagement.User_Groups
{
    internal class User_GroupsQuery : QueryObjectBase<User_GroupReturnSearchDto>
    {
        public User_GroupsQuery(
            ISqlQueryBuilder queryBuilder,
            DapperDbContext dapper,
            ITenantResolver tenantResolver,
            IExceptionManager exceptionManager,
            string? fiscalYear = null)
            : base(queryBuilder, dapper, tenantResolver, exceptionManager, fiscalYear)
        {
        }

        public override async Task<ReturnBase<IEnumerable<User_GroupReturnSearchDto>>> Query(SqlQueryOptions queryOptions)
        {
            try
            {
                // ================= MASTER =================
                string tableName = "Sec.User_Group";

                var selectFields = new[]
                {
                    "Tenant_ID",
                    "User_group_ID",
                    "User_group_Name"
                };

                var tenantJoin = new JoinTable(
                    "Syst.Tenant_Code",
                    "Tenant_Name, LocaleCode",
                    "Tenant_ID Tenant_ID"
                );

                var masterQueryData = await _queryBuilder.GetQueryStringDataAsync(
                    tableName,
                    string.Join(", ", selectFields),
                    new List<JoinTable> { tenantJoin },
                    queryOptions);

                var masterResult = await _dapper.QueryList<User_GroupReturnSearchDto>(
                    masterQueryData.QueryString!,
                    masterQueryData.Parameters!.ToDictionary());

                if (!masterResult.Succeeded)
                    return ReturnBase<IEnumerable<User_GroupReturnSearchDto>>.Fail(masterResult.Errors);

                var masters = masterResult.Result.ToList();

                if (!masters.Any())
                    return ReturnBase<IEnumerable<User_GroupReturnSearchDto>>.Success(masters);

                // ================= DETAILS: Screen_permissions =================
                string screenSql = @"
                    SELECT
                        Tenant_ID,
                        User_group_ID,
                        Screen_ID,
                        CanAdd,
                        CanUpdate,
                        CanDelete,
                        CanPrice,
                        CanPost,
                        CanPrint,
                        CanAttachment
                    FROM Sec.Screen_permission
                    WHERE User_group_ID IN @GroupIds
                ";

                var screenParams = new Dictionary<string, object>
                {
                    { "GroupIds", masters.Select(x => x.User_group_ID).ToArray() }
                };

                var screenResult = await _dapper.QueryList<CreateScreen_permissionDto>(screenSql, screenParams);

                if (!screenResult.Succeeded)
                    return ReturnBase<IEnumerable<User_GroupReturnSearchDto>>.Fail(screenResult.Errors);

                var screenLookup = screenResult.Result
                    .GroupBy(d => d.User_group_ID)
                    .ToDictionary(g => g.Key, g => g.ToList());

                foreach (var master in masters)
                {
                    if (screenLookup.TryGetValue(master.User_group_ID, out var screens))
                        master.Screen_permissions = screens;
                }

                // ================= DETAILS: User_Code_dGroups =================
                string detailsSql = @"
                    SELECT
                        Id,
                        Tenant_ID,
                        User_group_ID,
                        User_CodeId
                    FROM Sec.User_Code_dGroup
                    WHERE User_group_ID IN @GroupIds
                ";

                var detailsParams = new Dictionary<string, object>
                {
                    { "GroupIds", masters.Select(x => x.User_group_ID).ToArray() }
                };

                var detailsResult = await _dapper.QueryList<CreateUser_Code_dGroupDto>(detailsSql, detailsParams);

                if (!detailsResult.Succeeded)
                    return ReturnBase<IEnumerable<User_GroupReturnSearchDto>>.Fail(detailsResult.Errors);

                var detailsLookup = detailsResult.Result
                    .GroupBy(d => d.User_group_ID)
                    .ToDictionary(g => g.Key, g => g.ToList());

                foreach (var master in masters)
                {
                    if (detailsLookup.TryGetValue(master.User_group_ID, out var details))
                        master.User_Code_dGroups = details;
                }

                return ReturnBase<IEnumerable<User_GroupReturnSearchDto>>.Success(masters);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<User_GroupReturnSearchDto>>.Fail(ex, _exceptionManager);
            }
        }

        public override Task<ReturnBase<IEnumerable<User_GroupReturnSearchDto>>> Query(SqlQueryOptions queryOptions, string functionParameter)
        {
            throw new NotImplementedException();
        }

        public override Task<ReturnBase<IEnumerable<User_GroupReturnSearchDto>>> Query(SqlQueryOptions queryOptions, object[] functionParameters)
        {
            throw new NotImplementedException();
        }
    }
}
