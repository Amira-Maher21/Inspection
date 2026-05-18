using Inspection.Domain.Models.Accounting.AccountingSystem.PaymentTerms;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.QueryObjects.Accounting.AccountSystem.PaymentTerms
{
    public class PaymentTermQuery : QueryObjectBase<PaymentTerm>
    {
        public PaymentTermQuery(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, ITenantResolver tenantResolver, IExceptionManager exceptionManager, string? fiscalYear = null) : base(queryBuilder, dapper, tenantResolver, exceptionManager, fiscalYear)
        {
        }

        public override async Task<ReturnBase<IEnumerable<PaymentTerm>>> Query(SqlQueryOptions queryOptions)
        {
            try
            {
                string tableName = "Accounting.PaymentTerm";
                string fields = "[Id],[Code],[Name], [DaysDue],[DiscountPercentage],[DaysDiscount],[Description],[Tenant_ID],[CompanyId]";
                QueryStringData query = await _queryBuilder.GetQueryStringDataAsync(tableName, fields, queryOptions);

                var result = await this._dapper.QueryList<PaymentTerm>(query.QueryString!, query.Parameters.ToDictionary());
                if (!result.Succeeded)
                    return ReturnBase<IEnumerable<PaymentTerm>>.Fail(result.Errors);

                return ReturnBase<IEnumerable<PaymentTerm>>.Success(result.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<PaymentTerm>>.Fail(ex, _exceptionManager);
            }
        }
        public override Task<ReturnBase<IEnumerable<PaymentTerm>>> Query(SqlQueryOptions queryOptions, string functionParameter)
        {
            throw new NotImplementedException();
        }
        public override Task<ReturnBase<IEnumerable<PaymentTerm>>> Query(SqlQueryOptions queryOptions, object[] functionParameters)
        {
            throw new NotImplementedException();
        }
    }
}


