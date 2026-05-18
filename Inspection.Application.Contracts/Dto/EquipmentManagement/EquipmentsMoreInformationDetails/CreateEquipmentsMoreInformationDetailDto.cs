namespace Inspection.Application.Contracts.Dto.EquipmentManagement.EquipmentsMoreInformationDetails
{
    public class CreateEquipmentsMoreInformationDetailDto
    {

        public string KeyName { get; set; } = string.Empty;
        public string KeyValue { get; set; } = string.Empty;
        public long EquipmentsMoreInformationId { get; set; }

    }
}
