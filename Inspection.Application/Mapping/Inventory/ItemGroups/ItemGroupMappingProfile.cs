using AutoMapper;
using Inspection.Application.Contracts.Dto.Inventory.ItemGroupS;
using Inspection.Domain.Models.Inventory.ItemGroups;

namespace Inspection.Application.Mapping.Inventory.ItemGroups
{
    public class ItemGroupMappingProfile : Profile
    {
        public ItemGroupMappingProfile()
        {
            CreateMap<ItemGroupCreateDto, ItemGroup>().ReverseMap();
            CreateMap<ItemGroupUpdateDto, ItemGroup>().ReverseMap();
            CreateMap<ItemGroup, ItemGroupDto>().ReverseMap();
        }
    }
}