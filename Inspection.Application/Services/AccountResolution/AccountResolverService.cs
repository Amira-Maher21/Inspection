using AutoMapper;
using Inspection.Application.Contracts.Managers;
using Inspection.Application.Contracts.Services.AccountResolution;
using Inspection.Application.Contracts.UnitOfWork;
using Inspection.Application.Services.ServicesBase;
using Inspection.Application.Shared.ExcelTemplate;
using Inspection.Domain.Enums.AccountResolver;
using Inspection.Domain.Models.AccountResolution;
using Inspection.Domain.Models.Inventory.ItemGroups;
using Inspection.Domain.Models.SystemConfigurations.Companies;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Application.Services.AccountResolution
{
    public class AccountResolverService : AccountsServiceBase, IAccountResolverService
    {
        private readonly ITenantResolver _tenantResolver;
        private readonly IAccountsQueriesManager _queriesManager;
        private readonly IExcelTemplateGenerator _templateGenerator;

        public AccountResolverService(
            IAccountUnitOfWork accountUoW,
            IAccountsQueriesManager queriesManager,
            IMapper mapper,
            IExceptionManager exceptionManager,
            ITenantResolver tenantResolver,
            IExcelTemplateGenerator templateGenerator
            ) : base(accountUoW, queriesManager, mapper, exceptionManager)
        {
            _queriesManager = queriesManager ?? throw new ArgumentNullException(nameof(queriesManager));
            _tenantResolver = tenantResolver ?? throw new ArgumentNullException(nameof(tenantResolver));
            _templateGenerator = templateGenerator ?? throw new ArgumentNullException(nameof(templateGenerator));
        }


        private static readonly Dictionary<AccountResolverPurpose, Func<ItemGroup, long?>> _itemGroupAccountMap =
        new()
        {
            { AccountResolverPurpose.Inventory, g => g.InventoryAccountId },
            { AccountResolverPurpose.CostOfGoodsSold, g => g.CogsAccountId },
            { AccountResolverPurpose.SalesRevenue, g => g.RevenueAccountId },
            { AccountResolverPurpose.PurchaseAccount, g => g.PurchaseAccountId },
            { AccountResolverPurpose.PurchaseReturn, g => g.PurchaseReturnAccountId },
            { AccountResolverPurpose.SalesReturn, g => g.SalesReturnAccountId },
            { AccountResolverPurpose.InventoryVariance, g => g.AdjustmentAccountId }
        };

        private long? GetAccountIdFromCompany(Company company, AccountResolverPurpose purpose)
        {
            return purpose switch
            {
                AccountResolverPurpose.Inventory => company.InventoryAccountId,
                AccountResolverPurpose.CostOfGoodsSold => company.CogsAccountId,
                AccountResolverPurpose.SalesRevenue => company.RevenueAccountId,
                AccountResolverPurpose.PurchaseAccount => company.PurchaseAccountId,
                AccountResolverPurpose.SalesReturn => company.SalesReturnAccountId,
                AccountResolverPurpose.InventoryVariance => company.AdjustmentAccountId,
                _ => null
            };
        }

        private long? GetAccountIdFromItemGroup(ItemGroup group, AccountResolverPurpose purpose)
        {
            if (!_itemGroupAccountMap.TryGetValue(purpose, out var selector))
                return null;

            return selector(group);
        }

        public async Task<AccountResolutionResult?> TryResolveAsync(AccountResolverContext context)
        {
            // Item
            if (context.ItemId.HasValue)
                return await ResolveFromItem(context.ItemId.Value, context);

            // Customer
            //if (context.CustomerId.HasValue)
            //    return await ResolveFromCustomer(context.CustomerId.Value, purpose);


            return null;
        }

        // Item
        private async Task<AccountResolutionResult?> ResolveFromItem(long itemId, AccountResolverContext context)
        {
            var item = await _queriesManager.Items.GetById(itemId);
            if (item == null)
                return null;

            // Try ItemGroup first
            var group = await _queriesManager.ItemGroup.GetById(item.ItemGroupId);
            if (group != null)
            {
                var groupAccountId = GetAccountIdFromItemGroup(group, context.Purpose);

                if (groupAccountId.HasValue)
                {
                    var account = await _queriesManager.ChartOfAccounts.GetById(groupAccountId.Value);
                    if (account != null)
                    {
                        return AccountResolutionResult.Resolved(
                            account.Id,
                            account.AccountCode,
                            account.AccountName,
                            resolvedBy: "ItemGroup",
                            priority: 1
                        );
                    }
                }
            }

            // Try get from Company
            var company = await _queriesManager.Companies.GetById(item.CompanyId);
            if (company != null)
            {
                var companyAccountId = GetAccountIdFromCompany(company, context.Purpose);

                if (companyAccountId.HasValue)
                {
                    var account = await _queriesManager.ChartOfAccounts.GetById(companyAccountId.Value);
                    if (account != null)
                    {
                        return AccountResolutionResult.Resolved(
                            account.Id,
                            account.AccountCode,
                            account.AccountName,
                            resolvedBy: "Company",
                            priority: 2
                        );
                    }
                }
            }

            // Not found
            return null;
        }




    }

}
