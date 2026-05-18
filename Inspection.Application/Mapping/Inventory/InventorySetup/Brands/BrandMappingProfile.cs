using AutoMapper;
using Inspection.Application.Contracts.Dto.Inventory.InventorySetup.Brands;
using Inspection.Domain.Models.Inventory.InventorySetup.Brands;

namespace Inspection.Application.Mapping.Inventory.InventorySetup.Brands
{
    public class BrandMappingProfile : Profile
    {
        public BrandMappingProfile()
        {
            CreateMap<Brand, BrandDto>().ReverseMap();

            CreateMap<BrandCreateDto, Brand>().ReverseMap();

            CreateMap<BrandUpdateDto, Brand>().ReverseMap();
        }
    }
}
