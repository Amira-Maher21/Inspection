using Inspection.Application.Contracts.Dto.AccountingDtos.PR.MasterData.SupplierGroups;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.QueryObjects.Accounting.PR.MasterData.SupplierGroups
{
    public class SupplierGroupQuery : QueryObjectBase<SupplierGroupReturnSearchDto>
    {
        public SupplierGroupQuery(
            ISqlQueryBuilder queryBuilder,
            DapperDbContext dapper,
            ITenantResolver tenantResolver,
            IExceptionManager exceptionManager,
            string? fiscalYear = null)
            : base(queryBuilder, dapper, tenantResolver, exceptionManager, fiscalYear)
        {
        }

        public override async Task<ReturnBase<IEnumerable<SupplierGroupReturnSearchDto>>> Query(SqlQueryOptions queryOptions)
        {
            try
            {
                string tableName = "Accounting.SupplierGroup";

                var selectFields = new[]
                {
                    "Id",
                    "Code",
                    "Name",
                    "Tenant_ID",
                    "DefaultAccountGroupId",
                    "PaymentTermsId",
                    "TaxCategoryId",
                    "Notes"
                };

                // Join مع DefaultAccountGroup
                var defaultAccountGroupJoin = new JoinTable(
                    "Accounting.DefaultAccountGroup",
                    "GroupCode   , GroupName   ",
                    "DefaultAccountGroupId Id"
                );

                // Join مع PaymentTerm
                var paymentTermJoin = new JoinTable(
                    "Accounting.PaymentTerm",
                    "Code   PaymentTermCode, Name   PaymentTermName",
                    "PaymentTermsId Id"
                );

                // Join مع TaxCategory
                var taxCategoryJoin = new JoinTable(
                    "Accounting.TaxCategory",
                    "Code   TaxCategoryCode, Name   TaxCategoryName",
                    "TaxCategoryId Id"
                );

                var queryData = await _queryBuilder.GetQueryStringDataAsync(
                    tableName,
                    string.Join(", ", selectFields),
                    new List<JoinTable> { defaultAccountGroupJoin, paymentTermJoin, taxCategoryJoin },
                    queryOptions
                );

                var result = await _dapper.QueryList<SupplierGroupReturnSearchDto>(
                    queryData.QueryString!,
                    queryData.Parameters!.ToDictionary()
                );

                if (!result.Succeeded)
                    return ReturnBase<IEnumerable<SupplierGroupReturnSearchDto>>.Fail(result.Errors);

                return ReturnBase<IEnumerable<SupplierGroupReturnSearchDto>>.Success(result.Result);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<SupplierGroupReturnSearchDto>>.Fail(ex, _exceptionManager);
            }
        }

        public override Task<ReturnBase<IEnumerable<SupplierGroupReturnSearchDto>>> Query(SqlQueryOptions queryOptions, string functionParameter)
            => throw new NotImplementedException();

        public override Task<ReturnBase<IEnumerable<SupplierGroupReturnSearchDto>>> Query(SqlQueryOptions queryOptions, object[] functionParameters)
            => throw new NotImplementedException();
    }
}
