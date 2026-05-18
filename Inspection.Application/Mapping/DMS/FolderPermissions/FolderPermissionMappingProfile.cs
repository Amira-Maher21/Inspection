using AutoMapper;
using Inspection.Application.Contracts.Dto.DMSDTOs.FolderPermissionDTOs;
using Inspection.Domain.Models.DMS.FolderPermissions;

namespace Inspection.Application.Mapping.DMS.FolderPermissions
{
    public class FolderPermissionMappingProfile : Profile
    {
        public FolderPermissionMappingProfile()
        {
            CreateMap<FolderPermission, FolderPermissionCreateDto>().ReverseMap().ForMember(x => x.Tenant_ID, opt => opt.Ignore());
            CreateMap<FolderPermission, FolderPermissionUpdateDto>().ReverseMap();
            CreateMap<FolderPermission, FolderPermissionDto>().ReverseMap();
            CreateMap<FolderPermission, FolderPermissionReturnSearchDto>().ReverseMap();
        }
    }
}

