using AutoMapper;
using Inspection.Application.Contracts.Dto.SystemConfigurationDTOs.CityDTOs;
using Inspection.Domain.Models.SystemConfigurations.Cities;

namespace Inspection.Application.Mapping.SystemConfigurations.Cities
{
    public class CityMappingProfile : Profile
    {
        public CityMappingProfile()
        {
            CreateMap<City, CityCreateDto>().ReverseMap().ForMember(x => x.Tenant_ID, opt => opt.Ignore());
            CreateMap<CityUpdateDto, City>().ReverseMap();
            CreateMap<CityDto, City>().ReverseMap();
        }
    }
}