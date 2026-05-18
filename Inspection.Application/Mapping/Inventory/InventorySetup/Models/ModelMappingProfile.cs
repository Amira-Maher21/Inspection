using AutoMapper;
using Inspection.Application.Contracts.Dto.Inventory.InventorySetup.Models;
using Inspection.Domain.Models.Inventory.InventorySetup.Models;

namespace Inspection.Application.Mapping.Inventory.InventorySetup.Models
{
    public class ModelMappingProfile : Profile
    {
        public ModelMappingProfile()
        {
            CreateMap<Model, ModelDto>().ReverseMap();

            CreateMap<ModelCreateDto, Model>().ReverseMap();

            CreateMap<ModelUpdateDto, Model>().ReverseMap();
        }
    }
}