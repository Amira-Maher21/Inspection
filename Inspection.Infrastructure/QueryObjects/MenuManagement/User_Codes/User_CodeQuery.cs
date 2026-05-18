using Inspection.Application.Contracts.Dto.MenuManagement.User_Code_dGroups;
using Inspection.Application.Contracts.Dto.MenuManagement.User_Codes;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.QueryObjects.MenuManagement.User_Codes
{
    internal class User_CodeQuery : QueryObjectBase<User_CodeReturnSearchDto>
    {
        public User_CodeQuery(
            ISqlQueryBuilder queryBuilder,
            DapperDbContext dapper,
            ITenantResolver tenantResolver,
            IExceptionManager exceptionManager,
            string? fiscalYear = null)
            : base(queryBuilder, dapper, tenantResolver, exceptionManager, fiscalYear)
        {
        }

        public override async Task<ReturnBase<IEnumerable<User_CodeReturnSearchDto>>> Query(
            SqlQueryOptions queryOptions)
        {
            try
            {
                // ================= MASTER + JOIN =================
                string tableName = "Sec.User_Code";

                var selectFields = new[]
                {
                    "Id",
                    "User_ID",
                    "User_Name",
                    "Email",
                    "System_Owner",
                    "System_Administrator",
                    "Tenant_ID"
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

                var masterResult = await _dapper.QueryList<User_CodeReturnSearchDto>(
                    masterQueryData.QueryString!,
                    masterQueryData.Parameters!.ToDictionary());

                if (!masterResult.Succeeded)
                    return ReturnBase<IEnumerable<User_CodeReturnSearchDto>>.Fail(masterResult.Errors);

                var masters = masterResult.Result.ToList();

                if (!masters.Any())
                    return ReturnBase<IEnumerable<User_CodeReturnSearchDto>>.Success(masters);

                // ================= DETAILS =================
                string detailsSql = @"
                    SELECT
                        User_CodeId,
                        User_group_ID
                    FROM Sec.User_Code_dGroup
                    WHERE User_CodeId IN @MasterIds
                ";

                var parameters = new Dictionary<string, object>
                {
                    { "MasterIds", masters.Select(x => x.Id).ToArray() }
                };

                var detailsResult = await _dapper.QueryList<User_Code_dGroupDto>(detailsSql, parameters);

                if (!detailsResult.Succeeded)
                    return ReturnBase<IEnumerable<User_CodeReturnSearchDto>>.Fail(detailsResult.Errors);

                var detailsLookup = detailsResult.Result
                     .GroupBy(d => d.User_CodeId)
                     .ToDictionary(g => g.Key, g => g.ToList());

                foreach (var master in masters)
                {
                    if (detailsLookup.TryGetValue(master.Id, out var details))
                    {
                        master.User_Code_dGroups = details;
                    }
                }

                return ReturnBase<IEnumerable<User_CodeReturnSearchDto>>.Success(masters);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<User_CodeReturnSearchDto>>.Fail(ex, _exceptionManager);
            }
        }

        public override Task<ReturnBase<IEnumerable<User_CodeReturnSearchDto>>> Query(SqlQueryOptions queryOptions, string functionParameter)
        {
            throw new NotImplementedException();
        }

        public override Task<ReturnBase<IEnumerable<User_CodeReturnSearchDto>>> Query(SqlQueryOptions queryOptions, object[] functionParameters)
        {
            throw new NotImplementedException();
        }
    }
}