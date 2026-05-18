using Inspection.Application.Contracts.Dto.SystemDto.Taxs;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.QueryObjects.System.TaxQueries
{
    internal class TaxQuery : QueryObjectBase<TaxReturnSearchDto>
    {
        public TaxQuery(
            ISqlQueryBuilder queryBuilder,
            DapperDbContext dapper,
            ITenantResolver tenantResolver,
            IExceptionManager exceptionManager,
            string? fiscalYear = null)
            : base(queryBuilder, dapper, tenantResolver, exceptionManager, fiscalYear)
        {
        }

        public override async Task<ReturnBase<IEnumerable<TaxReturnSearchDto>>> Query(SqlQueryOptions queryOptions)
        {
            try
            {
                string tableName = "Accounting.Taxtype";

                string fields = "[Id], [Name],[Code],[Percentage],[Description],[IsActive],[IsRecoverable],[IsInclusive]" +
                    ",[taxCategoryId],[TaxAccountId],[IsExempt],[EtaCodeEgypt],[IsSystem]" +
                    ",[Tenant_ID]";

                var joins = new List<JoinTable>
                {
                    new JoinTable(
                        "Accounting.TaxCategory",
                        "Code TaxCategoryCode, Name TaxCategoryName",
                        "taxCategoryId Id"
                    ),
                    new JoinTable(
                        "Accounting.ChartOfAccount",
                        "AccountCode  TaxAccountCode,AccountName   TaxAccountName",
                        "TaxAccountId Id"
                    )
                };

                var queryData = await _queryBuilder.GetQueryStringDataAsync(
                    tableName,
                    fields,
                    joins,
                    queryOptions
                );

                var result = await _dapper.QueryList<TaxReturnSearchDto>(
                    queryData.QueryString!,
                    queryData.Parameters!.ToDictionary()
                );

                if (!result.Succeeded)
                    return ReturnBase<IEnumerable<TaxReturnSearchDto>>.Fail(result.Errors);

                return ReturnBase<IEnumerable<TaxReturnSearchDto>>.Success(result.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<TaxReturnSearchDto>>.Fail(ex, _exceptionManager);
            }
        }

        public override Task<ReturnBase<IEnumerable<TaxReturnSearchDto>>> Query(SqlQueryOptions queryOptions, string functionParameter)
        {
            throw new NotImplementedException();
        }

        public override Task<ReturnBase<IEnumerable<TaxReturnSearchDto>>> Query(SqlQueryOptions queryOptions, object[] functionParameters)
        {
            throw new NotImplementedException();
        }
    }
}
