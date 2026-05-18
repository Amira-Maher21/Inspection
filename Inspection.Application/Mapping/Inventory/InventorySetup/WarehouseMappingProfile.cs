using AutoMapper;
using Inspection.Application.Contracts.Dto.Inventory.InventorySetup;
using Inspection.Domain.Models.Inventory.InventorySetup;

namespace Inspection.Application.Mapping.Inventory.InventorySetup
{
    public class WarehouseMappingProfile : Profile
    {
        public WarehouseMappingProfile()
        {
            CreateMap<Warehouse, WarehouseDto>().ReverseMap();

            CreateMap<WarehouseCreateDto, Warehouse>().ReverseMap();

            CreateMap<WarehouseUpdateDto, Warehouse>().ReverseMap();
        }
    }
}
