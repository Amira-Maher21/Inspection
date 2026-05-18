using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Domain.Enums.AccountResolver
{
    public enum AccountResolverPurpose
    {
        // ── Receivables / Payables ────────────────────────────
        AccountsReceivable = 1,
        AccountsPayable,
        AdvanceFromCustomer,
        AdvanceToVendor,

        // ── Revenue ───────────────────────────────────────────
        SalesRevenue,
        SalesReturn,
        SalesDiscount,
        ShippingRevenue,
        ServiceRevenue,

        // ── Cost ──────────────────────────────────────────────
        CostOfGoodsSold,
        PurchaseAccount,
        PurchaseReturn,
        PurchaseDiscount,

        // ── Inventory ─────────────────────────────────────────
        Inventory,
        InventoryInTransit,
        InventoryVariance,

        // ── Tax ───────────────────────────────────────────────
        SalesTaxPayable,
        PurchaseTaxRecoverable,
        WithholdingTax,

        // ── Fixed Assets ──────────────────────────────────────
        AssetCost,
        AccumulatedDepreciation,
        DepreciationExpense,
        AssetDisposalGain,
        AssetDisposalLoss,

        // ── Payroll ───────────────────────────────────────────
        SalaryExpense,
        SocialInsurancePayable,
        IncomeTaxWithheld,
        NetPayable,

        // ── Bank / Cash ───────────────────────────────────────
        BankAccount,
        CashAccount,
        BankCharges,

        // ── Exchange ──────────────────────────────────────────
        ForeignExchangeGain,
        ForeignExchangeLoss,

        // ── Other ─────────────────────────────────────────────
        RoundingDifference,
        RetainedEarnings,
        OpeningBalance
    }

}
