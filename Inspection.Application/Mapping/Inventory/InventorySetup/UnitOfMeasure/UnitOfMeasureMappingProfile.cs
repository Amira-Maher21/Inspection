using AutoMapper;
using Inspection.Application.Contracts.Dto.Inventory.InventorySetup.UnitOfMeasure;

namespace Inspection.Application.Mapping.Inventory.InventorySetup.UnitOfMeasure
{
    public class UnitOfMeasureMappingProfile : Profile
    {
        public UnitOfMeasureMappingProfile()
        {
            CreateMap<Domain.Models.Inventory.InventorySetup.UnitOfMeasure, UnitOfMeasureDto>().ReverseMap();

            CreateMap<UnitOfMeasureCreateDto, Domain.Models.Inventory.InventorySetup.UnitOfMeasure>().ReverseMap();

            CreateMap<UnitOfMeasureUpdateDto, Domain.Models.Inventory.InventorySetup.UnitOfMeasure>().ReverseMap();
        }
    }
}
