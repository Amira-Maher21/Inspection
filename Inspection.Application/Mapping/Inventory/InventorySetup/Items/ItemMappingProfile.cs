using AutoMapper;
using Inspection.Application.Contracts.Dto.Inventory.InventorySetup.ItemDTOs;
using Inspection.Application.Contracts.Dto.Inventory.InventorySetup.ItemDTOs.ItemReorderPerWarehouseDTOs;
using Inspection.Application.Contracts.Dto.Inventory.InventorySetup.ItemDTOs.ItemVariantAttributeDTOs;
using Inspection.Domain.Models.Inventory.InventorySetup.Items;

namespace Inspection.Application.Mapping.Inventory.InventorySetup.Items
{
    public class ItemMappingProfile : Profile
    {
        public ItemMappingProfile()
        {
            // -------------------- READ --------------------

            CreateMap<Item, ItemDto>();
            CreateMap<ItemReorderPerWarehouse, ItemReorderPerWarehouseDto>();
            CreateMap<ItemVariantAttribute, ItemVariantAttributeDto>();
            CreateMap<ItemVariantAttribute, ItemVariantAttributeDto>()
                .ForMember(dest => dest.Code, opt => opt.Ignore())
                .ForMember(dest => dest.Name, opt => opt.Ignore())
                .ForMember(dest => dest.SKU, opt => opt.Ignore())
                //.ForMember(dest => dest.ItemGroup, opt => opt.Ignore())
                .ForMember(dest => dest.UnitPrice, opt => opt.Ignore())
                .ForMember(dest => dest.AttributeValueIds,
                    opt => opt.MapFrom(src => new List<long> { src.ItemAttributeValueId }));

            // -------------------- CREATE --------------------

            CreateMap<ItemCreateDto, Item>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.ItemReordersPerWarehouse, opt => opt.Ignore());

            CreateMap<ItemReorderPerWarehouseCreateDto, ItemReorderPerWarehouse>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.Item, opt => opt.Ignore());

            // -------------------- UPDATE --------------------

            CreateMap<ItemUpdateDto, Item>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.ItemReordersPerWarehouse, opt => opt.Ignore());

            CreateMap<ItemReorderPerWarehouseUpdateDto, ItemReorderPerWarehouse>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.Item, opt => opt.Ignore());
        }
    }
}