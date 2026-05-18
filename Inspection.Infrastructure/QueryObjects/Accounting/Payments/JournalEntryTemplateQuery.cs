using Inspection.Application.Contracts.Dto.AccountingDtos.Payments.JournalEntryTemplates;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.QueryObjects.Accounting.Payments
{
    internal class JournalEntryTemplateQuery : QueryObjectBase<JournalEntryTemplateSearchReturnDto>
    {
        public JournalEntryTemplateQuery(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, ITenantResolver tenantResolver, IExceptionManager exceptionManager, string? fiscalYear = null) : base(queryBuilder, dapper, tenantResolver, exceptionManager, fiscalYear)
        {
        }


        public override async Task<ReturnBase<IEnumerable<JournalEntryTemplateSearchReturnDto>>> Query(
       SqlQueryOptions queryOptions)
        {
            try
            {
                string tableName = "Accounting.JournalEntryTemplate";

                string selectFields = @"
                        [Id],
                        [Name],
                        [CurrencyId],
                        [TotalDebit],
                        [TotalCredit],
                        [Description],
                        [Tenant_ID],
                        [SeriesId],
                        [In_User],
                        [In_Date],
                        [Mod_User],
                        [Mod_Date]
                    ";


                var currencyJoin = new JoinTable(
                    "Sec.Currency",
                    "Name CurrencyName, Code CurrencyCode",
                    "CurrencyId Id"
                );

                var queryData = await _queryBuilder.GetQueryStringDataAsync(
                    tableName,
                    selectFields,
                    new List<JoinTable>
                    {
                     currencyJoin,
                    },
                    queryOptions
                );

                var queryResult = await _dapper.QueryList<JournalEntryTemplateSearchReturnDto>(
                    queryData.QueryString!,
                    queryData.Parameters!.ToDictionary()
                );

                return ReturnBase<IEnumerable<JournalEntryTemplateSearchReturnDto>>
                    .Success(queryResult.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<JournalEntryTemplateSearchReturnDto>>
                    .Fail(ex, _exceptionManager);
            }
        }
        public override Task<ReturnBase<IEnumerable<JournalEntryTemplateSearchReturnDto>>> Query(SqlQueryOptions queryOptions, string functionParameter)
        {
            throw new NotImplementedException();
        }

        public override Task<ReturnBase<IEnumerable<JournalEntryTemplateSearchReturnDto>>> Query(SqlQueryOptions queryOptions, object[] functionParameters)
        {
            throw new NotImplementedException();
        }
    }

}
