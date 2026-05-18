using Inspection.Application.Contracts.Dto.EquipmentManagement.EquipmentsMoreInformationTemplateDetails;

namespace Inspection.Application.Contracts.Dto.EquipmentManagement.EquipmentsMoreInformationTemplates
{
    public class EquipmentsMoreInformationTemplateDtoByInclude
    {

        public long Id { get; set; }

        public string EquipmentTypeName { get; set; }

        public long EquipmentTypeId { get; set; }


        public ICollection<EquipmentsMoreInformationTemplateDetailDto>? EquipmentsMoreInformationTemplateDetails { get; set; }
        public string Tenant_ID { get; set; }

    }
}
