using AutoMapper;
using Inspection.Application.Contracts.Dto.InspectionManagement.CustomerLocations;
using Inspection.Domain.Models.InspectionManagement.CustomerLocations;


namespace Inspection.Application.Mapping.InspectionManagement.CustomerLocations
{
    public class CustomerLocationMappingProfile : Profile
    {

        public CustomerLocationMappingProfile()
        {
            CreateMap<CustomerLocation, CreateCustomerLocationDto>().ReverseMap();

            CreateMap<UpdateCustomerLocationDto, CustomerLocation>().ReverseMap();

            CreateMap<CustomerLocationDto, CustomerLocation>().ReverseMap();

            CreateMap<CustomerLocationDto, CustomerLocationDtoLookUpForNames>().ReverseMap();
            CreateMap<CustomerLocationDtoByInclude, CustomerLocationDtoLookUpForNames>().ReverseMap();
            CreateMap<CustomerLocationDtoByInclude, CustomerLocationDto>().ReverseMap();

        }
    }
}

