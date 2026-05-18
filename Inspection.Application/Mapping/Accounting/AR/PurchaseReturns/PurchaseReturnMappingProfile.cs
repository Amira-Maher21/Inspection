using AutoMapper;
using Inspection.Application.Contracts.Dto.AccountingDtos.AR.PurchaseReturns;
using Inspection.Application.Contracts.Dto.AccountingDtos.AR.PurchaseReturns.PurchaseReturnAdjustments;
using Inspection.Application.Contracts.Dto.AccountingDtos.AR.PurchaseReturns.PurchaseReturnLines;
using Inspection.Domain.Models.Accounting.AR.PurchaseReturns;
using Inspection.Domain.Models.Accounting.AR.PurchaseReturns.PurchaseReturnAdjustments;
using Inspection.Domain.Models.Accounting.AR.PurchaseReturns.PurchaseReturnLines;

namespace Inspection.Application.Mapping.Accounting.AR.PurchaseReturns
{
    public class PurchaseReturnMappingProfile : Profile
    {
        public PurchaseReturnMappingProfile()
        {

            // READ

            CreateMap<PurchaseReturn, PurchaseReturnDto>();
            CreateMap<PurchaseReturnLine, PurchaseReturnLineDto>();
            CreateMap<PurchaseReturnAdjustment, PurchaseReturnAdjustmentDto>();


            // CREATE

            CreateMap<PurchaseReturnCreateDto, PurchaseReturn>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.PurchaseReturnLines, opt => opt.Ignore())
                .ForMember(d => d.PurchaseReturnAdjustments, opt => opt.Ignore());

            CreateMap<PurchaseReturnLineCreateDto, PurchaseReturnLine>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.PurchaseReturn, opt => opt.Ignore());

            CreateMap<PurchaseReturnAdjustmentCreateDto, PurchaseReturnAdjustment>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.PurchaseReturn, opt => opt.Ignore());


            // UPDATE

            CreateMap<PurchaseReturnUpdateDto, PurchaseReturn>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.PurchaseReturnLines, opt => opt.Ignore())
                .ForMember(d => d.PurchaseReturnAdjustments, opt => opt.Ignore());

            CreateMap<PurchaseReturnLineUpdateDto, PurchaseReturnLine>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.PurchaseReturn, opt => opt.Ignore());

            CreateMap<PurchaseReturnAdjustmentUpdateDto, PurchaseReturnAdjustment>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.PurchaseReturn, opt => opt.Ignore());
        }
    }
}