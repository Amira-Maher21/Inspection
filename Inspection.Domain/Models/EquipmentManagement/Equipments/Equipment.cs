using Inspection.Domain.Models.Accounting.AR.MasterData;
using Inspection.Domain.Models.EquipmentManagement.EquipmentsMoreInformationDetails;
using Inspection.Domain.Models.EquipmentManagement.EquipmentTypes;
using Inspection.Domain.Models.InspectionManagement.CustomerLocations;
using Inspection.Domain.Models.InspectionManagement.CustomerProjects;
using Inspection.Domain.Models.MenuManagement;
using NDS.Shared.Domain.Contracts;
using NDS.Shared.Domain.Contracts.EntityCommonData;
using NDS.Shared.Domain.Contracts.Multitenant;

namespace Inspection.Domain.Models.EquipmentManagement.Equipments
{
    public class Equipment : IRootEntity, ITenantEntity, IAuditable
    {
        public long Id { get; set; }
        public long CompanyId { get; set; }
        public string EquipmentNo { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        // ================= Relations =================

        public long EquipmentTypeId { get; set; }
        public EquipmentType EquipmentType { get; set; } = null!;

        public long CustomerId { get; set; }
        public Customer Customer { get; set; } = null!;

        public long? CustomerProjectId { get; set; }
        public CustomerProject? CustomerProject { get; set; }

        public long CustomerLocationId { get; set; }
        public CustomerLocation CustomerLocation { get; set; } = null!;

        // ================= Technical Data =================

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


        public ICollection<EquipmentsMoreInformationDetail>? EquipmentsMoreInformationDetail { get; set; }


        // ================= Series =================

        public long SeriesId { get; set; }
        public Series? Series { get; set; }
        public int RunningNumber { get; set; }

        // ================= Tenant & Audit =================

        public string Tenant_ID { get; set; } = string.Empty;
        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }
    }
}