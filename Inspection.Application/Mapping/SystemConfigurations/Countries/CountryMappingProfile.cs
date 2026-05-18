using AutoMapper;
using Inspection.Application.Contracts.Dto.SystemConfigurationDTOs.CountrisDto;
using Inspection.Domain.Models.SystemConfigurations.Countriess;

namespace Inspection.Application.Mapping.SystemConfigurations.Countries
{
    public class CountryMappingProfile : Profile
    {
        public CountryMappingProfile()
        {
            CreateMap<Country, CountryCreateDto>().ReverseMap();
            CreateMap<Country, CountrySearchDto>().ReverseMap();
            CreateMap<CountryUpdateDto, Country>().ReverseMap();
            CreateMap<CountryDto, Country>().ReverseMap();
        }
    }
}
