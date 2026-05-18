using AutoMapper;
 using Inspection.Application.Contracts.Dto.EquipmentManagement.MaintenanceSchedules;
 using Inspection.Domain.Models.EquipmentManagement.MaintenanceSchedules;
 
namespace Inspection.Application.Mapping.EquipmentManagement.MaintenanceSchedules
{
    internal class MaintenanceScheduleMappingProfile : Profile
    {
        public MaintenanceScheduleMappingProfile()
        {
            CreateMap<MaintenanceSchedule, MaintenanceScheduleDto>().ReverseMap();
            CreateMap<CreateMaintenanceScheduleDto, MaintenanceSchedule>();
        }
    }
}
