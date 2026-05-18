//using Inspection.Application.Contracts.Dto.AccountingDtos.PR.MasterData.SupplierContacts;
//using Inspection.Application.Contracts.Dto.AccountingDtos.PR.MasterData.Suppliers;
//using NDS.Shared.Application.DataQuery;
//using NDS.Shared.Application.Multitenant;
//using NDS.Shared.Infrastructure.DataContext;
//using NDS.Shared.Kernel.BaseReturnTypes;
//using NDS.Shared.Kernel.Exceptions;

//namespace Inspection.Infrastructure.QueryObjects.Accounting.PR.MasterData.Suppliers
//{
//    namespace Inspection.Infrastructure.QueryObjects.Accounting.PR.MasterData.Suppliers
//    {
//        public class SupplierQuery : QueryObjectBase<SuppliersDTOs>
//        {
//            public SupplierQuery(
//                ISqlQueryBuilder queryBuilder,
//                DapperDbContext dapper,
//                ITenantResolver tenantResolver,
//                IExceptionManager exceptionManager,
//                string? fiscalYear = null)
//                : base(queryBuilder, dapper, tenantResolver, exceptionManager, fiscalYear)
//            {
//            }

//            public override async Task<ReturnBase<IEnumerable<SuppliersDTOs>>> Query(SqlQueryOptions queryOptions)
//            {
//                try
//                {
//                    string tableName = "Supplier";
//                    string fields = "[Id], [Code], [Name], [Type], [NationId], [TaxRegistration], [CommercialRegistry], " +
//                                    "[Address], [Phone], [Mobile], [Email], [Website], [PaymentTermsId], [CreditLimit], [Dsiable], [Notes], " +
//                                    "[CountryId], [CityId], [CurrencyId], [TaxCategoryId], [Tenant_ID], [In_User], [In_Date], [Mod_User], [Mod_Date]";

//                    QueryStringData query =
//                        await _queryBuilder.GetQueryStringDataAsync(tableName, fields, queryOptions);

//                    var suppliersResult =
//                        await _dapper.QueryList<SuppliersDTOs>(
//                            query.QueryString!,
//                            query.Parameters.ToDictionary());

//                    if (!suppliersResult.Succeeded)
//                        return ReturnBase<IEnumerable<SuppliersDTOs>>.Fail(suppliersResult.Errors);

//                    var suppliers = suppliersResult.Result.ToList();

//                    if (!suppliers.Any())
//                        return ReturnBase<IEnumerable<SuppliersDTOs>>.Success(suppliers);

//                    // Supplier Contacts
//                    string contactsSql = @"
//            SELECT *
//            FROM SupplierContact
//            WHERE SupplierId IN @SupplierIds
//        ";

//                    var parameters = new Dictionary<string, object>
//        {
//            { "SupplierIds", suppliers.Select(x => x.Id).ToArray() }
//        };

//                    var contactsResult =
//                        await _dapper.QueryList<SupplierContactDTOs>(
//                            contactsSql,
//                            parameters
//                        );

//                    if (!contactsResult.Succeeded)
//                        return ReturnBase<IEnumerable<SuppliersDTOs>>.Fail(contactsResult.Errors);

//                    // Mapping
//                    var contactsLookup = contactsResult.Result
//                        .GroupBy(c => c.supplierId)
//                        .ToDictionary(g => g.Key, g => g.ToList());

//                    foreach (var supplier in suppliers)
//                    {
//                        if (contactsLookup.TryGetValue(supplier.Id, out var contacts))
//                            supplier.SupplierContactDTOs = contacts;
//                    }

//                    return ReturnBase<IEnumerable<SuppliersDTOs>>.Success(suppliers);
//                }
//                catch (Exception ex)
//                {
//                    return ReturnBase<IEnumerable<SuppliersDTOs>>.Fail(ex, _exceptionManager);
//                }
//            }

//            public override Task<ReturnBase<IEnumerable<SuppliersDTOs>>> Query(
//                SqlQueryOptions queryOptions,
//                string functionParameter)
//            {
//                throw new NotImplementedException();
//            }

//            public override Task<ReturnBase<IEnumerable<SuppliersDTOs>>> Query(
//                SqlQueryOptions queryOptions,
//                object[] functionParameters)
//            {
//                throw new NotImplementedException();
//            }
//        }
//    }
//}



