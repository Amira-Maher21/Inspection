using AutoMapper;
using Inspection.Application.Contracts.Dto.DMSDTOs.TagDTOs;
using Inspection.Domain.Models.DMS.Tags;

namespace Inspection.Application.Mapping.DMS.Tags
{
    public class TagMappingProfile : Profile
    {
        public TagMappingProfile()
        {
            CreateMap<Tag, TagCreateDto>().ReverseMap().ForMember(x => x.Tenant_ID, opt => opt.Ignore());
            CreateMap<Tag, TagUpdateDto>().ReverseMap();
            CreateMap<Tag, TagDto>().ReverseMap();
            CreateMap<Tag, TagReturnSearchDto>().ReverseMap();
        }
    }
}