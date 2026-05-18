using AutoMapper;
using Inspection.Application.Contracts.Dto.SalesManagment.sales.Transactions.SalesReturns;
using Inspection.Application.Contracts.Dto.SalesManagment.sales.Transactions.SalesReturns.SalesReturnAdjustments;
using Inspection.Application.Contracts.Dto.SalesManagment.sales.Transactions.SalesReturns.SalesReturnLines;
using Inspection.Domain.Models.SalesManagment.Transaction.SalesReturns;

namespace Inspection.Application.Mapping.SalesManagment.Transactions.SalesReturns
{
    public class SalesReturnMappingProfile : Profile
    {
        public SalesReturnMappingProfile()
        {
            // -------------------- READ --------------------

            CreateMap<SalesReturn, SalesReturnDto>();

            CreateMap<SalesReturnLine, SalesReturnLineDto>();

            CreateMap<SalesReturnAdjustment, SalesReturnAdjustmentDto>();


            // -------------------- CREATE --------------------

            CreateMap<SalesReturnCreateDto, SalesReturn>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.SalesReturnLines, opt => opt.Ignore())
                .ForMember(d => d.SalesReturnAdjustments, opt => opt.Ignore());

            CreateMap<SalesReturnLineCreateDto, SalesReturnLine>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.SalesReturn, opt => opt.Ignore());

            CreateMap<SalesReturnAdjustmentCreateDto, SalesReturnAdjustment>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.SalesReturn, opt => opt.Ignore());


            // -------------------- UPDATE --------------------

            CreateMap<SalesReturnUpdateDto, SalesReturn>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.SalesReturnLines, opt => opt.Ignore())
                .ForMember(d => d.SalesReturnAdjustments, opt => opt.Ignore());

            CreateMap<SalesReturnLineUpdateDto, SalesReturnLine>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.SalesReturn, opt => opt.Ignore());

            CreateMap<SalesReturnAdjustmentUpdateDto, SalesReturnAdjustment>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.SalesReturn, opt => opt.Ignore());
        }
    }
}