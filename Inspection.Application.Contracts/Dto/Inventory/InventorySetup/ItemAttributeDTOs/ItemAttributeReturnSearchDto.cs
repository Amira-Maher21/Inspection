using Inspection.Application.Contracts.Dto.Inventory.InventorySetup.ItemAttributeDTOs.ItemAttributeValueDTOs;

namespace Inspection.Application.Contracts.Dto.Inventory.InventorySetup.ItemAttributeDTOs
{
    public class ItemAttributeReturnSearchDto
    {
        public long Id { get; set; }
        public string Tenant_ID { get; set; } = string.Empty;
        public string AttributeName { get; set; } = string.Empty;

        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }
        public List<ItemAttributeValueDto> ItemAttributeValues { get; set; } = new List<ItemAttributeValueDto>();
    }
}
