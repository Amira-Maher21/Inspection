namespace Inspection.Application.Contracts.Dto.EquipmentManagement.EquipmentTypes
{
    public class CreateEquipmentTypeDto
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public long EquipmentCategoryId { get; set; }

    }
}
