using AutoMapper;
using Inspection.Application.Contracts.Dto.SystemConfigurationDTOs.CompanyDTOs;
using Inspection.Domain.Models.SystemConfigurations.Companies;

namespace Inspection.Application.Mapping.SystemConfigurations.Companies
{
    public class CompanyMappingProfile : Profile
    {
        public CompanyMappingProfile()
        {
            CreateMap<Company, CompanyCreateDto>().ReverseMap().ForMember(x => x.Tenant_ID, opt => opt.Ignore());
            CreateMap<Company, CompanySearchDto>().ReverseMap();
            CreateMap<CompanyUpdateDto, Company>().ReverseMap();
            CreateMap<CompanyDto, Company>().ReverseMap();
            CreateMap<CompanyIdNameDto, CompanyDto>().ReverseMap();
            CreateMap<CompanyDto, CompanyReturnSearchDto>().ReverseMap();
        }
    }
}