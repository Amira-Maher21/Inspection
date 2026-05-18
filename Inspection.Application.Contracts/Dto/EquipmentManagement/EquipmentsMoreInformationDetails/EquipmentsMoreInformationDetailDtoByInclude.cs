using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Contracts.Dto.EquipmentManagement.EquipmentsMoreInformationDetails
{
    public class EquipmentsMoreInformationDetailDtoByInclude
    {
        public long Id { get; set; }
        public string KeyName { get; set; } = string.Empty;
        public string KeyValue { get; set; } = string.Empty;

        public long EquipmentsMoreInformationId { get; set; }
        public string Tenant_ID { get; set; }


    }
}
