using Inspection.Domain.Enums.InventoryEnums;
using Inspection.Domain.Models.Accounting.PR.MasterData.Suppliers;
using Inspection.Domain.Models.DMS.Documents;
using Inspection.Domain.Models.Inventory.InventorySetup.Brands;
using Inspection.Domain.Models.Inventory.InventorySetup.Colors;
using Inspection.Domain.Models.Inventory.InventorySetup.Models;
using Inspection.Domain.Models.Inventory.InventorySetup.Sizes;
using Inspection.Domain.Models.Inventory.ItemGroups;
using Inspection.Domain.Models.MenuManagement;
using NDS.Shared.Domain.Contracts;
using NDS.Shared.Domain.Contracts.EntityCommonData;
using NDS.Shared.Domain.Contracts.Multitenant;

namespace Inspection.Domain.Models.Inventory.InventorySetup.Items
{
    public class Item : IRootEntity, ITenantEntity, IAuditable
    {
        public long Id { get; private set; }
        public string Tenant_ID { get; set; } = string.Empty;
        public long CompanyId { get; set; }

        // Basic Information
        public string Code { get; set; } = string.Empty;
        public string? SKU { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? BarCode { get; set; }

        // Classification 
        public long ItemGroupId { get; set; }
        public ItemGroup ItemGroup { get; set; } = null!;
        public ItemType ItemType { get; set; }
        public long? UnitOfMeasureId { get; set; }
        public UnitOfMeasure? UnitOfMeasure { get; private set; }

        // Inventory Flags
        public bool IsStocked { get; set; }
        public bool IsSerialTracked { get; set; }
        public bool IsBatchTracked { get; set; }
        public bool IsExpiryTracked { get; set; }


        // Warehouse
        public long? DefaultWarehouseId { get; set; }
        public Warehouse? DefaultWarehouse { get; private set; }

        // Supplier
        public long? DefaultSupplierId { get; set; }
        public Supplier? Supplier { get; private set; }

        // Stock Control
        public decimal? ReorderLevel { get; set; }
        public decimal? ReorderQuantity { get; set; }
        public decimal? SafetyStock { get; set; }
        public long? LeadTime { get; set; }

        // Sales Options
        public bool? Sale { get; set; } = true;
        public bool? IncludeInPOS { get; private set; } = false;
        public bool? IncludeInOnline { get; private set; } = false;

        // ETA (Egyptian Tax Authority)
        public ETAItemType? ETAItemType { get; private set; }
        public string? ETAItemCode { get; private set; }

        // Physical Attributes
        public decimal? Weight { get; private set; }
        public decimal? Volume { get; private set; }
        public decimal? Calories { get; private set; }

        // Pricing 
        public decimal? UnitPrice { get; set; }
        public decimal? UnitCost { get; set; }

        // Media
        public long? ItemPhotoId { get; private set; }
        public Document? Document { get; private set; }

        // Attributes
        public long? BrandId { get; private set; }
        public Brand? Brand { get; private set; }
        public long? ModelId { get; private set; }
        public Model? Model { get; private set; }
        public long? ColorId { get; private set; }
        public Color? Color { get; private set; }
        public long? SizeId { get; private set; }
        public Size? Size { get; private set; }

        // Variants 
        public bool? HasVariant { get; set; }
        public long? RelatedItemVariantId { get; set; }
        public Item? RelatedItemVariant { get; private set; }

        // Status 
        public bool Disabled { get; private set; } = false;

        // ItemReorder
        public List<ItemReorderPerWarehouse> ItemReordersPerWarehouse { get; set; } = null!;

        // Variant
        public List<ItemVariantAttribute> VariantAttributes { get; set; } = null!;

        // series related
        public Series Series { get; set; } = null!;
        public long? SeriesId { get; set; }
        public int RunningNumber { get; set; }

        // Audit 
        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }
    }
}