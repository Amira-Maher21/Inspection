using AutoMapper;
using Inspection.Application.Contracts.Dto.InspectionManagement.InspectionTypes;
using Inspection.Domain.Models.InspectionManagement.InspectionTypes;

namespace Inspection.Application.Mapping.InspectionManagement.InspectionTypes
{

    public class InspectionTypeMappingProfile : Profile
    {
        public InspectionTypeMappingProfile()
        {
            CreateMap<InspectionType, InspectionTypeCreateDto>().ReverseMap().ForMember(x => x.Tenant_ID, opt => opt.Ignore());
            CreateMap<InspectionType, InspectionTypeUpdateDto>().ReverseMap();
            CreateMap<InspectionType, InspectionTypeDto>().ReverseMap();
        }
    }
}