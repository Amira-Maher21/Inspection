namespace Inspection.Application.Contracts.Dto.EquipmentManagement.EquipmentsMoreInformationTemplates
{
    public class EquipmentsMoreInformationTemplateReturnSearchDto
    {
        public long Id { get; set; }
        public long EquipmentTypeId { get; set; }
        public string EquipmentTypeCode { get; set; }
        public string EquipmentTypeName { get; set; }
        public string Tenant_ID { get; set; }
    }
}
