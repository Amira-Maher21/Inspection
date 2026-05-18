using AutoMapper;
using Inspection.Application.Contracts.Dto.Inventory.System.InventoryCostLayers;
using Inspection.Domain.Models.Inventory.System;

namespace Inspection.Application.Mapping.Inventory.System.InventoryCostLayers
{
    public class InventoryCostLayerMappingProfile : Profile
    {

        public InventoryCostLayerMappingProfile()
        {
            CreateMap<InventoryCostLayer, InventoryCostLayerCreateDto>().ReverseMap();
            CreateMap<InventoryCostLayer, InventoryCostLayerDto>().ReverseMap();
            CreateMap<InventoryCostLayerUpdateDto, InventoryCostLayer>().ReverseMap();
            CreateMap<InventoryCostLayerDto, InventoryCostLayer>().ReverseMap();
        }
    }
}