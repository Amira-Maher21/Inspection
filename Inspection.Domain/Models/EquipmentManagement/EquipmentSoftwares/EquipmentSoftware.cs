using Inspection.Domain.Models.EquipmentManagement.CompanyEquipments;
using NDS.Shared.Domain.Contracts;
using NDS.Shared.Domain.Contracts.Multitenant;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inspection.Domain.Models.EquipmentManagement.EquipmentSoftwares
{
    [Table("EquipmentSoftware", Schema = "Inspection")]
    public class EquipmentSoftware : IRootEntity, ITenantEntity
    {
        public long Id { get; set; }
        [ForeignKey("CompanyEquipments")]
        public long CompanyEquipmentId { get; set; }
        public CompanyEquipment CompanyEquipments { get; set; }

        public string Description { get; set; } = string.Empty;
        public string Manufacturer { get; set; } = string.Empty;
        public string? Version { get; set; }
        public string? Notes { get; set; }
        public string Tenant_ID { get; set; } = string.Empty;
    }
}