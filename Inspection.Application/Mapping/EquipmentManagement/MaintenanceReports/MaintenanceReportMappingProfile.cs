using AutoMapper;
 using Inspection.Application.Contracts.Dto.EquipmentManagement.MaintenanceReports;
 using Inspection.Domain.Models.EquipmentManagement.MaintenanceReports;
 

namespace Inspection.Application.Mapping.EquipmentManagement.MaintenanceReports
{
    internal class MaintenanceReportMappingProfile : Profile
    {
        public MaintenanceReportMappingProfile()
        {
            CreateMap<MaintenanceReport, MaintenanceReportDto>().ReverseMap();
            CreateMap<CreateMaintenanceReportDto, MaintenanceReport>();
        }
    }
}
