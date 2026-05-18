using Inspection.Domain.Enums;
using Inspection.Domain.Models.Accounting.AR.MasterData;
using Inspection.Domain.Models.EquipmentManagement.Equipments;
using Inspection.Domain.Models.EquipmentManagement.EquipmentTypes;
using Inspection.Domain.Models.Inspection.Techinal.Inspectors;
using Inspection.Domain.Models.Inspection.Techinal.JobOrder;
using Inspection.Domain.Models.InspectionManagement.CustomerLocations;
using Inspection.Domain.Models.InspectionManagement.CustomerProjects;
using Inspection.Domain.Models.InspectionManagement.InspectionChecklistMoreInformations;
using Inspection.Domain.Models.InspectionManagement.InspectionMethods;
using Inspection.Domain.Models.InspectionManagement.InspectionTypes;
using Inspection.Domain.Models.SystemConfigurations.Companies;
using NDS.Shared.Domain.Contracts;
using NDS.Shared.Domain.Contracts.Multitenant;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inspection.Domain.Models.InspectionManagement.InspectionChecklists
{
    public class InspectionChecklist : ITenantEntity, IRootEntity
    {

        public long Id { get; set; }
        public string ChecklistNumber { get; set; }

        [ForeignKey("JobOrders")]
        public long JobOrderId { get; set; }
        public JobOrder JobOrders { get; set; }

        [ForeignKey("Customers")]
        public long? CustomerId { get; set; }
        public Customer Customers { get; set; }

        [ForeignKey("Companies")]
        public long? CompanyId { get; set; }
        public Company Companies { get; set; }

        [ForeignKey("EquipmentTypes")]
        public long? EquipmentTypeId { get; set; }
        public EquipmentType EquipmentTypes { get; set; }

        [ForeignKey("Equipments")]
        public long? EquipmentId { get; set; }
        public Equipment Equipments { get; set; }


        [ForeignKey("InspectionTypes")]
        public long? InspectionTypeId { get; set; }
        public InspectionType InspectionTypes { get; set; }

        [ForeignKey("CustomerLocations")]
        public long? LocationId { get; set; }
        public CustomerLocation CustomerLocations { get; set; }

        [ForeignKey("CustomerProjects")]
        public long? CustomerProjectId { get; set; }
        public CustomerProject CustomerProjects { get; set; }

        [ForeignKey("Inspectors")]
        public long? InspectorId { get; set; }
        public Inspector Inspectors { get; set; }

        [ForeignKey("InspectionMethods")]
        public long? InspectionMethodId { get; set; }
        public InspectionMethod InspectionMethods { get; set; }


        public DateTime? PreviousInspectionDate { get; set; }
        public DateTime? InspectionDate { get; set; }
        public DateTime ExpireDate { get; set; }
        public string? TimeSheetNo { get; set; }
        public string? StickerNo { get; set; }
        public string? RemarksAndRecommendations { get; set; }
        public InspectionCheckListStatus? Status { get; set; }
        public string? RefferenceStandard { get; set; }

        public ICollection<InspectionChecklistMoreInformation> InspectionChecklistMoreInformations { get; set; }
        public string? Series { get; set; }

        public string Tenant_ID { get; set; }

    }
}
