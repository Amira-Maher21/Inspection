using Inspection.Domain.Enums;
using Inspection.Domain.Models.Accounting.AR.MasterData;
using Inspection.Domain.Models.InspectionManagement.InspectionRequests;
using Inspection.Domain.Models.MenuManagement;
using Inspection.Domain.Models.SalesManagment.Transaction.SalesOrders;
using Inspection.Domain.Models.SalesManagment.Transaction.SalesQuotations;
using NDS.Shared.Domain.Contracts;
using NDS.Shared.Domain.Contracts.EntityCommonData;
using NDS.Shared.Domain.Contracts.Multitenant;
using System.ComponentModel.DataAnnotations;

namespace Inspection.Domain.Models.Inspection.Techinal.JobOrder
{

    public class JobOrder : IRootEntity, ITenantEntity, IAuditable
    {
        [Key]
        public long Id { get; set; }
        public string Tenant_ID { get; set; }
        public string CompanyId { get; set; } = string.Empty;

        public string JobOrderNumber { get; set; }
        public Customer Customer { get; set; }
        public long? CustomerId { get; set; }

        public InspectionRequest InspectionRequest { get; set; }
        public long? InspectionRequestId { get; set; }

        public SalesQuotation SalesQuotation { get; set; }
        public long? QuotationId { get; set; }

        public SalesOrder SalesOrder { get; set; } = null!;
        public long? SalesOrderId { get; set; }

        public DateTime JobOrderDate { get; set; }
        public DateTime PlannedStartDate { get; set; }
        public DateTime PlannedEndDate { get; set; }
        public string SiteContactName { get; set; } = string.Empty;
        public string SiteContactMobile { get; set; } = string.Empty;
        public string SiteContactEmail { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public string Remarks { get; set; } = string.Empty;

        public JobOrderDocumentStatus DocumentStatus { get; set; } = JobOrderDocumentStatus.Draft;
        public string DocumentStatusCancelledDescription { get; set; } = string.Empty;
        public SalesQuotationStatus ApprovalStatus { get; set; }

        // series related
        public Series Series { get; set; }
        public long? SeriesId { get; set; }
        public int RunningNumber { get; set; }

        public string In_User { get; set; } = string.Empty;

        public DateTime In_Date { get; set; }

        public string? Mod_User { get; set; }

        public DateTime? Mod_Date { get; set; }


        public ICollection<JobOrderLine> JobOrderLines { get; set; }



    }

}
