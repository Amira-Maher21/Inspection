using Inspection.Application.Contracts.Dto.AccountingDtos.AccountingSetupDtos.LedgerDTOs;
using Inspection.Application.Contracts.Dto.AccountingDtos.AccountingSetupDtos.LedgerDTOs.LedgerLineDTOs;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.QueryObjects.Accounting.AccountSetup.Ledger
{
    internal class LedgerQuery : QueryObjectBase<LedgerDto>
    {

        public LedgerQuery(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, ITenantResolver tenantResolver, IExceptionManager exceptionManager, string? fiscalYear = null) : base(queryBuilder, dapper, tenantResolver, exceptionManager, fiscalYear)
        {
        }


        public override async Task<ReturnBase<IEnumerable<LedgerDto>>> Query(SqlQueryOptions queryOptions)
        {

            try
            {
                string tableName = "Accounting.Ledger";
                string baseAlias = "L";


                var selectFields = new List<string>
                {
                    "L.Id",
                    "L.PostingDate",
                    "L.TotalDebit",
                    "L.TotalCredit",

                    // Audit
                    "L.In_User",
                    "L.In_Date",
                    "L.Mod_User",
                    "L.Mod_Date"

                };

                var queryData = await _queryBuilder.GetQueryStringDataAsync(
                    tableName,
                    string.Join(", ", selectFields),
                    new List<JoinTable>
                    {
                    },
                    queryOptions
                );

                var LedgerResult = await _dapper.QueryList<LedgerDto>(
                    queryData.QueryString!,
                    queryData.Parameters!.ToDictionary()
                );

                if (!LedgerResult.Succeeded)
                    return ReturnBase<IEnumerable<LedgerDto>>.Fail(LedgerResult.Errors);

                var LedgerList = LedgerResult.Result?.ToList()
                ?? new List<LedgerDto>();

                if (LedgerList.Count == 0)
                    return ReturnBase<IEnumerable<LedgerDto>>.Success(LedgerList);

                // Slaes Order Lines
                var parameters = new Dictionary<string, object>
                {
                    { "LedgerIds", LedgerList.Select(x => x.Id).ToArray() }
                };

                var LedgerLinesResult = await _dapper.QueryList<LedgerLineDto>(
                    "SELECT * FROM [Accounting].[LedgerLine] WHERE LedgerId IN @LedgerIds",
                    parameters
                );

                if (!LedgerLinesResult.Succeeded)
                    return ReturnBase<IEnumerable<LedgerDto>>.Fail(LedgerLinesResult.Errors);

                var LedgerLineLookup = (LedgerLinesResult.Result ?? Enumerable.Empty<LedgerLineDto>())
                    .GroupBy(x => x.LedgerId)
                    .ToDictionary(x => x.Key, x => x.ToList());

                foreach (var Ledger in LedgerList)
                {
                    if (LedgerLineLookup.TryGetValue(Ledger.Id, out var LedgerLines))
                        Ledger.LedgerLines = LedgerLines;
                }

                return ReturnBase<IEnumerable<LedgerDto>>.Success(LedgerList);

            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<LedgerDto>>.Fail(ex, _exceptionManager);
            }
        }

        public override Task<ReturnBase<IEnumerable<LedgerDto>>> Query(SqlQueryOptions queryOptions, string functionParameter)
        {
            throw new NotImplementedException();
        }

        public override Task<ReturnBase<IEnumerable<LedgerDto>>> Query(SqlQueryOptions queryOptions, object[] functionParameters)
        {
            throw new NotImplementedException();
        }
    }
}
