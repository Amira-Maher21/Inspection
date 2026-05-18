using AutoMapper;
using Inspection.Application.Contracts.Dto.InspectionManagement.InspectionChecklistMoreInformationTemplates;
using Inspection.Domain.Models.InspectionManagement.InspectionChecklistMoreInformationTemplates;

namespace Inspection.Application.Mapping.InspectionManagement.InspectionChecklistMoreInformationTemplates
{

    public class InspectionChecklistMoreInformationTemplateMappingProfile : Profile
    {
        public InspectionChecklistMoreInformationTemplateMappingProfile()
        {
            CreateMap<InspectionChecklistMoreInformationTemplate, CreateInspectionChecklistMoreInformationTemplateDto>().ReverseMap();

            CreateMap<UpdateInspectionChecklistMoreInformationTemplateDto, InspectionChecklistMoreInformationTemplate>().ReverseMap();

            CreateMap<InspectionChecklistMoreInformationTemplateDto, InspectionChecklistMoreInformationTemplate>().ReverseMap();


            CreateMap<InspectionChecklistMoreInformationTemplateDtoByInclude, InspectionChecklistMoreInformationTemplate>().ReverseMap();
            CreateMap<InspectionChecklistMoreInformationTemplateDtoByInclude, InspectionChecklistMoreInformationTemplateDto>().ReverseMap();



        }
    }
}
