using AutoMapper;
using Inspection.Application.Contracts.Dto.InspectionManagement.InspectorCategory;

namespace Inspection.Application.Mapping.InspectionManagement.InspectorCategory
{
    public class InspectorCategoryMappingProfile : Profile
    {
        public InspectorCategoryMappingProfile()
        {
            CreateMap<Domain.Models.InspectionManagement.InspectorCategories.InspectorCategory, InspectorCategoryCreateDto>().ReverseMap().ForMember(x => x.Tenant_ID, opt => opt.Ignore());
            CreateMap<Domain.Models.InspectionManagement.InspectorCategories.InspectorCategory, InspectorCategoryUpdateDto>().ReverseMap();
            CreateMap<Domain.Models.InspectionManagement.InspectorCategories.InspectorCategory, InspectorCategoryDto>().ReverseMap();
            CreateMap<Domain.Models.InspectionManagement.InspectorCategories.InspectorCategory, InspectorCategoryGetListDto>().ReverseMap();
        }
    }
}