using Inspection.Application.Contracts.Dto.AccountingDtos.AccountingSetupDtos.Branches;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.QueryObjects.Accounting.AccountSetup.Branches
{
    public class BranchQuery : QueryObjectBase<BranchReturnSearchDto>
    {
        public BranchQuery(
            ISqlQueryBuilder queryBuilder,
            DapperDbContext dapper,
            ITenantResolver tenantResolver,
            IExceptionManager exceptionManager,
            string? fiscalYear = null)
            : base(queryBuilder, dapper, tenantResolver, exceptionManager, fiscalYear)
        {
        }

        public override async Task<ReturnBase<IEnumerable<BranchReturnSearchDto>>> Query(SqlQueryOptions queryOptions)
        {
            try
            {
                var tableName = "Accounting.Branch";

                var selectFields = new[]
                {
                    "Id",
                    "Name",
                    "Code",
                    "Description",
                    "CompanyId",
                    "Tenant_ID",

                    "CountryId",
                    "CityId",
                    "Address",
                    "Phone",
                    "Email"
                };

                // Company Join
                var companyJoin = new JoinTable(
                    "Sec.Company",
                    "Code CompanyCode, Name CompanyName",
                    "CompanyId Id"
                );

                // Country Join
                var countryJoin = new JoinTable(
                    "Sec.Country",
                    "Code CountryCode, Name CountryName",
                    "CountryId Id"
                );

                // City Join
                var cityJoin = new JoinTable(
                    "Sec.City",
                    "Code CityCode, Name CityName",
                    "CityId Id"
                );

                var queryData = await _queryBuilder.GetQueryStringDataAsync(
                    tableName,
                    string.Join(", ", selectFields),
                    new List<JoinTable>
                    {
                        companyJoin,
                        countryJoin,
                        cityJoin
                    },
                    queryOptions
                );

                return await _dapper.QueryList<BranchReturnSearchDto>(
                    queryData.QueryString!,
                    queryData.Parameters!.ToDictionary()
                );
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<BranchReturnSearchDto>>.Fail(ex, _exceptionManager);
            }
        }


        public override Task<ReturnBase<IEnumerable<BranchReturnSearchDto>>> Query(
            SqlQueryOptions queryOptions,
            string functionParameter)
            => throw new NotImplementedException();

        public override Task<ReturnBase<IEnumerable<BranchReturnSearchDto>>> Query(
            SqlQueryOptions queryOptions,
            object[] functionParameters)
            => throw new NotImplementedException();
    }
}
