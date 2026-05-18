using AutoMapper;
using Inspection.Application.Contracts.Dto.Inventory.InventorySetup.Sizes;
using Inspection.Domain.Models.Inventory.InventorySetup.Sizes;

namespace Inspection.Application.Mapping.Inventory.Sizes
{
    public class SizeMappingProfile : Profile
    {
        public SizeMappingProfile()
        {
            CreateMap<Size, SizeCreateDto>().ReverseMap();
            CreateMap<Size, SizeDto>().ReverseMap();
            CreateMap<SizeUpdateDto, Size>().ReverseMap();
            CreateMap<SizeDto, Size>().ReverseMap();
        }
    }
}
