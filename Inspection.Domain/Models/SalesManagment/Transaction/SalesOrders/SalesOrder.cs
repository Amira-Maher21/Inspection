using Inspection.Domain.Enums;
using Inspection.Domain.Models.Accounting.AccountingSetup.Branches;
using Inspection.Domain.Models.Accounting.AccountingSystem.PaymentTerms;
using Inspection.Domain.Models.Accounting.AR.MasterData;
using Inspection.Domain.Models.MenuManagement;
using Inspection.Domain.Models.SalesManagment.Setup.SalesPersons;
using Inspection.Domain.Models.SalesManagment.Transaction.SalesQuotations;
using Inspection.Domain.Models.System.Taxes;
using Inspection.Domain.Models.SystemConfigurations.Currencies;
using NDS.Shared.Domain.Contracts;
using NDS.Shared.Domain.Contracts.EntityCommonData;
using NDS.Shared.Domain.Contracts.Multitenant;

namespace Inspection.Domain.Models.SalesManagment.Transaction.SalesOrders
{
    public class SalesOrder : IRootEntity, ITenantEntity, IAuditable
    {
        public long Id { get; set; }
        public string Tenant_ID { get; set; } = string.Empty;
        public string CompanyId { get; set; } = string.Empty;

        public string OrderNumber { get; set; } = string.Empty;
        public DateTime? OrderDate { get; set; }

        public long CustomerId { get; set; }
        public virtual Customer Customer { get; set; } = null!;

        public long? SalesQuotationId { get; set; }
        public SalesQuotation SalesQuotation { get; set; } = null!;

        public Currency Currency { get; set; } = null!;
        public long? CurrencyId { get; set; }

        public PaymentTerm PaymentTerm { get; set; } = null!;
        public long? PaymentTermId { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public decimal? SubTotal { get; set; }
        public decimal Discount { get; set; }
        //public decimal? TaxAmount { get; set; }
        public TaxType TaxType { get; set; } = null!;
        public long? TaxTypeId { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime? ValidUntil { get; set; }
        public long? SalespersonId { get; set; }
        public SalesPerson Salesperson { get; set; } = null!;
        public long? BranchId { get; set; }
        public Branch Branch { get; set; } = null!;
        public string Notes { get; set; } = string.Empty;
        public SalesOrderDocumentStatus DocumentStatus { get; set; } = SalesOrderDocumentStatus.Draft;
        public SalesOrderApprovalStatus ApprovalStatus { get; set; } = SalesOrderApprovalStatus.Initialized;
        public string DocumentStatusCancelledReason { get; set; } = string.Empty;
        public virtual ICollection<SalesOrderLines> SalesOrderLines { get; set; } = new List<SalesOrderLines>();
        // series related
        public Series Series { get; set; } = null!;
        public long? SeriesId { get; set; }
        public int RunningNumber { get; set; }
        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }
    }
}