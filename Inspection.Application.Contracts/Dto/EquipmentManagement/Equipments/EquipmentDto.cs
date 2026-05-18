namespace Inspection.Application.Contracts.Dto.EquipmentManagement.Equipments
{
    public class EquipmentDto
    {
        public long Id { get; set; }
        public long CompanyId { get; set; }
        public string EquipmentNo { get; set; }
        public string Description { get; set; }


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


        //public ICollection<EquipmentsMoreInformationDetailDto>? EquipmentsMoreInformationDetailDto { get; set; }



        public long SeriesId { get; set; }
        public int RunningNumber { get; set; }


        public string Tenant_ID { get; set; } = string.Empty;
        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }

    }

}
