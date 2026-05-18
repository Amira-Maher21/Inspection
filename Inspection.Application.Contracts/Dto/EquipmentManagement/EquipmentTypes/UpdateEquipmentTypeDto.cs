namespace Inspection.Application.Contracts.Dto.EquipmentManagement.EquipmentTypes
{
    public class UpdateEquipmentTypeDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }

        public long EquipmentCategoryId { get; set; }

    }
}
