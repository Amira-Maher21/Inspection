using AutoMapper;
using Inspection.Application.Contracts.Dto.Inventory.Transaction.GoodsTransferOutDTOs;
using Inspection.Application.Contracts.Dto.Inventory.Transaction.GoodsTransferOutDTOs.GoodsTransferOutLineDTOs;
using Inspection.Domain.Models.Inventory.Transaction.GoodsTransferOuts;

namespace Inspection.Application.Mapping.Inventory.Transaction.GoodsTransferOuts
{
    public class GoodsTransferOutMappingProfile : Profile
    {
        public GoodsTransferOutMappingProfile()
        {
            // -------------------- READ --------------------

            CreateMap<GoodsTransferOut, GoodsTransferOutDto>();
            CreateMap<GoodsTransferOutLine, GoodsTransferOutLineDto>();

            // -------------------- CREATE --------------------

            CreateMap<GoodsTransferOutCreateDto, GoodsTransferOut>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.GoodsTransferOutLines, opt => opt.Ignore());

            CreateMap<GoodsTransferOutLineCreateDto, GoodsTransferOutLine>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.GoodsTransferOut, opt => opt.Ignore()); ;

            // -------------------- UPDATE --------------------

            CreateMap<GoodsTransferOutUpdateDto, GoodsTransferOut>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.GoodsTransferOutLines, opt => opt.Ignore());


            CreateMap<GoodsTransferOutLineUpdateDto, GoodsTransferOutLine>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.GoodsTransferOut, opt => opt.Ignore());
        }
    }
}