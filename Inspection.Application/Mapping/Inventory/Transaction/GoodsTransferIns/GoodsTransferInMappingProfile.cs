using AutoMapper;
using Inspection.Application.Contracts.Dto.Inventory.Transaction.GoodsTransferInDTOs;
using Inspection.Application.Contracts.Dto.Inventory.Transaction.GoodsTransferInDTOs.GoodsTransferInLineDTOs;
using Inspection.Domain.Models.Inventory.Transaction.GoodsTransferIns;

namespace Inspection.Application.Mapping.Inventory.Transaction.GoodsTransferIns
{
    public class GoodsTransferInMappingProfile : Profile
    {
        public GoodsTransferInMappingProfile()
        {
            // -------------------- READ --------------------

            CreateMap<GoodsTransferIn, GoodsTransferInDto>();
            CreateMap<GoodsTransferInLine, GoodsTransferInLineDto>();

            // -------------------- CREATE --------------------

            CreateMap<GoodsTransferInCreateDto, GoodsTransferIn>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.GoodsTransferInLines, opt => opt.Ignore());

            CreateMap<GoodsTransferInLineCreateDto, GoodsTransferInLine>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.GoodsTransferIn, opt => opt.Ignore()); ;

            // -------------------- UPDATE --------------------

            CreateMap<GoodsTransferInUpdateDto, GoodsTransferIn>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.GoodsTransferInLines, opt => opt.Ignore());


            CreateMap<GoodsTransferInLineUpdateDto, GoodsTransferInLine>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.GoodsTransferIn, opt => opt.Ignore());
        }
    }
}