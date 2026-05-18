using AutoMapper;
using Inspection.Application.Contracts.Dto.EquipmentManagement.EquipmentCalibrationHistorys;
using Inspection.Domain.Models.EquipmentManagement.EquipmentCalibrationHistorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Mapping.EquipmentManagement.EquipmentCalibrationHistorys
{
 

    public class EquipmentCalibrationHistoryMappingProfile : Profile
    {
        public EquipmentCalibrationHistoryMappingProfile()
        {
            CreateMap<EquipmentCalibrationHistory, CreateEquipmentCalibrationHistoryDto>().ReverseMap();

            CreateMap<UpdateEquipmentCalibrationHistoryDto, EquipmentCalibrationHistory>().ReverseMap();

            CreateMap<EquipmentCalibrationHistoryDto, EquipmentCalibrationHistory>().ReverseMap();

            //CreateMap<EquipmentCalibrationHistoryDtoLookUpForNames, EquipmentCalibrationHistory>().ReverseMap();

            CreateMap<EquipmentCalibrationHistoryDtoByInclude, EquipmentCalibrationHistory>().ReverseMap();
            CreateMap<EquipmentCalibrationHistoryDtoByInclude, EquipmentCalibrationHistoryDto>().ReverseMap();


            //CreateMap<EquipmentCalibrationHistoryDtoByInclude, EquipmentCalibrationHistoryDtoLookUpForNames>().ReverseMap();

        }
    }
}
