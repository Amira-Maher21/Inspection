using AutoMapper;
using Inspection.Application.Contracts.Dto.DMSDTOs.DocumentCommentDTOs;
using Inspection.Domain.Models.DMS.DocumentComments;

namespace Inspection.Application.Mapping.DMS.DocumentComments
{
    public class DocumentCommentMappingProfile : Profile
    {
        public DocumentCommentMappingProfile()
        {
            CreateMap<DocumentComment, DocumentCommentCreateDto>().ReverseMap().ForMember(x => x.Tenant_ID, opt => opt.Ignore());
            CreateMap<DocumentComment, DocumentCommentUpdateDto>().ReverseMap();
            CreateMap<DocumentComment, DocumentCommentDto>().ReverseMap();
            CreateMap<DocumentComment, DocumentCommentReturnSearchDto>().ReverseMap();
        }
    }
}