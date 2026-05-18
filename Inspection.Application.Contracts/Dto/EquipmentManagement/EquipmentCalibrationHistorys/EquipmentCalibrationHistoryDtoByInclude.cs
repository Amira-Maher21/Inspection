using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Contracts.Dto.EquipmentManagement.EquipmentCalibrationHistorys
{
    public class EquipmentCalibrationHistoryDtoByInclude
    {
        public long Id { get; set; }
        public long CompanyEquipmentId { get; set; }

        public string? Note { get; set; }

        public string CertificateNo { get; set; }
        public string? CalibrationBody { get; set; }
        public DateTime? CalDate { get; set; }

        public DateTime? ExpiryDate { get; set; }

        public string Tenant_ID { get; set; }
    }
}
