using AutoMapper;
using Inspection.Application.Contracts.Dto.MenuManagement.Screen_permissions;
using Inspection.Domain.Models.MenuManagement;

namespace Inspection.Application.Mapping.MenuManagement.Screen_permissions
{

    public class Screen_permissionMappingProfile : Profile
    {
        public Screen_permissionMappingProfile()
        {
            CreateMap<Screen_permission, Screen_permissionDto>().ReverseMap();
            CreateMap<Screen_permission, Screen_permissionDtoByInclude>().ReverseMap();
            CreateMap<Screen_permission, CreateScreen_permissionDto>().ReverseMap();
            CreateMap<Screen_permission, UpdateScreen_permissionDto>().ReverseMap();
            CreateMap<Screen_permissionDto, Screen_permissionDtoByInclude>().ReverseMap();

        }
    }
}


