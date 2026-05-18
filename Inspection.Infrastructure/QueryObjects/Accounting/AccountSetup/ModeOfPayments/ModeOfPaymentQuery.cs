using Inspection.Application.Contracts.Dto.AccountingDtos.AccountingSetupDtos.ModeOfPayments;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.QueryObjects.Accounting.AccountingSetup.ModeOfPayments
{
    public class ModeOfPaymentQuery : QueryObjectBase<ModeOfPaymentSearchReturnDto>
    {
        public ModeOfPaymentQuery(
            ISqlQueryBuilder queryBuilder,
            DapperDbContext dapper,
            ITenantResolver tenantResolver,
            IExceptionManager exceptionManager)
            : base(queryBuilder, dapper, tenantResolver, exceptionManager)
        {
        }

        public override async Task<ReturnBase<IEnumerable<ModeOfPaymentSearchReturnDto>>> Query(
            SqlQueryOptions queryOptions)
        {
            try
            {
                string tableName = "Accounting.ModeOfPayment";

                string selectFields = @"
                    [Id],
                    [Tenant_ID],
                    [Name],
                    [Description],
                    [ChartOfAccountId],
                    [CurrencyId],
                    [PaymentType],
                    [FeeType],
                    [FeesAccountId],
                    [Direction],
                    [FeeValue],
                    [HasFee],
                    [IncludeInPOS],
                    
                    [In_User],
                    [In_Date],
                    [Mod_User],
                    [Mod_Date]
                ";






                var queryData = await _queryBuilder.GetQueryStringDataAsync(
                                    tableName,
                                    selectFields,
                                    //new List<JoinTable>
                                    //{

                                    //},
                                    queryOptions
                                );

                var queryResult = await _dapper.QueryList<ModeOfPaymentSearchReturnDto>(
                    queryData.QueryString!,
                    queryData.Parameters!.ToDictionary()
                );

                return ReturnBase<IEnumerable<ModeOfPaymentSearchReturnDto>>
                    .Success(queryResult.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<ModeOfPaymentSearchReturnDto>>
                    .Fail(ex, _exceptionManager);
            }
        }

        public override Task<ReturnBase<IEnumerable<ModeOfPaymentSearchReturnDto>>> Query(
            SqlQueryOptions queryOptions,
            string functionParameter)
        {
            throw new NotImplementedException();
        }

        public override Task<ReturnBase<IEnumerable<ModeOfPaymentSearchReturnDto>>> Query(
            SqlQueryOptions queryOptions,
            object[] functionParameters)
        {
            throw new NotImplementedException();
        }
    }
}