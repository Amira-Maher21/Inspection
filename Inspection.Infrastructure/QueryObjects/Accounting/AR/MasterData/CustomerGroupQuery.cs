using Inspection.Application.Contracts.Dto.AccountingDtos.AR.MasterData.CustomerGroup;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.QueryObjects.Accounting.AR.MasterData
{
    public class CustomerGroupQuery : QueryObjectBase<CustomerGroupReturnSearchDto>
    {
        public CustomerGroupQuery(
            ISqlQueryBuilder queryBuilder,
            DapperDbContext dapper,
            ITenantResolver tenantResolver,
            IExceptionManager exceptionManager,
            string? fiscalYear = null)
            : base(queryBuilder, dapper, tenantResolver, exceptionManager, fiscalYear)
        {
        }

        public override async Task<ReturnBase<IEnumerable<CustomerGroupReturnSearchDto>>> Query(SqlQueryOptions queryOptions)
        {
            try
            {
                var tableName = "Accounting.CustomerGroup";

                var selectFields = new[]
                {
                    "Id",
                    "GroupCode",
                    "GroupName",
                    "CreditLimit",
                    "PaymentTermsId",
                    "DefaultAccountGroupId",
                    "TaxCategoryId",
                    "Tenant_ID",
                    "In_User",
                    "In_Date",
                    "Mod_User",
                    "Mod_Date"
                };

                var paymentTermJoin = new JoinTable(
                    "Accounting.PaymentTerm",
                    "Code PaymentTermCode, Name PaymentTermName",
                    "PaymentTermsId Id"
                );

                var accountGroupJoin = new JoinTable(
                    "Accounting.DefaultAccountGroup",
                    "GroupCode DefaultAccountGroupCode, GroupName DefaultAccountGroupName",
                    "DefaultAccountGroupId Id"
                );

                var taxCategoryJoin = new JoinTable(
                    "Accounting.TaxCategory",
                    "Name TaxCategoryName,Code TaxCategoryCode ",
                    "TaxCategoryId Id"
                );


                var queryData = await _queryBuilder.GetQueryStringDataAsync(
                    tableName,
                    string.Join(", ", selectFields),
                    new List<JoinTable> { paymentTermJoin, accountGroupJoin, taxCategoryJoin },
                    queryOptions
                );

                var result = await _dapper.QueryList<CustomerGroupReturnSearchDto>(
                    queryData.QueryString!,
                    queryData.Parameters!.ToDictionary()
                );

                if (!result.Succeeded)
                    return ReturnBase<IEnumerable<CustomerGroupReturnSearchDto>>.Fail(result.Errors);

                return ReturnBase<IEnumerable<CustomerGroupReturnSearchDto>>.Success(result.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<CustomerGroupReturnSearchDto>>.Fail(ex, _exceptionManager);
            }
        }

        public override Task<ReturnBase<IEnumerable<CustomerGroupReturnSearchDto>>> Query(SqlQueryOptions queryOptions, string functionParameter)
            => throw new NotImplementedException();

        public override Task<ReturnBase<IEnumerable<CustomerGroupReturnSearchDto>>> Query(SqlQueryOptions queryOptions, object[] functionParameters)
            => throw new NotImplementedException();
    }
}
