using Inspection.Domain.Models.EquipmentManagement.EquipmentsMoreInfo;
using NDS.Shared.Domain.Contracts;
using NDS.Shared.Domain.Contracts.Multitenant;

namespace Inspection.Domain.Models.EquipmentManagement.EquipmentsMoreInformationDetails
{
    public class EquipmentsMoreInformationDetail : ITenantEntity, IRootEntity
    {
        public long Id { get; set; }
        public string Tenant_ID { get; set; } = string.Empty;
        public string KeyName { get; set; } = string.Empty;
        public string KeyValue { get; set; } = string.Empty;

        public long EquipmentsMoreInformationId { get; set; }
        public EquipmentsMoreInformation EquipmentsMoreInformations { get; set; } = null!;
    }
}