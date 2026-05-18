using Inspection.Application.Contracts.Dto.EquipmentManagement.EquipmentAccessories;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.QueryObjects.EquipmentManagment.EquipmentAccessories
{


    internal class EquipmentAccessoriesQuery : QueryObjectBase<EquipmentAccessoryDtoByInclude>
    {
        public EquipmentAccessoriesQuery(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, ITenantResolver tenantResolver, IExceptionManager exceptionManager, string? fiscalYear = null) : base(queryBuilder, dapper, tenantResolver, exceptionManager, fiscalYear)
        {
        }

        public override async Task<ReturnBase<IEnumerable<EquipmentAccessoryDtoByInclude>>> Query(SqlQueryOptions queryOptions)
        {
            try
            {

                string tableName = "Inspection.EquipmentAccessory";
                string fields = "[Id], [CompanyEquipmentId],[Note],[Description],[Model],[SerialNumber],[Status],[Tenant_ID]";
                QueryStringData query = await _queryBuilder.GetQueryStringDataAsync(tableName, fields, queryOptions);

                var result = await this._dapper.QueryList<EquipmentAccessoryDtoByInclude>(query.QueryString!, query.Parameters.ToDictionary());
                if (!result.Succeeded)
                    return ReturnBase<IEnumerable<EquipmentAccessoryDtoByInclude>>.Fail(result.Errors);

                return ReturnBase<IEnumerable<EquipmentAccessoryDtoByInclude>>.Success(result.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<EquipmentAccessoryDtoByInclude>>.Fail(ex, _exceptionManager);
            }
        }

        public override Task<ReturnBase<IEnumerable<EquipmentAccessoryDtoByInclude>>> Query(SqlQueryOptions queryOptions, string functionParameter)
        {
            throw new NotImplementedException();
        }
        public override Task<ReturnBase<IEnumerable<EquipmentAccessoryDtoByInclude>>> Query(SqlQueryOptions queryOptions, object[] functionParameters)
        {
            throw new NotImplementedException();
        }
    }
}