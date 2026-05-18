using Inspection.Application.Contracts.Dto.EquipmentManagement.EquipmentSoftwares;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.QueryObjects.EquipmentManagment.EquipmentSoftwares
{


    internal class EquipmentSoftwareQuery : QueryObjectBase<EquipmentSoftwareDtoByInclude>
    {
        public EquipmentSoftwareQuery(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, ITenantResolver tenantResolver, IExceptionManager exceptionManager, string? fiscalYear = null) : base(queryBuilder, dapper, tenantResolver, exceptionManager, fiscalYear)
        {
        }

        public override async Task<ReturnBase<IEnumerable<EquipmentSoftwareDtoByInclude>>> Query(SqlQueryOptions queryOptions)
        {
            try
            {

                string tableName = "Inspection.EquipmentSoftware";
                string fields = "[Id], [CompanyEquipmentId],[Description],[Manufacturer],[Version],[Notes],[Tenant_ID]";
                QueryStringData query = await _queryBuilder.GetQueryStringDataAsync(tableName, fields, queryOptions);

                var result = await this._dapper.QueryList<EquipmentSoftwareDtoByInclude>(query.QueryString!, query.Parameters.ToDictionary());
                if (!result.Succeeded)
                    return ReturnBase<IEnumerable<EquipmentSoftwareDtoByInclude>>.Fail(result.Errors);

                return ReturnBase<IEnumerable<EquipmentSoftwareDtoByInclude>>.Success(result.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<EquipmentSoftwareDtoByInclude>>.Fail(ex, _exceptionManager);
            }
        }

        public override Task<ReturnBase<IEnumerable<EquipmentSoftwareDtoByInclude>>> Query(SqlQueryOptions queryOptions, string functionParameter)
        {
            throw new NotImplementedException();
        }
        public override Task<ReturnBase<IEnumerable<EquipmentSoftwareDtoByInclude>>> Query(SqlQueryOptions queryOptions, object[] functionParameters)
        {
            throw new NotImplementedException();
        }
    }
}