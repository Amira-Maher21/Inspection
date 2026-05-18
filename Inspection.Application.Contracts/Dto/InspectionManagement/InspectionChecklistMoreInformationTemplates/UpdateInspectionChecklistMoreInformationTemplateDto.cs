using Inspection.Application.Contracts.Dto.InspectionManagement.InspectionChecklistMoreInformationTemplateDetails;

namespace Inspection.Application.Contracts.Dto.InspectionManagement.InspectionChecklistMoreInformationTemplates
{
    public class UpdateInspectionChecklistMoreInformationTemplateDto
    {
        public long Id { get; set; }



        public long EquipmentTypeId { get; set; }



        public ICollection<InspectionChecklistMoreInformationTemplateDetailDto>? InspectionChecklistMoreInformationTemplateDetails { get; set; }
        public string Tenant_ID { get; set; }
    }
}
