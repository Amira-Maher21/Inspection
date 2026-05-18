using AutoMapper;
using Inspection.Application.Contracts.Dto.InspectionManagement.InspectionChecklistMoreInformationDetails;
using Inspection.Domain.Models.InspectionManagement.InspectionChecklistMoreInformationDetails;

namespace Inspection.Application.Mapping.InspectionManagement.InspectionChecklistMoreInformationDetails
{


    public class InspectionChecklistMoreInformationDetailMappingProfile : Profile
    {
        public InspectionChecklistMoreInformationDetailMappingProfile()
        {
            CreateMap<InspectionChecklistMoreInformationDetail, CreateInspectionChecklistMoreInformationDetailDto>().ReverseMap();

            CreateMap<UpdateInspectionChecklistMoreInformationDetailDto, InspectionChecklistMoreInformationDetail>().ReverseMap();

            CreateMap<InspectionChecklistMoreInformationDetailDto, InspectionChecklistMoreInformationDetail>().ReverseMap();


            CreateMap<InspectionChecklistMoreInformationDetailDtoByInclude, InspectionChecklistMoreInformationDetail>().ReverseMap();
            CreateMap<InspectionChecklistMoreInformationDetailDtoByInclude, InspectionChecklistMoreInformationDetailDto>().ReverseMap();
            CreateMap<InspectionChecklistMoreInformationDetailsKeyValueDto, InspectionChecklistMoreInformationDetail>().ReverseMap();
            CreateMap<InspectionChecklistMoreInformationDetailsKeyValueDto, InspectionChecklistMoreInformationDetailDto>().ReverseMap();
            CreateMap<InspectionChecklistMoreInformationDetailsKeyValueDto, InspectionChecklistMoreInformationDetailDtoByInclude>().ReverseMap();



        }
    }
}
