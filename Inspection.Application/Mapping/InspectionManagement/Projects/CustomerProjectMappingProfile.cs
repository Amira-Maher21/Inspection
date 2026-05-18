using AutoMapper;
using Inspection.Application.Contracts.Dto.InspectionManagement.CustomerProjects;
using Inspection.Domain.Models.InspectionManagement.CustomerProjects;

namespace Inspection.Application.Mapping.InspectionManagement.CustomerProjects
{
    public class CustomerProjectMappingProfile : Profile
    {
        public CustomerProjectMappingProfile()
        {
            CreateMap<CustomerProject, CreateCustomerProjectDto>().ReverseMap();

            CreateMap<UpdateCustomerProjectDto, CustomerProject>().ReverseMap();

            CreateMap<CustomerProjectDto, CustomerProject>().ReverseMap();
            CreateMap<CustomerProjectDtoByInclude, CustomerProject>().ReverseMap();
            CreateMap<CustomerProjectDtoByInclude, CustomerProjectDto>().ReverseMap();

            CreateMap<CustomerProjectDtoLookUpForNames, CustomerProjectDtoByInclude>().ReverseMap();
        }
    }
}
