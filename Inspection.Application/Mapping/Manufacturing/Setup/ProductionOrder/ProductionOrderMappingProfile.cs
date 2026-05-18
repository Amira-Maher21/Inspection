using AutoMapper;
using Inspection.Application.Contracts.Dto.Manufacturing.ContractingDTOs.Setup.CommitmentDTOs.CommitmentLineDTOs;
using Inspection.Application.Contracts.Dto.Manufacturing.Setup.ProductionOrderDTOs;
using Inspection.Application.Contracts.Dto.Manufacturing.Setup.ProductionOrderDTOs.ProductionOrderLineDTOs;
using Inspection.Domain.Models.Manufacturing.Setup.ProductionOrder;

namespace Inspection.Application.Mapping.Contracting.Setup.ProductionOrders
{
    public class ProductionOrderMappingProfile : Profile
    {
        public ProductionOrderMappingProfile()
        {
            // -------------------- READ --------------------

            CreateMap<ProductionOrder, ProductionOrderDto>();
            CreateMap<ProductionOrderLine, ProductionOrderLineDto>();

            // -------------------- CREATE --------------------

            CreateMap<ProductionOrderCreateDto, ProductionOrder>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.ProductionOrderLines, opt => opt.Ignore());

            CreateMap<ProductionOrderLineCreateDto, ProductionOrderLine>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.ProductionOrder, opt => opt.Ignore());

            // -------------------- UPDATE --------------------

            CreateMap<ProductionOrderUpdateDto, ProductionOrder>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.ProductionOrderLines, opt => opt.Ignore());

            CreateMap<ProductionOrderLineUpdateDto, ProductionOrderLine>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.ProductionOrder, opt => opt.Ignore());
        }
    }
}