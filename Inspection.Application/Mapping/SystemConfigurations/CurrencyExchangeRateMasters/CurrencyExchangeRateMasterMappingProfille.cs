using AutoMapper;
using Inspection.Application.Contracts.Dto.SystemConfigurationDTOs.CurrencyExchangRateDtos;
using Inspection.Application.Contracts.Dto.SystemConfigurationDTOs.DetailTableDtos;
using Inspection.Application.Contracts.Dtos.CurrencyExchange;
using Inspection.Domain.Models.SystemConfigurations.CurrencyExchangRates;
using Inspection.Domain.Models.SystemConfigurations.DetailTables;

namespace Inspection.Application.MappingProfiles
{
    public class CurrencyExchangeRateMasterMappingProfile : Profile
    {
        public CurrencyExchangeRateMasterMappingProfile()
        {
            // DetailTable Mappings
            CreateMap<DetailTableCreateDto, DetailTable>()
                .ForMember(dest => dest.CurrencyExchangRateId, opt => opt.Ignore());

            CreateMap<DetailTableUpdateDto, DetailTable>()
                .ForMember(dest => dest.CurrencyExchangRateId, opt => opt.Ignore());

            CreateMap<DetailTableDto, DetailTable>()
                .ForMember(dest => dest.CurrencyExchangRateId, opt => opt.Ignore());

            CreateMap<DetailTable, DetailTableDto>();

            // CurrencyExchangeRateMaster Mappings
            CreateMap<CurrencyExchangeRateMasterCreateDto, CurrencyExchangRate>()
               .ForMember(dest => dest.Details, opt => opt.MapFrom(src => src.Details))
               .ForMember(dest => dest.Tenant_ID, opt => opt.Ignore());

            CreateMap<CurrencyExchangeRateMasterUpdateDto, CurrencyExchangRate>()
                .ForMember(dest => dest.Details, opt => opt.MapFrom(src => src.Details))
                .ForMember(dest => dest.Tenant_ID, opt => opt.Ignore());

            CreateMap<CurrencyExchangeRateMasterDto, CurrencyExchangRate>()
                .ForMember(dest => dest.Details, opt => opt.MapFrom(src => src.Details));

            CreateMap<CurrencyExchangRate, CurrencyExchangeRateMasterDto>()
                .ForMember(dest => dest.Details, opt => opt.MapFrom(src => src.Details));

            CreateMap<CurrencyExchangRate, CurrencyExchangeRateReturnSearchDto>()
                .ForMember(dest => dest.Details, opt => opt.MapFrom(src => src.Details));
        }
    }
}
