using AutoMapper;
using Inspection.Application.Contracts.Dto.InspectionManagement.InspectionChecklists;
using Inspection.Domain.Models.InspectionManagement.InspectionChecklistMoreInformations;

namespace Inspection.Application.Mapping.InspectionManagement.InspectionChecklistMoreInformations
{

    public class InspectionChecklistMoreInformationMappingProfile : Profile
    {
        public InspectionChecklistMoreInformationMappingProfile()
        {
            CreateMap<InspectionChecklistMoreInformation, CreateInspectionChecklistMoreInformationDto>().ReverseMap();

            CreateMap<UpdateInspectionChecklistMoreInformationDto, InspectionChecklistMoreInformation>().ReverseMap();

            CreateMap<InspectionChecklistMoreInformationDto, InspectionChecklistMoreInformation>().ReverseMap();


            CreateMap<InspectionChecklistMoreInformationDtoByInclude, InspectionChecklistMoreInformation>().ReverseMap();
            CreateMap<InspectionChecklistMoreInformationDtoByInclude, InspectionChecklistMoreInformationDto>().ReverseMap();




        }
    }
}
