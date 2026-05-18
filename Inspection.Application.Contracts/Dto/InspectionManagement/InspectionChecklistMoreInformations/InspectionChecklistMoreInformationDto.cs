using Inspection.Application.Contracts.Dto.InspectionManagement.InspectionChecklistMoreInformationDetails;

namespace Inspection.Application.Contracts.Dto.InspectionManagement.InspectionChecklists
{
    public class InspectionChecklistMoreInformationDto
    {
        public long Id { get; set; }

        public long EquipmentTypeId { get; set; }
        public long InspectionChecklistId { get; set; }


        public ICollection<InspectionChecklistMoreInformationDetailDto>? InspectionChecklistMoreInformationDetails { get; set; }
        public string Tenant_ID { get; set; }

    }
}
