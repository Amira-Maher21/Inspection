using AutoMapper;
using Inspection.Application.Contracts.Dto.Inventory.InventorySetup.Batchs;
using Inspection.Domain.Models.Inventory.InventorySetup.Batchs;

namespace Inspection.Application.Mapping.Inventory.InventorySetup.Batchs
{
    public class BatchMappingProfile : Profile
    {
        public BatchMappingProfile()
        {
            CreateMap<Batch, BatchDto>().ReverseMap();

            CreateMap<BatchCreateDto, Batch>().ReverseMap();

            CreateMap<BatchUpdateDto, Batch>().ReverseMap();
        }
    }
}
