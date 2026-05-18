using Inspection.Domain.Models.EquipmentManagement.CompanyEquipments;
using NDS.Shared.Domain.Contracts;
using NDS.Shared.Domain.Contracts.Multitenant;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inspection.Domain.Models.EquipmentManagement.EquipmentPreventiveMaintenances
{
    [Table("EquipmentPreventiveMaintenance", Schema = "Inspection")]
    public class EquipmentPreventiveMaintenance : IRootEntity, ITenantEntity
    {
        public long Id { get; set; }

        [ForeignKey("CompanyEquipments")]
        public long CompanyEquipmentId { get; set; }
        public CompanyEquipment CompanyEquipments { get; set; }

        public string Action { get; set; } = string.Empty;
        public string? Frequency { get; set; }
        public DateTime? Dte { get; set; }
        public string PerformedBy { get; set; } = string.Empty;
        public string? Note { get; set; }
        public string Tenant_ID { get; set; } = string.Empty;
    }
}