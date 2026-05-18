using Inspection.Application.Contracts.Dto.EquipmentManagement.EquipmentsMoreInformationTemplateDetails;
using System.ComponentModel.DataAnnotations;

namespace Inspection.Application.Contracts.Dto.EquipmentManagement.EquipmentsMoreInformationTemplates
{
    public class EquipmentsMoreInformationTemplateDto
    {
        [Key]
        public long Id { get; set; }



        public long EquipmentTypeId { get; set; }



        //public string series { get; set; }
        public ICollection<EquipmentsMoreInformationTemplateDetailDto>? EquipmentsMoreInformationTemplateDetails { get; set; }
        public string Tenant_ID { get; set; }

    }
}
