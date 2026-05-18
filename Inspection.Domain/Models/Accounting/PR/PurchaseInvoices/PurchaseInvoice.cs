using Inspection.Domain.Enums.Accounting.AR.SalesInvoices;
using Inspection.Domain.Enums.Accounting.payments.JournalEntrys;
using Inspection.Domain.Models.Accounting.AccountingSetup.Branches;
using Inspection.Domain.Models.Accounting.AccountingSystem.PaymentTerms;
using Inspection.Domain.Models.Accounting.PR.MasterData.Suppliers;
using Inspection.Domain.Models.Inventory.InventorySetup;
using Inspection.Domain.Models.MenuManagement;
using Inspection.Domain.Models.SalesManagment.Setup.SalesPersons;
using Inspection.Domain.Models.SalesManagment.Transaction.SalesOrders;
using Inspection.Domain.Models.SystemConfigurations.Currencies;
using Inspection.Domain.Shared.ApprovalStatus;
using Inspection.Domain.Shared.Series;
using NDS.Shared.Domain.Contracts;
using NDS.Shared.Domain.Contracts.EntityCommonData;
using NDS.Shared.Domain.Contracts.Multitenant;

namespace Inspection.Domain.Models.Accounting.PR.PurchaseInvoices
{
    public class PurchaseInvoice : IRootEntity, ITenantEntity, IAuditable, ISeries
    {
        public long Id { get; private set; }
        public string InvoiceNo { get; set; } = string.Empty;

        public long BranchId { get; private set; }
        public Branch Branch { get; private set; }

        public long? WarehouseId { get; private set; }
        public Warehouse? Warehouse { get; private set; }

        public long SupplierId { get; private set; }
        public Supplier Supplier { get; private set; }

        public DateTime InvoiceDate { get; private set; }

        public long? SalesOrderId { get; private set; }
        public SalesOrder? SalesOrder { get; private set; }

        public long CurrencyId { get; private set; }
        public Currency Currency { get; private set; }

        public long PaymentTermId { get; private set; }
        public PaymentTerm PaymentTerm { get; private set; }

        public long? SalesPersonId { get; private set; }
        public SalesPerson? SalesPerson { get; private set; }


        public decimal TotalAmount { get; private set; }
        public decimal NetAmount { get; private set; }
        public decimal? TaxAmount { get; private set; }
        public DateTime PaymentDueDate { get; private set; }
        public string? Notes { get; private set; }
        public Posting Posting { get; set; }
        public AdditionalDiscountType? AdditionalDiscountType { get; private set; }
        public decimal? AdditionalDiscountValue { get; private set; }
        public decimal? AdditionalDiscountAmount { get; private set; }
        public decimal? ShipmentAmount { get; private set; }
        public string? ShipmentAddress { get; private set; }
        public ShipmentStatus? ShipmentStatus { get; private set; }
        public ShipmentMethod? ShipmentMethod { get; private set; }
        public decimal? TotalDiscount { get; private set; }

        public ApprovalStatus ApprovalStatus { get; private set; }
        public DocumentStatus Status { get; private set; }


        public ICollection<PurchaseInvoiceLine> InvoiceLines { get; set; } = new List<PurchaseInvoiceLine>();
        public ICollection<PurchaseInvoiceAdjustment> Adjustments { get; set; } = new List<PurchaseInvoiceAdjustment>();
        // Tenant & Company
        public string Tenant_ID { get; set; } = string.Empty;
        public long CompanyId { get; private set; }

        // Series
        public Series Series { get; set; } = null!;
        public long? SeriesId { get; set; }
        public int RunningNumber { get; set; }

        // Audit
        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }




    }
}