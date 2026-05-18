using Inspection.Domain.Enums;
using Inspection.Domain.Models.Accounting.AR.MasterData;
using Inspection.Domain.Models.InspectionManagement.CustomerLocations;
using Inspection.Domain.Models.InspectionManagement.CustomerProjects;
using Inspection.Domain.Models.InspectionManagement.InspectionTypes;
using Inspection.Domain.Models.MenuManagement;
using Inspection.Domain.Models.ServiceCatalog.ServiceTypes;
using NDS.Shared.Domain.Contracts;
using NDS.Shared.Domain.Contracts.EntityCommonData;
using NDS.Shared.Domain.Contracts.Multitenant;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inspection.Domain.Models.InspectionManagement.InspectionRequests
{

    public class InspectionRequest : IRootEntity, ITenantEntity, IAuditable
    {
        public long Id { get; set; }
        public string? Tenant_ID { get; set; }
        public long? CompanyId { get; set; }

        public string RequestNumber { get; set; } = string.Empty;
        public DateTime RequestDate { get; set; } = DateTime.UtcNow;

        public long CustomerId { get; set; }
        public Customer Customers { get; set; }

        public long? LocationId { get; set; } = default!;
        public CustomerLocation CustomerLocations { get; set; }

        public long? ContactPersonId { get; set; }
        public CustomerContact CustomerContact { get; set; }

        public long? CustomerProjectId { get; set; }
        public CustomerProject CustomerProjects { get; set; }

        public long? InspectionTypeId { get; set; }
        public InspectionType InspectionType { get; set; }

        public DateTime? RequestedInspectionDate { get; set; }
        public InspectionDocumentStatus DocumentStatus { get; set; } = InspectionDocumentStatus.Draft;
        public string DocumentStatusCancelledDescription { get; set; } = string.Empty;
        public InspectionApprovalStatus ApprovalStatus { get; set; }
        [MaxLength(500)]
        public string Remarks { get; set; } = string.Empty;

        public Series Series { get; set; }
        public long? SeriesId { get; set; }
        public int RunningNumber { get; set; }

        public ICollection<InspectionRequestLines> InspectionRequestLines { get; set; } = new List<InspectionRequestLines>();

        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }


    }
}








