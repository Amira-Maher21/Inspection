using Inspection.Application.Contracts.Dto.SystemConfigurationDTOs.CompanyDTOs;
using Inspection.Application.Contracts.Repositories.Query.SystemConfigurations.Companies;
using Inspection.Domain.Models.SystemConfigurations.Companies;
using Inspection.Infrastructure.QueryObjects.SystemConfigurations.CompanyQueries;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.Repositories.Query.SystemConfigurations.Companies
{
    public class CompanyQueryRepository : QueryRepositoryBase<Company>, ICompanyQueryRepository
    {
        public CompanyQueryRepository(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(queryBuilder, dapper, context, tenantResolver, exceptionManager)
        {
        }

        public async Task<Company?> GetById(long id)
        {
            return await _context.Set<Company>().Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<ReturnBase<IEnumerable<CompanyReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions)
        {
            var CompanyQueryRepository = new CompanyQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);
            return await CompanyQueryRepository.Query(sqlQueryOptions);
        }

        public async Task<ReturnBase<IEnumerable<CompanyDto>>> GetCompanyIdAndName(SqlQueryOptions queryOptions)
        {
            var companyQueryRepository = new CompanyQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);

            var result = await companyQueryRepository.Query(queryOptions);

            if (!result.Succeeded)
                return ReturnBase<IEnumerable<CompanyDto>>.Fail(result.Errors);

            var mapped = result.Result.Select(x => new CompanyDto
            {

                Id = x.Id,
                Tenant_ID = x.Tenant_ID,
                Code = x.Code,
                Name = x.Name,
                Address = x.Address,
                PhoneNumber = x.PhoneNumber,
                Email = x.Email,
                Website = x.Website,
                ReportingCurrencyId = x.ReportingCurrencyId,
                IndustrySector = x.IndustrySector,
                DefaultTaxTypeId = x.DefaultTaxTypeId,
                BuildingNumber = x.BuildingNumber,
                Street = x.Street,
                Zone = x.Zone,
                DefaultTaxType2Id = x.DefaultTaxType2Id,
                TaxIdNumber = x.TaxIdNumber,
                CommercialRegisterNumber = x.CommercialRegisterNumber,
                InventoryAccountId = x.InventoryAccountId,
                CogsAccountId = x.CogsAccountId,
                AdjustmentAccountId = x.AdjustmentAccountId,
                RevenueAccountId = x.RevenueAccountId,
                PurchaseAccountId = x.PurchaseAccountId,
                PurchaseReturnAccountId = x.PurchaseReturnAccountId,
                SalesReturnAccountId = x.SalesReturnAccountId,
                GoodsReceivedNotInvoicedAccountId = x.GoodsReceivedNotInvoicedAccountId,
                WipAccountId = x.WipAccountId,

                ActiveCostCenter = x.ActiveCostCenter,
                ActiveCostUnit = x.ActiveCostUnit,
                ActiveOperation = x.ActiveOperation,
                ActiveWBS = x.ActiveWBS,
                ActiveCostCode = x.ActiveCostCode,
                ActiveActivity = x.ActiveActivity,
                ActiveBOQItem = x.ActiveBOQItem,
                ActiveSubcontractBOQ = x.ActiveSubcontractBOQ,
                ActiveProductionOrder = x.ActiveProductionOrder,

                CountryId = x.CountryId,
                CityId = x.CityId,
                BaseCurrencyId = x.BaseCurrencyId,
                OfficialCurrencyId = x.OfficialCurrencyId,
                In_User = x.In_User,
                In_Date = x.In_Date,
                Mod_User = x.Mod_User,
                Mod_Date = x.Mod_Date,
                CostingMethodEnum = x.CostingMethodEnum


            }).ToList();

            return ReturnBase<IEnumerable<CompanyDto>>.Success(mapped);
        }
        public async Task<Company?> GetByCode(string code)
        {
            return await _context.Set<Company>().Where(x => x.Code == code).FirstOrDefaultAsync();
        }
    }
}