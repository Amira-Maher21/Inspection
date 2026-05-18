using AutoMapper;
using Inspection.Application.Contracts.Dto.DMSDTOs.DocumentDTOs;
using Inspection.Application.Contracts.Dto.DMSDTOs.DocumentDTOs.DocumentEntityLinkDTOs;
using Inspection.Domain.Models.DMS.Documents;

namespace Inspection.Application.Mapping.DMS.Documents
{
    public class DocumentMappingProfile : Profile
    {
        public DocumentMappingProfile()
        {
            // -------------------- READ --------------------

            CreateMap<Document, DocumentDto>()
                .ForMember(
                    dest => dest.TagIds,
                    opt => opt.MapFrom(src =>
                        src.DocumentTags.Select(dt => dt.TagId)
                    ));

            CreateMap<DocumentEntityLink, DocumentEntityLinkDto>();
            CreateMap<Document, DocumentSearchReturnDto>()
                .ForMember(
                    dest => dest.TagIds,
                    opt => opt.MapFrom(src =>
                        src.DocumentTags.Select(dt => dt.TagId)
                    ));

            // -------------------- CREATE --------------------

            CreateMap<DocumentCreateDto, Document>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.DocumentEntityLinks, opt => opt.Ignore());

            CreateMap<DocumentEntityLinkCreateDto, DocumentEntityLink>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.Document, opt => opt.Ignore());

            CreateMap<DocumentEntityLinkCreateWithOutDocumentIdDto, DocumentEntityLink>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.Document, opt => opt.Ignore());

            // -------------------- UPDATE --------------------

            CreateMap<DocumentUpdateDto, Document>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.DocumentEntityLinks, opt => opt.Ignore());

            CreateMap<DocumentEntityLinkUpdateDto, DocumentEntityLink>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.Document, opt => opt.Ignore());
        }
    }
}