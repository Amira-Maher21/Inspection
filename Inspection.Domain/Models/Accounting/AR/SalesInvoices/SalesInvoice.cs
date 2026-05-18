using Inspection.Domain.Enums.Accounting.AR.SalesInvoices;
using Inspection.Domain.Enums.Posting;
using Inspection.Domain.Models.Accounting.AccountingSetup.Branches;
using Inspection.Domain.Models.Accounting.AccountingSystem.PaymentTerms;
using Inspection.Domain.Models.Accounting.AR.MasterData;
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

namespace Inspection.Domain.Models.Accounting.AR.SalesInvoices
{
    public class SalesInvoice : IRootEntity, ITenantEntity, IAuditable, ISeries
    {
        public long Id { get; private set; }
        public string InvoiceNo { get; set; } = string.Empty;

        public string Tenant_ID { get; set; } = string.Empty;
        public long CompanyId { get; private set; }

        public long BranchId { get; set; }
        public Branch Branch { get; set; } = null!;

        public long? WarehouseId { get; set; }
        public Warehouse? Warehouse { get; set; }

        public long CustomerId { get; set; }
        public Customer Customer { get; set; }

        public DateTime InvoiceDate { get; set; }

        public long? SalesOrderId { get; set; }
        public SalesOrder? SalesOrder { get; set; }

        public long CurrencyId { get; set; }
        public Currency Currency { get; set; } = null!;


        public long PaymentTermsId { get; set; }
        public PaymentTerm PaymentTerm { get; set; } = null!;

        public long? SalesPersonId { get; set; }
        public SalesPerson? SalesPerson { get; set; }

        public decimal TotalAmount { get; set; }
        public decimal NetAmount { get; set; }
        public decimal? TaxAmount { get; set; }
        public DateTime PaymentDuesDate { get; set; }

        public string? Notes { get; set; }
        public PostingEnum? Posting { get; set; }
        public string? CustomersPurchaseOrder { get; set; }
        public DateTime? CustomersPurchaseOrderDate { get; set; }

        public AdditionalDiscountType? AdditionalDiscountType { get; set; }

        public decimal? AdditionalDiscountValue { get; set; }
        public decimal? AdditionalDiscountAmount { get; set; }
        public decimal? TotalDiscount { get; set; }
        public decimal? ShipmentAmount { get; set; }
        public string? ShipmentAddress { get; set; }
        public ShipmentStatus? ShipmentStatus { get; set; }
        public ShipmentMethod? ShipmentMethod { get; set; }

        public ApprovalStatus ApprovalStatus { get; set; }


        // Amounts

        public ICollection<SalesInvoiceLine> SalesInvoiceLines { get; set; } = new List<SalesInvoiceLine>();
        public ICollection<SalesInvoiceSalesAdjustment> SalesInvoiceSalesAdjustments { get; set; } = new List<SalesInvoiceSalesAdjustment>();
        public ICollection<SalesInvoiceSalesPerson> SalesInvoiceSalesPersons { get; set; } = new List<SalesInvoiceSalesPerson>();



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