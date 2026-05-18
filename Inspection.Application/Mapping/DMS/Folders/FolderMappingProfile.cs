using AutoMapper;
using Inspection.Application.Contracts.Dto.DMSDTOs.FolderDTOs;
using Inspection.Domain.Models.DMS.Folders;

namespace Inspection.Application.Mapping.DMS.Folders
{
    public class FolderMappingProfile : Profile
    {
        public FolderMappingProfile()
        {
            CreateMap<Folder, FolderCreateDto>().ReverseMap().ForMember(x => x.Tenant_ID, opt => opt.Ignore());
            CreateMap<Folder, FolderUpdateDto>().ReverseMap();
            CreateMap<Folder, FolderDto>().ReverseMap();
            CreateMap<Folder, FolderReturnSearchDto>().ReverseMap();
        }
    }
}
