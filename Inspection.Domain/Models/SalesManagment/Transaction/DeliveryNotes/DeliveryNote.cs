using Inspection.Domain.Enums.Accounting.AR.SalesInvoices;
using Inspection.Domain.Enums.Posting;
using Inspection.Domain.Models.Accounting.AccountingSetup.Branches;
using Inspection.Domain.Models.Accounting.AccountingSystem.PaymentTerms;
using Inspection.Domain.Models.Accounting.AR.MasterData;
using Inspection.Domain.Models.Accounting.AR.SalesInvoices;
using Inspection.Domain.Models.Inventory.InventorySetup;
using Inspection.Domain.Models.MenuManagement;
using Inspection.Domain.Models.SalesManagment.Transaction.SalesOrders;
using Inspection.Domain.Models.SystemConfigurations.Currencies;
using Inspection.Domain.Shared.ApprovalStatus;
using NDS.Shared.Domain.Contracts;
using NDS.Shared.Domain.Contracts.EntityCommonData;
using NDS.Shared.Domain.Contracts.Multitenant;

namespace Inspection.Domain.Models.SalesManagment.Transaction.DeliveryNotes
{

    public class DeliveryNote : IRootEntity, ITenantEntity, IAuditable
    {
        public long Id { get; set; }
        public string DeliveryNoteNo { get; set; }
        public long CompanyId { get; set; }

        public long BranchId { get; set; }
        public Branch Branch { get; set; }


        public long? WarehouseId { get; set; }
        public Warehouse? Warehouse { get; set; }


        public long CustomerId { get; set; }
        public Customer Customer { get; set; }


        public DateTime DeliveryNoteDate { get; set; }


        public long? SalesOrderId { get; set; }
        public SalesOrder? SalesOrder { get; set; }
        public long? SalesInvoiceId { get; set; }
        public SalesInvoice? SalesInvoice { get; set; }


        public long CurrencyId { get; set; }
        public Currency Currency { get; set; }

        public long PaymentTermId { get; set; }
        public PaymentTerm PaymentTerm { get; set; }

        public decimal TotalAmount { get; set; }
        public decimal NetAmount { get; set; }
        public decimal? TaxAmount { get; set; }
        public string Notes { get; set; }
        public PostingEnum Posting { get; set; }
        public string CustomerPurchaseOrder { get; set; }
        public DateTime? CustomerPurchaseOrderDate { get; set; }

        public AdditionalDiscountType? AdditionalDiscountType { get; set; }
        public decimal? AdditionalDiscountValue { get; set; }
        public decimal? AdditionalDiscountAmount { get; set; }
        public decimal? TotalDiscount { get; set; }
        public decimal? ShipmentAmount { get; set; }

        public string ShipmentAddress { get; set; }
        public ShipmentStatus ShipmentStatus { get; set; }
        public ShipmentMethod ShipmentMethod { get; set; }
        public string DeliveryPersonName { get; set; }

        public virtual List<DeliveryNoteLine> DeliveryNoteLines { get; set; } = new List<DeliveryNoteLine>();


        // Series
        public Series Series { get; set; } = null!;
        public long? SeriesId { get; set; }
        public int RunningNumber { get; set; }

        // Status
        public ApprovalStatus ApprovalStatus { get; set; }

        public string Tenant_ID { get; set; } = string.Empty;
        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }
    }



}
