using Inspection.Application.Contracts.Dto.AccountingDtos.AccountingSetupDtos.AccountingPeriodDTOs;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.QueryObjects.Accounting.AccountSetup.AccountingPeriods
{
    public class AccountingPeriodQuery : QueryObjectBase<AccountingPeriodReturnSearchDto>
    {
        public AccountingPeriodQuery(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, ITenantResolver tenantResolver, IExceptionManager exceptionManager, string? fiscalYear = null)
            : base(queryBuilder, dapper, tenantResolver, exceptionManager, fiscalYear)
        {
        }





        public override async Task<ReturnBase<IEnumerable<AccountingPeriodReturnSearchDto>>> Query(SqlQueryOptions queryOptions)
        {
            try
            {
                var tableName = "Accounting.AccountingPeriod";

                var selectFields = new[]
               {
                    "Id",
                    "CompanyId",
                    "Tenant_ID",
                    "FiscalYearId",
                    "Code",
                    "Name",
                    "StartDate",
                    "LockDate",
                    "EndDate",
                    "IsClosed",
                    "In_User",
                    "In_Date",
                    "Mod_User",
                    "Mod_Date"
                };

                var joinTableName = "Accounting.FiscalYear";
                var joinSelectFields = "Code FiscalYearCode, Name FiscalYearName";
                var joinField = "FiscalYearId Id";
                var joinTable = new JoinTable(joinTableName, joinSelectFields, joinField);

                var queryData = await _queryBuilder.GetQueryStringDataAsync(
                   tableName,
                   string.Join(", ", selectFields),
                   new List<JoinTable> { joinTable },
                   queryOptions);

                var queryResult = await _dapper.QueryList<AccountingPeriodReturnSearchDto>(
                   queryData.QueryString!,
                   queryData.Parameters!.ToDictionary());

                return queryResult;
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<AccountingPeriodReturnSearchDto>>.Fail(ex, _exceptionManager);
            }
        }

        public override Task<ReturnBase<IEnumerable<AccountingPeriodReturnSearchDto>>> Query(SqlQueryOptions queryOptions, string functionParameter)
        {
            throw new NotImplementedException();
        }

        public override Task<ReturnBase<IEnumerable<AccountingPeriodReturnSearchDto>>> Query(SqlQueryOptions queryOptions, object[] functionParameters)
        {
            throw new NotImplementedException();
        }
    }
}

