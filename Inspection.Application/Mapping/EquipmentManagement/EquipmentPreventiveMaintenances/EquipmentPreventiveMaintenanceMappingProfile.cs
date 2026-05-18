using AutoMapper;
using Inspection.Application.Contracts.Dto.EquipmentManagement.EquipmentPreventiveMaintenances;
using Inspection.Domain.Models.EquipmentManagement.EquipmentPreventiveMaintenances;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Mapping.EquipmentManagement.EquipmentPreventiveMaintenances
{
 

    public class EquipmentPreventiveMaintenanceMappingProfile : Profile
    {
        public EquipmentPreventiveMaintenanceMappingProfile()
        {
            CreateMap<EquipmentPreventiveMaintenance, CreateEquipmentPreventiveMaintenanceDto>().ReverseMap();

            CreateMap<UpdateEquipmentPreventiveMaintenanceDto, EquipmentPreventiveMaintenance>().ReverseMap();

            CreateMap<EquipmentPreventiveMaintenanceDto, EquipmentPreventiveMaintenance>().ReverseMap();

            //CreateMap<EquipmentPreventiveMaintenanceDtoLookUpForNames, EquipmentPreventiveMaintenance>().ReverseMap();

            CreateMap<EquipmentPreventiveMaintenanceDtoByInclude, EquipmentPreventiveMaintenance>().ReverseMap();
            CreateMap<EquipmentPreventiveMaintenanceDtoByInclude, EquipmentPreventiveMaintenanceDto>().ReverseMap();


            //CreateMap<EquipmentPreventiveMaintenanceDtoByInclude, EquipmentPreventiveMaintenanceDtoLookUpForNames>().ReverseMap();

        }
    }
}
