using Inspection.Application.Contracts.Dto.Setting.ModuleSettings;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.QueryObjects.Setting.ModuleSetting
{
    internal class ModuleSettingQuery
        : QueryObjectBase<ModuleSettingReturnSearchDto>
    {
        public ModuleSettingQuery(
            ISqlQueryBuilder queryBuilder,
            DapperDbContext dapper,
            ITenantResolver tenantResolver,
            IExceptionManager exceptionManager,
            string? fiscalYear = null)
            : base(queryBuilder, dapper, tenantResolver, exceptionManager, fiscalYear)
        {
        }

        public override async Task<ReturnBase<IEnumerable<ModuleSettingReturnSearchDto>>>
            Query(SqlQueryOptions queryOptions)
        {
            try
            {
                string tableName = " ModuleSetting";

                string fields =
                    "[Id], [ProgramId], [SettingKey], [SettingValue], [ValueType], " +
                    "[Description], [CompanyId], [Tenant_ID]";

                var joins = new List<JoinTable>
                {
                    new JoinTable(
                        " Syst.Program",
                        "  ProgramName",
                        "ProgramId Program_ID"
                    )
                };

                var queryData = await _queryBuilder.GetQueryStringDataAsync(
                    tableName,
                    fields,
                    joins,
                    queryOptions
                );

                var result = await _dapper.QueryList<ModuleSettingReturnSearchDto>(
                    queryData.QueryString!,
                    queryData.Parameters!.ToDictionary()
                );

                if (!result.Succeeded)
                    return ReturnBase<IEnumerable<ModuleSettingReturnSearchDto>>
                        .Fail(result.Errors);

                return ReturnBase<IEnumerable<ModuleSettingReturnSearchDto>>
                    .Success(result.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<ModuleSettingReturnSearchDto>>
                    .Fail(ex, _exceptionManager);
            }
        }

        public override Task<ReturnBase<IEnumerable<ModuleSettingReturnSearchDto>>>
            Query(SqlQueryOptions queryOptions, string functionParameter)
        {
            throw new NotImplementedException();
        }

        public override Task<ReturnBase<IEnumerable<ModuleSettingReturnSearchDto>>>
            Query(SqlQueryOptions queryOptions, object[] functionParameters)
        {
            throw new NotImplementedException();
        }
    }
}
