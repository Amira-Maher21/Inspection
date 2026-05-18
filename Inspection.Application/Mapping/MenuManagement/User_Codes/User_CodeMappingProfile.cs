
using AutoMapper;
using Inspection.Application.Contracts.Dto.MenuManagement.User_Code_dGroups;
using Inspection.Application.Contracts.Dto.MenuManagement.User_Codes;
using Inspection.Domain.Models.MenuManagement;

namespace Inspection.Application.Mapping.MenuManagement.User_Codes
{
    public class User_CodeMappingProfile : Profile
    {
        public User_CodeMappingProfile()
        {
            // Create
            CreateMap<CreateUser_CodeDto, User_Code>()
                .ForMember(d => d.Tenant_ID, o => o.Ignore())
                .ForMember(d => d.User_Code_dGroups, opt => opt.MapFrom(src => src.User_Code_dGroups));

            CreateMap<User_Code_dGroupDto, User_Code_dGroup>()
                .ForMember(d => d.User_CodeId, opt => opt.Ignore())
                .ForMember(d => d.Tenant_ID, opt => opt.Ignore());

            // Update
            CreateMap<UpdateUser_CodeDto, User_Code>()
             .ForMember(d => d.Id, o => o.Ignore())
             .ForMember(d => d.Tenant_ID, o => o.Ignore())
             .ForMember(d => d.User_Code_dGroups, o => o.Ignore());

            // DTOs
            CreateMap<User_Code, User_CodeDto>()
                .ForMember(d => d.User_Code_dGroups, opt => opt.MapFrom(src => src.User_Code_dGroups));

            CreateMap<User_Code_dGroup, User_Code_dGroupDto>();
        }
    }
}