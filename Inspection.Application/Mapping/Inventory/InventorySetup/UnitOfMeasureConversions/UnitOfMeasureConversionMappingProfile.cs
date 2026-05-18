using AutoMapper;
using Inspection.Application.Contracts.Dto.Inventory.InventorySetup.UnitOfMeasureConversion;
using Inspection.Domain.Models.Inventory.InventorySetup.UnitOfMeasureConversions;

namespace Inspection.Application.Mapping.Inventory.InventorySetup.UnitOfMeasureConversions
{
    public class UnitOfMeasureConversionMappingProfile : Profile
    {
        public UnitOfMeasureConversionMappingProfile()
        {
            CreateMap<UnitOfMeasureConversion, UnitOfMeasureConversionDto>().ReverseMap();

            CreateMap<UnitOfMeasureConversionCreateDto, UnitOfMeasureConversion>().ReverseMap();

            CreateMap<UnitOfMeasureConversionUpdateDto, UnitOfMeasureConversion>().ReverseMap();
        }
    }
}
