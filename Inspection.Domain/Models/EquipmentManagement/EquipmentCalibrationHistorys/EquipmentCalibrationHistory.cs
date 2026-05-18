using Inspection.Domain.Models.EquipmentManagement.CompanyEquipments;
using NDS.Shared.Domain.Contracts;
using NDS.Shared.Domain.Contracts.Multitenant;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inspection.Domain.Models.EquipmentManagement.EquipmentCalibrationHistorys
{
    [Table("EquipmentCalibrationHistory", Schema = "Inspection")]
    public class EquipmentCalibrationHistory : IRootEntity, ITenantEntity
    {
        public long Id { get; set; }
        [ForeignKey("CompanyEquipments")]
        public long CompanyEquipmentId { get; set; }
        public CompanyEquipment CompanyEquipments { get; set; }
        public string? Note { get; set; }

        public string CertificateNo { get; set; } = string.Empty;
        public string? CalibrationBody { get; set; }
        public DateTime? CalDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public string Tenant_ID { get; set; } = string.Empty;
    }
}