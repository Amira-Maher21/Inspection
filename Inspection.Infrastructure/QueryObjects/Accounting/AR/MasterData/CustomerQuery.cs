
using Inspection.Application.Contracts.Dto.AccountingDtos.AR.MasterData.CustomerContacts;
using Inspection.Application.Contracts.Dto.InspectionManagement.CustomerLocations;
using Inspection.Application.Contracts.Dto.InspectionManagement.CustomerProjects;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.QueryObjects.Accounting.AR.MasterData
{
    public class CustomerQuery : QueryObjectBase<CustomerReturnSearchDto>
    {
        public CustomerQuery(
            ISqlQueryBuilder queryBuilder,
            DapperDbContext dapper,
            ITenantResolver tenantResolver,
            IExceptionManager exceptionManager,
            string? fiscalYear = null)
            : base(queryBuilder, dapper, tenantResolver, exceptionManager, fiscalYear)
        {
        }

        public override async Task<ReturnBase<IEnumerable<CustomerReturnSearchDto>>> Query(SqlQueryOptions queryOptions)
        {
            try
            {
                var tableName = "Accounting.Customer";

                var selectFields = new[]
                {
                    "Id",
                    "Tenant_ID",
                    "SeriesId",
                    "RunningNumber",
                    "Code",
                    "Name",
                    "CustomerType",
                    "NationalId",
                    "TaxRegistrationNo",
                    "CommercialRegistryNo",
                    "CountryId",
                    "CityId",
                    "Address",
                    "Phone",
                    "Mobile",
                    "Email",
                    "Website",
                    "CustomerGroupId",
                    "CurrencyId",
                    "PaymentTermId",
                    "TaxCategoryId",
                    "CreditLimit",
                    "Disable",
                    "Notes",
                };

                // ================== JOINS ==================

                var countryJoin = new JoinTable(
                    "Sec.Country",
                    "Code CountryCode,Name CountryName",
                    "CountryId Id"
                );

                var cityJoin = new JoinTable(
                    "Sec.City",
                    "Code  CityCode,Name CityName",
                    "CityId Id"
                );

                var currencyJoin = new JoinTable(
                    "Sec.Currency",
                    "Code  CurrencyCode,Name CurrencyName",
                    "CurrencyId Id"
                );

                var customerGroupJoin = new JoinTable(
                    "Accounting.CustomerGroup",
                    "GroupCode CustomerGroupCode, GroupName CustomerGroupName",
                    "CustomerGroupId Id"
                );

                var paymentTermJoin = new JoinTable(
                    "Accounting.PaymentTerm",
                    "Code PaymentTermCode, Name PaymentTermName",
                    "PaymentTermId Id"
                );

                var taxCategoryJoin = new JoinTable(
                    "Accounting.TaxCategory",
                    "Code TaxCategoryCode, Name TaxCategoryName",
                    "TaxCategoryId Id"
                );

                var queryData = await _queryBuilder.GetQueryStringDataAsync(
                    tableName,
                    string.Join(", ", selectFields),
                    new List<JoinTable>
                    {
                        countryJoin,
                        cityJoin,
                        currencyJoin,
                        customerGroupJoin,
                        paymentTermJoin,
                        taxCategoryJoin
                    },
                    queryOptions
                );

                var customersResult = await _dapper.QueryList<CustomerReturnSearchDto>(
                    queryData.QueryString!,
                    queryData.Parameters!.ToDictionary()
                );

                if (!customersResult.Succeeded)
                    return ReturnBase<IEnumerable<CustomerReturnSearchDto>>.Fail(customersResult.Errors);

                //var customers = customersResult.Result.ToList();

                //if (!customers.Any())
                //    return ReturnBase<IEnumerable<CustomerReturnSearchDto>>.Success(customers);

                var customers = customersResult.Result?.ToList()
                ?? new List<CustomerReturnSearchDto>();

                if (customers.Count == 0)
                    return ReturnBase<IEnumerable<CustomerReturnSearchDto>>.Success(customers);

                // ================== CHILD TABLES ==================

                var parameters = new Dictionary<string, object>
                {
                    { "CustomerIds", customers.Select(x => x.Id).ToArray() }
                };

                var contactsResult = await _dapper.QueryList<CustomerContactDto>(
                    "SELECT * FROM [Accounting].[CustomerContact] WHERE CustomerId IN @CustomerIds",
                    parameters
                );

                var locationsResult = await _dapper.QueryList<CustomerLocationDto>(
                    "SELECT * FROM [Inspection].[CustomerLocation] WHERE CustomerId IN @CustomerIds",
                    parameters
                );

                var projectsResult = await _dapper.QueryList<CustomerProjectDto>(
                    "SELECT * FROM [Inspection].[CustomerProject] WHERE CustomerId IN @CustomerIds",
                    parameters
                );

                if (!contactsResult.Succeeded)
                    return ReturnBase<IEnumerable<CustomerReturnSearchDto>>.Fail(contactsResult.Errors);

                // ================== MAPPING ==================

                //var contactsLookup = contactsResult.Result
                //    .GroupBy(x => x.CustomerId)
                //    .ToDictionary(x => x.Key, x => x.ToList());

                //var locationsLookup = locationsResult.Result
                //    .GroupBy(x => x.CustomerId)
                //    .ToDictionary(x => x.Key, x => x.ToList());

                //var projectsLookup = projectsResult.Result
                //    .GroupBy(x => x.CustomerId)
                //    .ToDictionary(x => x.Key, x => x.ToList());

                var contactsLookup = (contactsResult.Result ?? Enumerable.Empty<CustomerContactDto>())
                    .GroupBy(x => x.CustomerId)
                    .ToDictionary(x => x.Key, x => x.ToList());

                var locationsLookup = (locationsResult.Result ?? Enumerable.Empty<CustomerLocationDto>())
                    .GroupBy(x => x.CustomerId)
                    .ToDictionary(x => x.Key, x => x.ToList());

                var projectsLookup = (projectsResult.Result ?? Enumerable.Empty<CustomerProjectDto>())
                    .GroupBy(x => x.CustomerId)
                    .ToDictionary(x => x.Key, x => x.ToList());


                foreach (var customer in customers)
                {
                    if (contactsLookup.TryGetValue(customer.Id, out var contacts))
                        customer.CustomerContact = contacts;

                    if (locationsLookup.TryGetValue(customer.Id, out var locations))
                        customer.CustomerLocation = locations;

                    if (projectsLookup.TryGetValue(customer.Id, out var projects))
                        customer.CustomerProject = projects;
                }

                return ReturnBase<IEnumerable<CustomerReturnSearchDto>>.Success(customers);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<CustomerReturnSearchDto>>.Fail(ex, _exceptionManager);
            }
        }

        public override Task<ReturnBase<IEnumerable<CustomerReturnSearchDto>>> Query(SqlQueryOptions queryOptions, string functionParameter)
            => throw new NotImplementedException();

        public override Task<ReturnBase<IEnumerable<CustomerReturnSearchDto>>> Query(SqlQueryOptions queryOptions, object[] functionParameters)
            => throw new NotImplementedException();
    }
}
