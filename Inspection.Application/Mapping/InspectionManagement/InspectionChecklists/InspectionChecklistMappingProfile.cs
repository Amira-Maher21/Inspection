using AutoMapper;
using Inspection.Application.Contracts.Dto.InspectionManagement.InspectionChecklists;
using Inspection.Domain.Models.InspectionManagement.InspectionChecklists;

namespace Inspection.Application.Mapping.InspectionManagement.InspectionChecklists
{
    public class InspectionChecklistMappingProfile : Profile
    {
        public InspectionChecklistMappingProfile()
        {
            CreateMap<InspectionChecklist, InspectionChecklistDto>().ReverseMap();
            CreateMap<CreateInspectionChecklistDto, InspectionChecklist>().ReverseMap();
            CreateMap<UpdateInspectionChecklistDto, InspectionChecklist>().ReverseMap();
            CreateMap<InspectionChecklistDtoByInclude, InspectionChecklist>().ReverseMap();
            CreateMap<InspectionChecklistDtoByInclude, InspectionChecklistDto>().ReverseMap();
            CreateMap<InspectionChecklistDto, InspectionChecklist>().ReverseMap();
        }
    }

}
