namespace Inspection.Application.Contracts.Dto.EquipmentManagement.Equipments
{
    public class UpdateEquipmentDto
    {

        public long Id { get; set; }
        public long CompanyId { get; set; }
        public string EquipmentNo { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public long EquipmentTypeId { get; set; }

        public long CustomerId { get; set; }

        public long? CustomerProjectId { get; set; }

        public long CustomerLocationId { get; set; }

        public string? SerialNumber { get; set; }
        public string? Model { get; set; }
        public string? Manufacturer { get; set; }

        public DateTime? ManufactureDate { get; set; }
        public DateTime? OperationStartDate { get; set; }
        public DateTime? InstallationDate { get; set; }
        public DateTime? LastInspectionDate { get; set; }
        public DateTime? NextInspectionDate { get; set; }

        public decimal? Capacity { get; set; }
        public decimal? PowerRating { get; set; }
        public decimal? Voltage { get; set; }
        public decimal? Pressure { get; set; }
        public string? Dimensions { get; set; }
        public decimal? Weight { get; set; }
        public string? Material { get; set; }
        public string? Notes { get; set; }

        //public ICollection<UpdateEquipmentsMoreInformationDetailDto> UpdateEquipmentsMoreInformationDetailDto { get; set; }

    }
}
