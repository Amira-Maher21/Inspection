namespace Inspection.Application.Contracts.Dto.EquipmentManagement.Equipments
{
    public class EquipmentsMoreInformationDto
    {
        public long Id { get; private set; }
        //public string Tenant_ID { get; set; } = string.Empty;
        public string KeyName { get; private set; } = string.Empty;
        public string KeyValue { get; set; } = string.Empty;

    }
}
