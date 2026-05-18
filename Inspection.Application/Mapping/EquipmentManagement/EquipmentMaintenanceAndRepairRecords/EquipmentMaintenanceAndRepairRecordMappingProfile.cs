using AutoMapper;
using Inspection.Application.Contracts.Dto.EquipmentManagement.EquipmentMaintenanceAndRepairRecords;
using Inspection.Domain.Models.EquipmentManagement.EquipmentMaintenanceAndRepairRecords;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Mapping.EquipmentManagement.EquipmentMaintenanceAndRepairRecords
{
 

    public class EquipmentMaintenanceAndRepairRecordMappingProfile : Profile
    {
        public EquipmentMaintenanceAndRepairRecordMappingProfile()
        {
            CreateMap<EquipmentMaintenanceAndRepairRecord, CreateEquipmentMaintenanceAndRepairRecordDto>().ReverseMap();

            CreateMap<UpdateEquipmentMaintenanceAndRepairRecordDto, EquipmentMaintenanceAndRepairRecord>().ReverseMap();

            CreateMap<EquipmentMaintenanceAndRepairRecordDto, EquipmentMaintenanceAndRepairRecord>().ReverseMap();

            //CreateMap<EquipmentMaintenanceAndRepairRecordDtoLookUpForNames, EquipmentMaintenanceAndRepairRecord>().ReverseMap();

            CreateMap<EquipmentMaintenanceAndRepairRecordDtoByInclude, EquipmentMaintenanceAndRepairRecord>().ReverseMap();
            CreateMap<EquipmentMaintenanceAndRepairRecordDtoByInclude, EquipmentMaintenanceAndRepairRecordDto>().ReverseMap();


            //CreateMap<EquipmentMaintenanceAndRepairRecordDtoByInclude, EquipmentMaintenanceAndRepairRecordDtoLookUpForNames>().ReverseMap();

        }
    }
}
