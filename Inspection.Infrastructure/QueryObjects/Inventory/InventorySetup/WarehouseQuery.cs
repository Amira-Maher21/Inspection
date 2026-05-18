using Inspection.Application.Contracts.Dto.Inventory.InventorySetup;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.QueryObjects.Inventory.InventorySetup
{
    public class WarehouseQuery : QueryObjectBase<WarehouseReturnSearchDto>
    {
        public WarehouseQuery(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, ITenantResolver tenantResolver, IExceptionManager exceptionManager, string? fiscalYear = null) : base(queryBuilder, dapper, tenantResolver, exceptionManager, fiscalYear)
        {
        }

        public override async Task<ReturnBase<IEnumerable<WarehouseReturnSearchDto>>> Query(SqlQueryOptions queryOptions)
        {
            try
            {
                string tableName = "Inventory.[Warehouse]";
                string fields = "[Id],[CompanyId],[Tenant_ID], [BranchId],[Code],[Name],[Description],[InventoryAccountId],[CountryId],[CityId],[Address],[ResponsibleEmployeeId],[ContactPhone],[ContactEmail]";


                var Join1 = new JoinTable("Accounting.Branch", "Code BranchCode, Name BranchName", "BranchId Id");
                var Join2 = new JoinTable("Sec.Country", "Code CountryCode, Name CountryName", "CountryId Id");
                var Join3 = new JoinTable("Sec.City", "Code CityCode, Name CityName", "CityId Id");
                var Join4 = new JoinTable("Accounting.ChartOfAccount", "AccountCode, AccountName", "InventoryAccountId Id");
                var Join5 = new JoinTable("HR.Employee", "EmployeeCode ,FullName EmployeeName", "ResponsibleEmployeeId Id");

                var queryData = await _queryBuilder.GetQueryStringDataAsync(
                    tableName,
                    string.Join(", ", fields),
                    new List<JoinTable> { Join1, Join2, Join3, Join4, Join5 },
                    queryOptions
                );

                var queryResult = await _dapper.QueryList<WarehouseReturnSearchDto>(
                    queryData.QueryString!,
                    queryData.Parameters!.ToDictionary()
                );

                return ReturnBase<IEnumerable<WarehouseReturnSearchDto>>.Success(queryResult.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<WarehouseReturnSearchDto>>.Fail(ex, _exceptionManager);
            }
        }
        public override Task<ReturnBase<IEnumerable<WarehouseReturnSearchDto>>> Query(SqlQueryOptions queryOptions, string functionParameter)
        {
            throw new NotImplementedException();
        }
        public override Task<ReturnBase<IEnumerable<WarehouseReturnSearchDto>>> Query(SqlQueryOptions queryOptions, object[] functionParameters)
        {
            throw new NotImplementedException();
        }
    }
}

