using AutoMapper;
using Inspection.Application.Contracts.Dto.MenuManagement.BranchF;
using Inspection.Domain.Models.MenuManagement;

namespace Inspection.Application.Mapping.MenuManagement.BranchF
{
    public class CustomerBranchMappingProfile : Profile
    {
        public CustomerBranchMappingProfile()
        {
            CreateMap<CustomerBranch, CustomerBranchDto>().ReverseMap();
            CreateMap<CustomerBranch, CreateCustomerBranchDto>().ReverseMap();
            CreateMap<CustomerBranch, UpdateCustomerBranchDto>().ReverseMap();
            CreateMap<CustomerBranchLookupDefualtDto, CustomerBranchIncludeDto>().ReverseMap();
        }
    }
}
