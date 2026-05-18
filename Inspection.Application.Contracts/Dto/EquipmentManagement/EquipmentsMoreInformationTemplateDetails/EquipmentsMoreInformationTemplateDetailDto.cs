using System.ComponentModel.DataAnnotations;

namespace Inspection.Application.Contracts.Dto.EquipmentManagement.EquipmentsMoreInformationTemplateDetails
{
    public class EquipmentsMoreInformationTemplateDetailDto
    {
        [Key]
        public long Id { get; set; }
        public string KeyName { get; set; }
        public string KeyValue { get; set; }

        public long EquipmentsMoreInformationTemplateId { get; set; }

        public string Tenant_ID { get; set; }
    }
}
