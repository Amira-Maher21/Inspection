using AutoMapper;
using Inspection.Application.Contracts.Dto.InspectionManagement.InspectionMethodDTOs;
using Inspection.Domain.Models.InspectionManagement.InspectionMethods;

namespace Inspection.Application.Mapping.InspectionManagement.InspectionMethods
{

    public class InspectionMethodMappingProfile : Profile
    {
        public InspectionMethodMappingProfile()
        {
            // -------------------- READ --------------------
            CreateMap<InspectionMethod, InspectionMethodDto>();

            // -------------------- CREATE --------------------
            CreateMap<InspectionMethodCreateDto, InspectionMethod>()
                .ForMember(d => d.Id, opt => opt.Ignore());

            // -------------------- UPDATE --------------------
            CreateMap<InspectionMethodUpdateDto, InspectionMethod>()
                .ForMember(d => d.Id, opt => opt.Ignore());
        }
    }
}