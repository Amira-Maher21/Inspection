namespace Inspection.Application.Contracts.Dto.EquipmentManagement.Equipments
{
    public class EquipmentDetailsDto
    {
        public long Id { get; set; }
        public string EquipmentNo { get; set; }
        public string Description { get; set; }

        public string? SerialNumber { get; set; }
        public string? Model { get; set; }
        public string? Manufacturer { get; set; }

        public DateTime? ManufactureDate { get; set; }
        public DateTime? NextInspectionDate { get; set; }

        public decimal? Capacity { get; set; }
        public decimal? PowerRating { get; set; }
        public decimal? Voltage { get; set; }
        public decimal? Pressure { get; set; }

        public string? Dimensions { get; set; }
        public decimal? Weight { get; set; }
        public string? Material { get; set; }
        public string? Notes { get; set; }

        public List<EquipmentsMoreInformationDto>? MoreInformations { get; set; }
    }
}
