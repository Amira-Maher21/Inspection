using AutoMapper;
using Inspection.Application.Contracts.Dto.Inventory.InventorySetup.ItemAttributeDTOs;
using Inspection.Application.Contracts.Dto.Inventory.InventorySetup.ItemAttributeDTOs.ItemAttributeValueDTOs;
using Inspection.Domain.Models.Inventory.InventorySetup.ItemAttribute;

namespace Inspection.Application.Mapping.Inventory.ItemAttributes
{
    public class ItemAttributeMappingProfile : Profile
    {
        public ItemAttributeMappingProfile()
        {
            // -------------------- READ --------------------

            CreateMap<ItemAttribute, ItemAttributeDto>();
            CreateMap<ItemAttributeValue, ItemAttributeValueDto>();

            // -------------------- CREATE --------------------

            CreateMap<ItemAttributeCreateDto, ItemAttribute>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.ItemAttributeValues, opt => opt.Ignore());

            CreateMap<ItemAttributeValueCreateDto, ItemAttributeValue>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.ItemAttribute, opt => opt.Ignore());

            // -------------------- UPDATE --------------------

            CreateMap<ItemAttributeUpdateDto, ItemAttribute>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.ItemAttributeValues, opt => opt.Ignore());

            CreateMap<ItemAttributeValueUpdateDto, ItemAttributeValue>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.ItemAttribute, opt => opt.Ignore());
        }
    }
}