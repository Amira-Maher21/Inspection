using Inspection.Application.Contracts.Dto.AccountingDtos.AccountingSetupDtos.LedgerDTOs.LedgerLineDTOs;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.QueryObjects.Accounting.AccountSetup.Ledger
{
    internal class GetLedgerLineQuery : QueryObjectBase<ViewEntryLedgerDto>
    {

        public GetLedgerLineQuery(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, ITenantResolver tenantResolver, IExceptionManager exceptionManager, string? fiscalYear = null) : base(queryBuilder, dapper, tenantResolver, exceptionManager, fiscalYear)
        {
        }


        public override async Task<ReturnBase<IEnumerable<ViewEntryLedgerDto>>> Query(SqlQueryOptions queryOptions)
        {
            try
            {
                var tableName = "Accounting.Ledger";

                var selectFields = new[]
                {
                    "Id",
                    "PostingDate",
                    "ReferenceDocumentId",
                    "DocumentCode"
                };

                //var queryData = await _queryBuilder.GetQueryStringDataAsync(
                //    tableName,
                //    string.Join(", ", selectFields),
                //    new List<JoinTable>
                //    {
                //    },
                //    queryOptions
                //);

                    var queryData = await _queryBuilder.GetQueryStringDataAsync(
                        tableName,
                        string.Join(", ", selectFields),
                        queryOptions
                    );

                var ledgerResult = await _dapper.QueryList<ViewEntryLedgerDto>(
                    queryData.QueryString!,
                    queryData.Parameters!.ToDictionary()
                );

                if (!ledgerResult.Succeeded)
                    return ReturnBase<IEnumerable<ViewEntryLedgerDto>>.Fail(ledgerResult.Errors);

                var ledgers = ledgerResult.Result?.ToList() ?? new List<ViewEntryLedgerDto>();

                if (ledgers.Count == 0)
                    return ReturnBase<IEnumerable<ViewEntryLedgerDto>>.Success(ledgers);

                // ================= CHILD TABLE =================

                var parameters = new Dictionary<string, object>
                {
                    { "LedgerIds", ledgers.Select(x => x.Id).ToArray() }
                };

                var ledgerLinesResult = await _dapper.QueryList<ViewEntryLedgerLineDto>(
                    @"SELECT 
                        LL.Id,
                        LL.LedgerId,
                        LL.ChartOfAccountId,
                        COA.AccountCode,
                        COA.AccountName,
                        LL.DebitAmount,
                        LL.CreditAmount,
                        LL.CostCenterId,
                        LL.CostUnitId
                  FROM Accounting.LedgerLine LL
                  LEFT JOIN Accounting.ChartOfAccount COA
                        ON LL.ChartOfAccountId = COA.Id
                  WHERE LL.LedgerId IN @LedgerIds",
                    parameters
                );

                if (!ledgerLinesResult.Succeeded)
                    return ReturnBase<IEnumerable<ViewEntryLedgerDto>>.Fail(ledgerLinesResult.Errors);

                // ================= LOOKUP =================

                var ledgerLineLookup = (ledgerLinesResult.Result ?? Enumerable.Empty<ViewEntryLedgerLineDto>())
                    .GroupBy(x => x.LedgerId)
                    .ToDictionary(x => x.Key, x => x.ToList());

                foreach (var ledger in ledgers)
                {
                    if (ledgerLineLookup.TryGetValue(ledger.Id, out var lines))
                        ledger.LedgerLines = lines;
                }

                return ReturnBase<IEnumerable<ViewEntryLedgerDto>>.Success(ledgers);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<ViewEntryLedgerDto>>.Fail(ex, _exceptionManager);
            }
        }
        public override Task<ReturnBase<IEnumerable<ViewEntryLedgerDto>>> Query(SqlQueryOptions queryOptions, string functionParameter)
            => throw new NotImplementedException();

        public override Task<ReturnBase<IEnumerable<ViewEntryLedgerDto>>> Query(SqlQueryOptions queryOptions, object[] functionParameters)
            => throw new NotImplementedException();
    }
}
