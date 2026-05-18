using AutoMapper;
using Inspection.Application.Contracts.Dto.SystemConfigurationDTOs.CompanyDTOs;
using Inspection.Application.Contracts.Dto.SystemConfigurationDTOs.CurrencyDTOs;
using Inspection.Domain.Models.SystemConfigurations.Currencies;

namespace Inspection.Application.Mapping.SystemConfigurations.Currencies
{
    public class CurrencyMappingProfile : Profile
    {
        public CurrencyMappingProfile()
        {
            CreateMap<Currency, CurrencyCreateDto>().ReverseMap();
            CreateMap<CurrencyUpdateDto, Currency>().ReverseMap();
            CreateMap<CurrencyDto, Currency>().ReverseMap();
            CreateMap<CompanyIdNameDto, CompanyDto>().ReverseMap();
        }
    }
}