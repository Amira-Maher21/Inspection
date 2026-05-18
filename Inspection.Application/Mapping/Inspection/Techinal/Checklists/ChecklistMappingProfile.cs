using AutoMapper;
using Inspection.Application.Contracts.Dto.InspectionDto.Techinal.Checklists;
using Inspection.Application.Contracts.Dto.InspectionDto.Techinal.Checklists.ChecklistLines;
using Inspection.Domain.Models.Inspection.Techinal.ChecklistLines;
using Inspection.Domain.Models.Inspection.Techinal.Checklists;

namespace Inspection.Application.Mapping.Inspection.Techinal.Checklists
{
    public class ChecklistMappingProfile : Profile
    {
        public ChecklistMappingProfile()
        {
            // -------------------- READ --------------------

            CreateMap<Checklist, ChecklistDto>();
            CreateMap<ChecklistLine, ChecklistLineDto>();


            // -------------------- CREATE --------------------

            CreateMap<ChecklistCreateDto, Checklist>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.ChecklistLines, opt => opt.Ignore());

            CreateMap<ChecklistLineCreateDto, ChecklistLine>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.Checklist, opt => opt.Ignore());


            // -------------------- UPDATE --------------------

            // -------------------- UPDATE --------------------
            CreateMap<ChecklistUpdateDto, Checklist>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.ChecklistLines, opt => opt.Ignore());

            CreateMap<ChecklistLineUpdateDto, ChecklistLine>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.Checklist, opt => opt.Ignore());
        }
    }
}
