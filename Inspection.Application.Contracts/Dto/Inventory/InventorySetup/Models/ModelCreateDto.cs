namespace Inspection.Application.Contracts.Dto.Inventory.InventorySetup.Models
{
    public class ModelCreateDto
    {
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public long? BrandId { get; set; }


    }
}
