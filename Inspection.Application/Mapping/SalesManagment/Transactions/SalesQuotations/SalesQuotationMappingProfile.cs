using AutoMapper;
using Inspection.Application.Contracts.Dto.SalesManagment.sales.Transactions.SalesQuotationDTOs;
using Inspection.Application.Contracts.Dto.SalesManagment.sales.Transactions.SalesQuotationDTOs.SalesQuotationLineDTOs;
using Inspection.Domain.Models.SalesManagment.Transaction.SalesQuotations;

namespace Inspection.Application.Mapping.SalesManagment.Transactions.SalesQuotations
{

    public class SalesQuotationMappingProfile : Profile
    {
        public SalesQuotationMappingProfile()
        {
            // -------------------- READ --------------------

            CreateMap<SalesQuotation, SalesQuotationDto>();
            CreateMap<SalesQuotationLine, SalesQuotationLineDto>();


            // -------------------- CREATE --------------------

            CreateMap<SalesQuotationCreateDto, SalesQuotation>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.SalesQuotationLines, opt => opt.Ignore());


            CreateMap<SalesQuotationLineCreateDto, SalesQuotationLine>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.SalesQuotation, opt => opt.Ignore());


            // -------------------- UPDATE --------------------

            CreateMap<SalesQuotationUpdateDto, SalesQuotation>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.SalesQuotationLines, opt => opt.Ignore());


            CreateMap<SalesQuotationLineUpdateDto, SalesQuotationLine>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.SalesQuotation, opt => opt.Ignore());
        }
    }
}