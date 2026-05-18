using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Contracts.Dto.EquipmentManagement.EquipmentMaintenanceAndRepairRecords
{
    public class UpdateEquipmentMaintenanceAndRepairRecordDto
    {
        public long Id { get; set; }
        public long CompanyEquipmentId { get; set; }

        public string MaintenanceNo { get; set; }
        public DateTime Dte { get; set; }
        public string DescriptionOfWorkDone { get; set; }
        public string Results { get; set; }
        public string Tenant_ID { get; set; }

    }
}
