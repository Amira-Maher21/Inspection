using Inspection.Application.Contracts.Dto.AccountingDtos.Payments.JournalEntrys;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.QueryObjects.Accounting.Payments.JournalEntrys
{
    public class JournalEntryQuery : QueryObjectBase<JournalEntrySearchReturnDto>
    {
        public JournalEntryQuery(
            ISqlQueryBuilder queryBuilder,
            DapperDbContext dapper,
            ITenantResolver tenantResolver,
            IExceptionManager exceptionManager,
            string? fiscalYear = null)
            : base(queryBuilder, dapper, tenantResolver, exceptionManager, fiscalYear)
        {
        }

        public override async Task<ReturnBase<IEnumerable<JournalEntrySearchReturnDto>>> Query(SqlQueryOptions queryOptions)
        {
            try
            {
                string tableName = "Accounting.JournalEntry";

                var selectFields = new[]
                {
                    "Id",
                    "CompanyId",
                    "JournalNo",
                    "FiscalYearId",
                    "JournalDate",
                    "PostingDate",
                    "BranchId",
                    "CurrencyId",
                    "JournalEntryTemplateId",
                    "IsReverseJournal",
                    "ReversalOfJournalEntryId",
                    "TotalDebit",
                    "TotalCredit",
                    "ReferenceNumber",
                    "ReferenceDate",
                    "DocumentStatus",
                    "ApprovalStatus",
                    "Description",
                    "Tenant_ID",
                    "In_User",
                    "In_Date",
                    "Mod_User",
                    "Mod_Date"
                };

                // FiscalYear Join
                var fiscalYearJoin = new JoinTable(
                    "Accounting.FiscalYear",
                    "Code FiscalYearCode",
                    "FiscalYearId Id"
                );

                // Branch Join
                var branchJoin = new JoinTable(
                    "Accounting.Branch",
                    "Name BranchName, Code BranchCode",
                    "BranchId Id"
                );

                // Currency Join
                var currencyJoin = new JoinTable(
                    "Sec.Currency",
                    "Name CurrencyName, Code CurrencyCode",
                    "CurrencyId Id"
                );

                // JournalEntryTemplate Join
                var templateJoin = new JoinTable(
                    "Accounting.JournalEntryTemplate",
                    "Name JournalEntryTemplateName",
                    "JournalEntryTemplateId Id"
                ); //, Code JournalEntryTemplateCode


                var queryData = await _queryBuilder.GetQueryStringDataAsync(
                    tableName,
                    string.Join(", ", selectFields),
                    new List<JoinTable>
                    {
                        fiscalYearJoin,
                        branchJoin,
                        currencyJoin,
                        templateJoin,
                    },
                    queryOptions
                );

                var result = await _dapper.QueryList<JournalEntrySearchReturnDto>(
                    queryData.QueryString!,
                    queryData.Parameters!.ToDictionary()
                );

                if (!result.Succeeded)
                    return ReturnBase<IEnumerable<JournalEntrySearchReturnDto>>.Fail(result.Errors);

                return ReturnBase<IEnumerable<JournalEntrySearchReturnDto>>.Success(result.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<JournalEntrySearchReturnDto>>.Fail(ex, _exceptionManager);
            }
        }

        public override Task<ReturnBase<IEnumerable<JournalEntrySearchReturnDto>>> Query(SqlQueryOptions queryOptions, string functionParameter)
            => throw new NotImplementedException();

        public override Task<ReturnBase<IEnumerable<JournalEntrySearchReturnDto>>> Query(SqlQueryOptions queryOptions, object[] functionParameters)
            => throw new NotImplementedException();
    }
}