using AutoMapper;
using Inspection.Application.Contracts.Dto.EquipmentManagement.EquipmentInspections;
 using Inspection.Domain.Models.EquipmentManagement.EquipmentInspections;
 

namespace Inspection.Application.Mapping.EquipmentManagement.EquipmentInspections
{
    public class EquipmentInspectionMappingProfile : Profile
    {
        public EquipmentInspectionMappingProfile()
        {
            CreateMap<EquipmentInspection, EquipmentInspectionDto>().ReverseMap();
            CreateMap<CreateEquipmentInspectionDto, EquipmentInspection>();
        }
    }
}

