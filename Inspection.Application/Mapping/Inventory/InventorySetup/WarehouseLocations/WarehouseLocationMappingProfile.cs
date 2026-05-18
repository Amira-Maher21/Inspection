using AutoMapper;
using Inspection.Application.Contracts.Dto.Inventory.InventorySetup.WarehouseLocations;
using Inspection.Domain.Models.Inventory.InventorySetup.WarehouseLocations;

namespace Inspection.Application.Mapping.Inventory.InventorySetup.WarehouseLocations
{
    public class WarehouseLocationMappingProfile : Profile
    {

        public WarehouseLocationMappingProfile()
        {
            CreateMap<WarehouseLocation, WarehouseLocationDto>().ReverseMap();
            CreateMap<WarehouseLocationCreateDto, WarehouseLocation>().ReverseMap();
            CreateMap<WarehouseLocationUpdateDto, WarehouseLocation>().ReverseMap();
        }

    }
}
