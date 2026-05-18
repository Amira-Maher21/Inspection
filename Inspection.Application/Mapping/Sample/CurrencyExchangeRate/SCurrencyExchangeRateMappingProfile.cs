using AutoMapper;
using Inspection.Application.Contracts.Dto.SampleDTOs.CurrencyExchangeRateDTOs;
using Inspection.Application.Extensions;
using Inspection.Domain.Models.Sample.CurrencyExchangeRate;

namespace Inspection.Application.Mapping.Sample.CurrencyExchangeRate
{
    internal class SCurrencyExchangeRateMappingProfile : Profile
    {
        public SCurrencyExchangeRateMappingProfile()
        {
            // -------------------- CREATE --------------------

            CreateMap<SCurrencyExchangeRateCreateDto.SCurrencyExchangeRateCreateLine,
                      SCurrencyExchangeRateLine>()
                .IgnoreAuditFields();

            CreateMap<SCurrencyExchangeRateCreateDto,
                      SCurrencyExchangeRateHeader>()
                .ForMember(dest => dest.Lines, opt => opt.MapFrom(src => src.Lines))
                .IgnoreAuditFields()
                .IgnoreMultiTenantFields();

            // -------------------- UPDATE HEADER --------------------

            CreateMap<SCurrencyExchangeRateUpdateDto,
                      SCurrencyExchangeRateHeader>()
                .ForMember(dest => dest.Lines, opt => opt.Ignore()) // 🚫 VERY IMPORTANT
                .ForMember(dest => dest.Currency, opt => opt.Ignore())
                .ForMember(dest => dest.CompanyId, opt => opt.Ignore())
                .IgnoreAuditFields()
                .IgnoreMultiTenantFields();

            // -------------------- ADD LINE --------------------

            CreateMap<SCurrencyExchangeRateAddLineDto,
                      SCurrencyExchangeRateLine>()
                .IgnoreAuditFields();

            // -------------------- UPDATE LINE --------------------

            CreateMap<SCurrencyExchangeRateUpdateLineDto,
                      SCurrencyExchangeRateLine>()
                .ForMember(dest => dest.Currency, opt => opt.Ignore())
                .ForMember(dest => dest.CurrencyExchangHeaderId, opt => opt.Ignore())
                .IgnoreAuditFields();
        }
    }
}