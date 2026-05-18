namespace Inspection.Application.Contracts.Dto.EquipmentManagement.Equipments
{
    public class EquipmentWithDetailsDto
    {
        public long Id { get; set; }
        public string EquipmentNo { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public List<EquipmentDetailDto>? Details { get; set; }
    }
}
