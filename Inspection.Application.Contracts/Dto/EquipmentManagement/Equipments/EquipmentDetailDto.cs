namespace Inspection.Application.Contracts.Dto.EquipmentManagement.Equipments
{
    public class EquipmentDetailDto
    {
        public long Id { get; set; }
        public string KeyName { get; set; } = string.Empty;
        public string KeyValue { get; set; } = string.Empty;
    }
}
