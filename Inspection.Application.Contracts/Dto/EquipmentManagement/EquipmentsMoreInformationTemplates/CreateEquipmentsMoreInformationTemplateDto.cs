using Inspection.Application.Contracts.Dto.EquipmentManagement.EquipmentsMoreInformationTemplateDetails;

namespace Inspection.Application.Contracts.Dto.EquipmentManagement.EquipmentsMoreInformationTemplates
{
    public class CreateEquipmentsMoreInformationTemplateDto
    {



        public long EquipmentTypeId { get; set; }



        //public string series { get; set; }
        public ICollection<EquipmentsMoreInformationTemplateDetailDto>? EquipmentsMoreInformationTemplateDetails { get; set; }
        public string Tenant_ID { get; set; }
    }
}
