using Inspection.Application.Contracts.Dto.EquipmentManagement.EquipmentsMoreInformationDetails;

namespace Inspection.Application.Contracts.Dto.EquipmentManagement.EquipmentsMoreInformations
{
    public class EquipmentsMoreInformationIncludeDto
    {
        public long Id { get; set; }

        public string EquipmentTypeName { get; set; }

        public long EquipmentTypeId { get; set; }

        public long EquipmentId { get; set; }

        public ICollection<EquipmentsMoreInformationDetailDto>? EquipmentsMoreInformationDetails { get; set; }
        public string Tenant_ID { get; set; }

    }
}
