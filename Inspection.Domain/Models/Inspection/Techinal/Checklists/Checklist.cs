using Inspection.Domain.Enums;
using Inspection.Domain.Enums.Checklists;
using Inspection.Domain.Models.Accounting.AR.MasterData;
using Inspection.Domain.Models.EquipmentManagement.Equipments;
using Inspection.Domain.Models.Inspection.Techinal.ChecklistLines;
using Inspection.Domain.Models.Inspection.Techinal.ChecklistTemplates;
using Inspection.Domain.Models.Inspection.Techinal.InspectionStandards;
using Inspection.Domain.Models.Inspection.Techinal.Inspectors;
using Inspection.Domain.Models.Inspection.Techinal.JobOrder;
using Inspection.Domain.Models.InspectionManagement.InspectionTypes;
using Inspection.Domain.Shared.Series;
using NDS.Shared.Domain.Contracts;
using NDS.Shared.Domain.Contracts.EntityCommonData;
using NDS.Shared.Domain.Contracts.Multitenant;

namespace Inspection.Domain.Models.Inspection.Techinal.Checklists
{
    public class Checklist : IRootEntity, ITenantEntity, IAuditable, ISeries
    {
        public long Id { get; private set; }
        public long EquipmentId { get; set; }
        public Equipment Equipment { get; set; } = null!;
        public long InspectorId { get; set; }
        public Inspector Inspector { get; set; } = null!;
        public long ChecklistTemplateId { get; set; }
        public ChecklistTemplate ChecklistTemplate { get; set; } = null!;
        public long StandardId { get; set; }
        public InspectionStandard InspectionStandard { get; set; } = null!;
        public long InspectionTypeId { get; set; }
        public InspectionType InspectionType { get; set; } = null!;
        public long JoborderId { get; set; }
        public Models.Inspection.Techinal.JobOrder.JobOrder JobOrder { get; set; } = null!;
        public long? JobOrderLineId { get; set; }
        public JobOrderLine? JobOrderLine { get; set; }

        public long CustomerId { get; private set; }
        public Customer Customer { get; private set; } = null!;

        public EquipmentStatus Status { get; set; }
        public string Location { get; set; } = string.Empty;
        public string Remarks { get; set; } = string.Empty;
        public DateTime InspectionDate { get; set; }
        public long CompanyId { get; set; }

        public ChecklistDocStatus DocStatus { get; set; }
        public List<ChecklistLine> ChecklistLines { get; set; } = new List<ChecklistLine>();
        //series
        public long? SeriesId { get; set; }
        public int RunningNumber { get; set; }
        public string ChecklistNumber { get; set; } = string.Empty;

        public string Tenant_ID { get; set; } = string.Empty;
        // Audit
        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }
    }
}