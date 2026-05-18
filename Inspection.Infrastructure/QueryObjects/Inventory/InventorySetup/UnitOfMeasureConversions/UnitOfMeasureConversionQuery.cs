using Inspection.Application.Contracts.Dto.Inventory.InventorySetup.UnitOfMeasureConversion;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.QueryObjects.Inventory.InventorySetup.UnitOfMeasureConversions
{
    public class UnitOfMeasureConversionQuery : QueryObjectBase<UnitOfMeasureConversionReturnSearchDto>
    {
        public UnitOfMeasureConversionQuery(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, ITenantResolver tenantResolver, IExceptionManager exceptionManager, string? fiscalYear = null) : base(queryBuilder, dapper, tenantResolver, exceptionManager, fiscalYear)
        {
        }

        public override async Task<ReturnBase<IEnumerable<UnitOfMeasureConversionReturnSearchDto>>> Query(SqlQueryOptions queryOptions)
        {
            try
            {
                string tableName = "Inventory.UnitOfMeasureConversion";

                var selectFields = new[]
                {
            "Id",
            "FromUoMId",
            "ToUoMId",
            "ConversionFactor",
            "Tenant_ID",
            "In_User",
            "In_Date",
            "Mod_User",
            "Mod_Date"
        };

                var fromUoMJoin = new JoinTable("Inventory.UnitOfMeasure", "Code FromUoMCode, Name FromUoMName", "FromUoMId Id");
                var toUoMJoin = new JoinTable("Inventory.UnitOfMeasure", "Code ToUoMCode, Name ToUoMName", "ToUoMId Id");

                var queryData = await _queryBuilder.GetQueryStringDataAsync(
                    tableName,
                    string.Join(", ", selectFields),
                    new List<JoinTable> { fromUoMJoin, toUoMJoin },
                    queryOptions
                );

                var queryResult = await _dapper.QueryList<UnitOfMeasureConversionReturnSearchDto>(
                    queryData.QueryString!,
                    queryData.Parameters!.ToDictionary()
                );

                return ReturnBase<IEnumerable<UnitOfMeasureConversionReturnSearchDto>>.Success(queryResult.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<UnitOfMeasureConversionReturnSearchDto>>.Fail(ex, _exceptionManager);
            }
        }
        public override Task<ReturnBase<IEnumerable<UnitOfMeasureConversionReturnSearchDto>>> Query(SqlQueryOptions queryOptions, string functionParameter)
        {
            throw new NotImplementedException();
        }
        public override Task<ReturnBase<IEnumerable<UnitOfMeasureConversionReturnSearchDto>>> Query(SqlQueryOptions queryOptions, object[] functionParameters)
        {
            throw new NotImplementedException();
        }
    }
}