using Inspection.Application.Contracts.Dto.AccountingDtos.PR.MasterData.Suppliers;
using Inspection.Domain.Models.Accounting.PR.MasterData.SupplierContacts;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.QueryObjects.Accounting.PR.MasterData.Suppliers
{
    public class SupplierQuery : QueryObjectBase<SupplierReturnSearchDto>
    {
        public SupplierQuery(
            ISqlQueryBuilder queryBuilder,
            DapperDbContext dapper,
            ITenantResolver tenantResolver,
            IExceptionManager exceptionManager,
            string? fiscalYear = null)
            : base(queryBuilder, dapper, tenantResolver, exceptionManager, fiscalYear)
        {
        }

        public override async Task<ReturnBase<IEnumerable<SupplierReturnSearchDto>>> Query(SqlQueryOptions queryOptions)
        {
            try
            {
                string tableName = "Accounting.Supplier";

                string fields = "[Id], [Code], [Name],  [NationId], [TaxRegistration], [CommercialRegistry], " +
                                "[Address], [Phone], [Mobile], [Email], [Website], [PaymentTermsId], [CreditLimit], [Dsiable], [Notes], " +
                                "[CountryId], [CityId], [CurrencyId], [TaxCategoryId], [SupplierGroupId], [Tenant_ID], [SeriesId], [RunningNumber]";

                var joins = new List<JoinTable>
                {
                    new JoinTable(
                    "Accounting.SupplierGroup",
                    "Code SupplierGroupCode, Name SupplierGroupNames",
                    "SupplierGroupId Id"),


                    new JoinTable(
                    "Accounting.PaymentTerm", "Code PaymentTermCode, Name PaymentTermName",
                    "PaymentTermsId Id"),


                    new JoinTable(
                     "Accounting.TaxCategory", "Code TaxCategoryCode, Name TaxCategoryName",
                     "TaxCategoryId Id"),


                    new JoinTable(
                    "Sec.Country", "Code CountryCode, Name CountryName",
                    "CountryId Id"),


                    new JoinTable(
                    "Sec.City", "Code CityCode, Name CityName",
                    "CityId Id"),


                    new JoinTable(
                    "Sec.Currency", "Code CurrencyCode, Name CurrencyName",
                    "CurrencyId Id")
                };

                var suppliersResult = await _dapper.QueryList<SupplierReturnSearchDto>(
                   (await _queryBuilder.GetQueryStringDataAsync(tableName, fields, joins, queryOptions)).QueryString!,
                   (await _queryBuilder.GetQueryStringDataAsync(tableName, fields, joins, queryOptions)).Parameters!.ToDictionary()
               );

                if (!suppliersResult.Succeeded)
                    return ReturnBase<IEnumerable<SupplierReturnSearchDto>>.Fail(suppliersResult.Errors);

                var suppliers = suppliersResult.Result.ToList();

                if (!suppliers.Any())
                    return ReturnBase<IEnumerable<SupplierReturnSearchDto>>.Success(suppliers);

                // ====== Supplier Contacts ======
                var parameters = new Dictionary<string, object>
                {
                    { "SupplierIds", suppliers.Select(x => x.Id).ToArray() }
                };

                var contactsResult = await _dapper.QueryList<SupplierContact>(
                    "SELECT * FROM Accounting.SupplierContact WHERE SupplierId IN @SupplierIds",
                    parameters
                );

                if (!contactsResult.Succeeded)
                    return ReturnBase<IEnumerable<SupplierReturnSearchDto>>.Fail(contactsResult.Errors);
                // ====== Supplier Contacts ======
                var contactParams = new Dictionary<string, object>
                {
                    { "SupplierIds", suppliers.Select(x => x.Id).ToArray() }
                };

                var contactsQueryResult = await _dapper.QueryList<SupplierContact>(
                   "SELECT * FROM Accounting.SupplierContact WHERE SupplierId IN @SupplierIds",
                   contactParams
               );

                if (!contactsQueryResult.Succeeded)
                    return ReturnBase<IEnumerable<SupplierReturnSearchDto>>.Fail(contactsQueryResult.Errors);

                // Mapping Supplier Contacts لكل Supplier
                var contactsLookup = contactsQueryResult.Result
                    .GroupBy(c => c.SupplierId)
                    .ToDictionary(g => g.Key, g => g.ToList());

                foreach (var supplier in suppliers)
                {
                    if (contactsLookup.TryGetValue(supplier.Id, out var contacts))
                        supplier.SupplierContacts = contacts;
                }



                return ReturnBase<IEnumerable<SupplierReturnSearchDto>>.Success(suppliers);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<SupplierReturnSearchDto>>.Fail(ex, _exceptionManager);
            }
        }

        public override Task<ReturnBase<IEnumerable<SupplierReturnSearchDto>>> Query(
            SqlQueryOptions queryOptions,
            string functionParameter) => throw new NotImplementedException();

        public override Task<ReturnBase<IEnumerable<SupplierReturnSearchDto>>> Query(
            SqlQueryOptions queryOptions,
            object[] functionParameters) => throw new NotImplementedException();
    }
}

