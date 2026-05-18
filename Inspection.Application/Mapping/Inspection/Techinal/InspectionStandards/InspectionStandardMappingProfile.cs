using AutoMapper;
using Inspection.Application.Contracts.Dto.InspectionDto.Techinal.InspectionStandards;
using Inspection.Domain.Models.Inspection.Techinal.InspectionStandardApplicabilityRules;
using Inspection.Domain.Models.Inspection.Techinal.InspectionStandards;

namespace Inspection.Application.Mapping.Inspection.Techinal.InspectionStandards
{
    public class InspectionStandardMappingProfile : Profile
    {
        public InspectionStandardMappingProfile()
        {
            // -------------------- READ --------------------

            CreateMap<InspectionStandard, InspectionStandardDto>();
            CreateMap<InspectionStandardApplicabilityRule, InspectionStandardApplicabilityRuleDto>();


            // -------------------- CREATE --------------------

            CreateMap<InspectionStandardCreateDto, InspectionStandard>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.InspectionStandardApplicabilityRules, opt => opt.Ignore());

            CreateMap<InspectionStandardApplicabilityRuleCreateDto, InspectionStandardApplicabilityRule>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.Standard, opt => opt.Ignore());


            // -------------------- UPDATE --------------------

            // -------------------- UPDATE --------------------
            CreateMap<InspectionStandardUpdateDto, InspectionStandard>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.InspectionStandardApplicabilityRules, opt => opt.Ignore());

            CreateMap<InspectionStandardApplicabilityRuleUpdateDto, InspectionStandardApplicabilityRule>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.Standard, opt => opt.Ignore());
        }
    }
}
