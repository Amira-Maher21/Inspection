using AutoMapper;
using Inspection.Application.Contracts.Dto.Inventory.Transaction.GoodsReceipts;
using Inspection.Application.Contracts.Dto.Inventory.Transaction.GoodsReceipts.GoodsReceiptLines;
using Inspection.Domain.Models.Inventory.Transaction.GoodsReceipts;
using Inspection.Domain.Models.Inventory.Transaction.GoodsReceipts.GoodsReceiptLines;

namespace Inspection.Application.Mapping.Inventory.Transaction.GoodsReceipts
{
    public class GoodsReceiptMappingProfile : Profile
    {
        public GoodsReceiptMappingProfile()
        {

            CreateMap<GoodsReceipt, GoodsReceiptDto>();
            CreateMap<GoodsReceiptLine, GoodsReceiptLineDto>();



            CreateMap<GoodsReceiptCreateDto, GoodsReceipt>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.GoodsReceiptLines, opt => opt.Ignore());

            CreateMap<GoodsReceiptLineCreateDto, GoodsReceiptLine>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.GoodsReceipt, opt => opt.Ignore());



            CreateMap<GoodsReceiptUpdateDto, GoodsReceipt>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.GoodsReceiptLines, opt => opt.Ignore());

            CreateMap<GoodsReceiptLineUpdateDto, GoodsReceiptLine>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.GoodsReceipt, opt => opt.Ignore());
        }
    }
}
