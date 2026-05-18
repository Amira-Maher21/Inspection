namespace Inspection.Application.Contracts.Dto.EquipmentManagement.EquipmentsMoreInformationTemplateDetails
{
    public class CreateEquipmentsMoreInformationTemplateDetailDto
    {

        public string KeyName { get; set; }
        public string KeyValue { get; set; }

        public long EquipmentsMoreInformationTemplateId { get; set; }

        public string Tenant_ID { get; set; }
    }
}
