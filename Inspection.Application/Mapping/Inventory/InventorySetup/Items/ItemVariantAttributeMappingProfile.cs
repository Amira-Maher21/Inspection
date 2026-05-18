using AutoMapper;
using Inspection.Application.Contracts.Dto.Inventory.InventorySetup.ItemDTOs.ItemVariantAttributeDTOs;
using Inspection.Domain.Models.Inventory.InventorySetup.Items;

namespace Inspection.Application.Mapping.Inventory.InventorySetup.Items
{
    public class ItemVariantAttributeMappingProfile : Profile
    {
        public ItemVariantAttributeMappingProfile()
        {
            // -------------------- READ --------------------

            CreateMap<ItemVariantAttribute, ItemVariantAttributeDto>();

            // -------------------- CREATE --------------------

            CreateMap<ItemVariantAttributeCreateDto, ItemVariantAttribute>()
                .ForMember(d => d.Id, opt => opt.Ignore());

            // -------------------- UPDATE --------------------

            //CreateMap<ItemUpdateDto, Item>()
            //    .ForMember(d => d.Id, opt => opt.Ignore())
            //    .ForMember(d => d.ItemReordersPerWarehouse, opt => opt.Ignore());

        }
    }
}