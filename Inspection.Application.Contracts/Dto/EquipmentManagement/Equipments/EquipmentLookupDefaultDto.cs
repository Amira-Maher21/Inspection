namespace Inspection.Application.Contracts.Dto.EquipmentManagement.Equipments
{
    public class EquipmentLookupDefaultDto
    {
        public long Id { get; set; }
        public string Description { get; set; } = default!;
        public string? seriesEquipmentNo { get; set; }

    }

}
