using AutoMapper;
using Inspection.Application.Contracts.Dto.InspectionDto.Techinal.InspectorCompetencyDTOs;
using Inspection.Application.Contracts.Dto.InspectionDto.Techinal.InspectorCompetencyDTOs.InspectorCompetencyLineDTOs;
using Inspection.Domain.Models.Inspection.Techinal.InspectorCompetencies;

namespace Inspection.Application.Mapping.Inspection.Techinal.InspectorCompetencies
{
    public class InspectorCompetencyMappingProfile : Profile
    {
        public InspectorCompetencyMappingProfile()
        {
            // -------------------- READ --------------------

            CreateMap<InspectorCompetency, InspectorCompetencyDto>();
            CreateMap<InspectorCompetencyLine, InspectorCompetencyLineDto>();

            CreateMap<InspectorAccreditation, InspectorAccreditationDto>()
                           .ForMember(d => d.InspectorCompetencyId, opt => opt.Ignore());

            // -------------------- CREATE --------------------


            CreateMap<InspectorCompetencyCreateDto, InspectorCompetency>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.InspectorCompetencyLines, opt => opt.Ignore())
                .ForMember(d => d.InspectorAccreditation, opt => opt.Ignore());

            CreateMap<InspectorCompetencyLineCreateDto, InspectorCompetencyLine>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.InspectorCompetency, opt => opt.Ignore());

            CreateMap<InspectorAccreditationCreateDto, InspectorAccreditation>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.InspectorCompetency, opt => opt.Ignore());


            // -------------------- UPDATE --------------------

            CreateMap<InspectorCompetencyUpdateDto, InspectorCompetency>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.InspectorCompetencyLines, opt => opt.Ignore())
                .ForMember(d => d.InspectorAccreditation, opt => opt.Ignore());

            CreateMap<InspectorCompetencyLineUpdateDto, InspectorCompetencyLine>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.InspectorCompetency, opt => opt.Ignore());

            CreateMap<InspectorAccreditationUpdateDto, InspectorAccreditation>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.InspectorCompetency, opt => opt.Ignore());
        }

    }
}