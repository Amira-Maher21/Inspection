using System.ComponentModel.DataAnnotations;

namespace Inspection.Application.Contracts.Dto.EquipmentManagement.EquipmentsMoreInformationTemplateDetails
{
    public class EquipmentsMoreInformationTemplateDetailDtoLookUpForNames
    {
        [Key]
        public long Id { get; set; }
        public string KeyName { get; set; }
        public string KeyValue { get; set; }


    }
}
