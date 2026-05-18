
using AutoMapper;
using Inspection.Application.Contracts.Dto.MenuManagement.Screen_permissions;
using Inspection.Application.Contracts.Dto.MenuManagement.User_Code_dGroups;
using Inspection.Application.Contracts.Dto.MenuManagement.User_Codes;
using Inspection.Application.Contracts.Dto.MenuManagement.User_Groups;
using Inspection.Domain.Models.MenuManagement;

namespace Inspection.Application.Mapping.MenuManagement.User_Groups
{
    public class User_GroupMappingProfile : Profile
    {
        public User_GroupMappingProfile()
        {
            CreateMap<User_Group, User_GroupDto>().ReverseMap();
            CreateMap<User_Group, UpdateUser_GroupDto>().ReverseMap();
            CreateMap<User_Group, User_CodeReturnSearchDto>().ReverseMap();
            CreateMap<CreateUser_GroupDto, User_Group>()
                      .ForMember(dest => dest.User_Code_dGroups, opt => opt.MapFrom(src => src.User_Code_dGroups));

            CreateMap<CreateUser_Code_dGroupDto, User_Code_dGroup>();
            CreateMap<UpdateUser_Code_dGroupDto, User_Code_dGroup>();




            CreateMap<CreateScreen_permissionDto, Screen_permission>();
            CreateMap<UpdateScreen_permissionDto, Screen_permission>();
            CreateMap<Screen_permissionDto, Screen_permission>();







        }
    }
}


