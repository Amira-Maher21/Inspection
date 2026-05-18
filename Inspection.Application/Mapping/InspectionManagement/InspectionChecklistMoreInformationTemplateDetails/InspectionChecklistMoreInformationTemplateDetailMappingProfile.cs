using AutoMapper;
using Inspection.Application.Contracts.Dto.InspectionManagement.InspectionChecklistMoreInformationTemplateDetails;
using Inspection.Domain.Models.InspectionManagement.InspectionChecklistMoreInformationTemplateDetails;

namespace Inspection.Application.Mapping.InspectionManagement.InspectionChecklistMoreInformationTemplateDetails
{

    public class InspectionChecklistMoreInformationTemplateDetailMappingProfile : Profile
    {
        public InspectionChecklistMoreInformationTemplateDetailMappingProfile()
        {
            CreateMap<InspectionChecklistMoreInformationTemplateDetail, CreateInspectionChecklistMoreInformationTemplateDetailDto>().ReverseMap();

            CreateMap<UpdateInspectionChecklistMoreInformationTemplateDetailDto, InspectionChecklistMoreInformationTemplateDetail>().ReverseMap();

            CreateMap<InspectionChecklistMoreInformationTemplateDetailDto, InspectionChecklistMoreInformationTemplateDetail>().ReverseMap();

            CreateMap<InspectionChecklistMoreInformationTemplateDetailDtoByInclude, InspectionChecklistMoreInformationTemplateDetail>().ReverseMap();

            CreateMap<InspectionChecklistMoreInformationTemplateDetailDtoByInclude, InspectionChecklistMoreInformationTemplateDetailDto>().ReverseMap();

            CreateMap<InspectionChecklistMoreInformationTemplateDetailKeyValueDto, InspectionChecklistMoreInformationTemplateDetail>().ReverseMap();
            CreateMap<InspectionChecklistMoreInformationTemplateDetailKeyValueDto, InspectionChecklistMoreInformationTemplateDetailDto>().ReverseMap();
            CreateMap<InspectionChecklistMoreInformationTemplateDetailKeyValueDto, InspectionChecklistMoreInformationTemplateDetailDtoByInclude>().ReverseMap();


        }
    }
}
