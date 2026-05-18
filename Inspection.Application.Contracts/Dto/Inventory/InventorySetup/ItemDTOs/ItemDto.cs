using Inspection.Application.Contracts.Dto.Inventory.InventorySetup.ItemDTOs.ItemReorderPerWarehouseDTOs;
using Inspection.Application.Contracts.Dto.Inventory.InventorySetup.ItemDTOs.ItemVariantAttributeDTOs;
using Inspection.Domain.Enums.InventoryEnums;

namespace Inspection.Application.Contracts.Dto.Inventory.InventorySetup.ItemDTOs
{
    public class ItemDto
    {
        public long Id { get; set; }
        public string Tenant_ID { get; set; } = string.Empty;
        public long CompanyId { get; set; }
        public string Code { get; set; } = string.Empty;
        public string? SKU { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? BarCode { get; set; }
        public long ItemGroupId { get; set; }
        public ItemType ItemType { get; set; }
        public long? UnitOfMeasureId { get; set; }
        public bool IsStocked { get; set; }
        public bool IsSerialTracked { get; set; }
        public bool IsBatchTracked { get; set; }
        public bool IsExpiryTracked { get; set; }
        public long? DefaultWarehouseId { get; set; }
        public long? DefaultSupplierId { get; set; }
        public decimal? ReorderLevel { get; set; }
        public decimal? ReorderQuantity { get; set; }
        public decimal? SafetyStock { get; set; }
        public long? LeadTime { get; set; }
        public bool? Sale { get; set; } = true;
        public bool? IncludeInPOS { get; set; } = false;
        public bool? IncludeInOnline { get; set; } = false;
        public ETAItemType? ETAItemType { get; set; }
        public string? ETAItemCode { get; set; }
        public decimal? Weight { get; set; }
        public decimal? Volume { get; set; }
        public decimal? Calories { get; set; }
        public decimal? UnitPrice { get; set; }
        public decimal? UnitCost { get; set; }
        public long? ItemPhotoId { get; set; }
        public long? BrandId { get; set; }
        public long? ModelId { get; set; }
        public long? ColorId { get; set; }
        public long? SizeId { get; set; }
        public bool? HasVariant { get; set; }
        public long? RelatedItemVariantId { get; set; }
        public bool Disabled { get; set; } = false;

        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }

        // series related
        public long? SeriesId { get; set; }
        public int RunningNumber { get; set; }

        public List<ItemReorderPerWarehouseDto> ItemReordersPerWarehouse { get; set; } = new List<ItemReorderPerWarehouseDto>();
        public List<ItemVariantAttributeDto> Variants { get; set; } = new();
    }
}