using AutoMapper;
using Inspection.Application.Contracts.Dto.InspectionDto.Techinal.ChecklistTemplates;

using Inspection.Domain.Models.Inspection.Techinal.ChecklistTemplates;

namespace Inspection.Application.Mapping.Inspection.Techinal.ChecklistTemplates
{
    public class ChecklistTemplateMappingProfile : Profile
    {
        public ChecklistTemplateMappingProfile()
        {
            // -------------------- READ --------------------

            CreateMap<ChecklistTemplate, ChecklistTemplateDto>();
            CreateMap<ChecklistTemplateLine, ChecklistTempleteLineDto>();


            // -------------------- CREATE --------------------

            CreateMap<ChecklistTemplateCreateDto, ChecklistTemplate>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.ChecklistTemplateLines, opt => opt.Ignore());

            CreateMap<ChecklistTempleteLineCreateDto, ChecklistTemplateLine>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.ChecklistTemplate, opt => opt.Ignore());

            // -------------------- UPDATE --------------------

            // -------------------- UPDATE --------------------
            CreateMap<ChecklistTemplateUpdateDto, ChecklistTemplate>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.ChecklistTemplateLines, opt => opt.Ignore());

            CreateMap<ChecklistTempleteLineUpdateDto, ChecklistTemplateLine>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.ChecklistTemplate, opt => opt.Ignore());


        }
    }
}
