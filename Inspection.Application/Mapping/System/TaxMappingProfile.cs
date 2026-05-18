using AutoMapper;
using Inspection.Application.Contracts.Dto.SystemDto.Taxs;
using Inspection.Application.Contracts.Dto.SystemDto.TaxTypeLine;
using Inspection.Domain.Models.System;
using Inspection.Domain.Models.System.Taxes;

namespace Inspection.Application.Mapping.System
{
    public class TaxMappingProfile : Profile
    {
        public TaxMappingProfile()
        {
            CreateMap<TaxType, TaxCreateDto>().ReverseMap();
            CreateMap<TaxDto, TaxType>().ReverseMap()
              .ForMember(dest => dest.TaxTypeLine, opt => opt.MapFrom(src => src.TaxTypeLine));

            CreateMap<TaxUpdateDto, TaxType>().ReverseMap();
            CreateMap<TaxReturnSearchDto, TaxType>().ReverseMap();


            CreateMap<TaxTypeLineDto, TaxTypeLine>().ReverseMap();


            CreateMap<TaxTypeLineCreateDto, TaxTypeLine>();
            CreateMap<TaxTypeLineUpdateDto, TaxTypeLine>();

        }
    }
}
