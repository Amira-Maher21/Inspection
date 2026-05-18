using AutoMapper;
using Inspection.Application.Contracts.Dto.Inventory.InventorySetup.Colors;
using Inspection.Domain.Models.Inventory.InventorySetup.Colors;

namespace Inspection.Application.Mapping.Inventory.Colors
{
    public class ColorMappingProfile : Profile
    {
        public ColorMappingProfile()
        {

            CreateMap<Color, ColorCreateDto>().ReverseMap();
            CreateMap<Color, ColorDto>().ReverseMap();
            CreateMap<ColorUpdateDto, Color>().ReverseMap();
            CreateMap<ColorDto, Color>().ReverseMap();
        }
    }
}
