using AutoMapper;
using Inspection.Application.Contracts.Dto.Inventory.Transaction.InventoryAdjustmentDTOs;
using Inspection.Application.Contracts.Dto.Inventory.Transaction.InventoryAdjustmentDTOs.InventoryAdjustmentLineDTOs;
using Inspection.Domain.Models.Inventory.Transaction.InventoryAdjustments;

namespace Inspection.Application.Mapping.Inventory.Transaction.InventoryAdjustments
{
    public class InventoryAdjustmentMappingProfile : Profile
    {
        public InventoryAdjustmentMappingProfile()
        {
            // -------------------- READ --------------------

            CreateMap<InventoryAdjustment, InventoryAdjustmentDto>();
            CreateMap<InventoryAdjustmentLine, InventoryAdjustmentLineDto>();

            // -------------------- CREATE --------------------

            CreateMap<InventoryAdjustmentCreateDto, InventoryAdjustment>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.InventoryAdjustmentLines, opt => opt.Ignore());

            CreateMap<InventoryAdjustmentLineCreateDto, InventoryAdjustmentLine>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.InventoryAdjustment, opt => opt.Ignore()); ;

            // -------------------- UPDATE --------------------

            CreateMap<InventoryAdjustmentUpdateDto, InventoryAdjustment>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.InventoryAdjustmentLines, opt => opt.Ignore());


            CreateMap<InventoryAdjustmentLineUpdateDto, InventoryAdjustmentLine>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.InventoryAdjustment, opt => opt.Ignore());
        }
    }
}