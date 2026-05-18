using Inspection.Application.Contracts.Dto.EquipmentManagement.EquipmentsMoreInformationTemplateDetails;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.QueryObjects.EquipmentManagment.EquipmentsMoreInformationTemplateDetails
{

    internal class EquipmentsMoreInformationTemplateDetailQuery : QueryObjectBase<EquipmentsMoreInformationTemplateDetailDtoByInclude>
    {
        public EquipmentsMoreInformationTemplateDetailQuery(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, ITenantResolver tenantResolver, IExceptionManager exceptionManager, string? fiscalYear = null) : base(queryBuilder, dapper, tenantResolver, exceptionManager, fiscalYear)
        {
        }
        public override async Task<ReturnBase<IEnumerable<EquipmentsMoreInformationTemplateDetailDtoByInclude>>> Query(SqlQueryOptions queryOptions)
        {

            try
            {
                string baseTable = "Inspection.EquipmentsMoreInformationTemplateDetail";
                string baseAlias = "EqT";

                var selectFields = new List<string>
                {
                    "KeyName",
                    "KeyValue",
                    "EquipmentsMoreInformationTemplateId",
                    "Tenant_ID"
                };


                var joins = new List<(string JoinType, string Table, string Alias, string Condition)>();

                var sql = base.ApplyJoinQuary(baseTable, baseAlias, selectFields, joins, queryOptions);

                var result = await _dapper.QueryList<EquipmentsMoreInformationTemplateDetailDtoByInclude>(sql);

                if (!result.Succeeded)
                    return ReturnBase<IEnumerable<EquipmentsMoreInformationTemplateDetailDtoByInclude>>.Fail(result.Errors);

                var list = base.ApplyFilters(result.Result, queryOptions);
                return ReturnBase<IEnumerable<EquipmentsMoreInformationTemplateDetailDtoByInclude>>.Success(list);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<EquipmentsMoreInformationTemplateDetailDtoByInclude>>.Fail(ex, _exceptionManager);
            }
        }

        public override Task<ReturnBase<IEnumerable<EquipmentsMoreInformationTemplateDetailDtoByInclude>>> Query(SqlQueryOptions queryOptions, string functionParameter)
        {
            throw new NotImplementedException();
        }
        public override Task<ReturnBase<IEnumerable<EquipmentsMoreInformationTemplateDetailDtoByInclude>>> Query(SqlQueryOptions queryOptions, object[] functionParameters)
        {
            throw new NotImplementedException();
        }
    }
}