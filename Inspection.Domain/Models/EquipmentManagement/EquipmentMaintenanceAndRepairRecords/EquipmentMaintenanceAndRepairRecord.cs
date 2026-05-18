using Inspection.Domain.Models.EquipmentManagement.CompanyEquipments;
using NDS.Shared.Domain.Contracts;
using NDS.Shared.Domain.Contracts.Multitenant;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inspection.Domain.Models.EquipmentManagement.EquipmentMaintenanceAndRepairRecords
{
    [Table("EquipmentMaintenanceAndRepairRecord", Schema = "Inspection")]

    public class EquipmentMaintenanceAndRepairRecord : ITenantEntity, IRootEntity
    {
        public long Id { get; set; }

        [ForeignKey("CompanyEquipments")]
        public long CompanyEquipmentId { get; set; }
        public CompanyEquipment CompanyEquipments { get; set; }

        public string MaintenanceNo { get; set; } = string.Empty;
        public DateTime Dte { get; set; }
        public string DescriptionOfWorkDone { get; set; } = string.Empty;
        public string Results { get; set; } = string.Empty;
        public string Tenant_ID { get; set; } = string.Empty;
    }
}