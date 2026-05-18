namespace Inspection.Application.Contracts.Dto.EquipmentManagement.EquipmentTypes
{
    public class EquipmentTypeDtoByInclude
    {
        public long Id { get; set; }
        public string Code { get; set; }

        public string Name { get; set; }
        public long EquipmentCategoryId { get; set; }
        public string EquipmentCategoryName { get; set; }


    }
}
