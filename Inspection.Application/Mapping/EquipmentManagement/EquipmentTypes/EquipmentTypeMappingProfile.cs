using AutoMapper;
using Inspection.Application.Contracts.Dto.EquipmentManagement.EquipmentTypes;
using Inspection.Domain.Models.EquipmentManagement.EquipmentTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Mapping.EquipmentManagement.EquipmentTypes
{
    public class EquipmentTypeMappingProfile: Profile
    {
        public EquipmentTypeMappingProfile()
        {
            CreateMap<EquipmentType, CreateEquipmentTypeDto>().ReverseMap();

            CreateMap<UpdateEquipmentTypeDto, EquipmentType>().ReverseMap();

            CreateMap<EquipmentTypeDto, EquipmentType>().ReverseMap();

            CreateMap<EquipmentTypeDtoLookUpForNames, EquipmentType>().ReverseMap();

            CreateMap<EquipmentTypeDtoByInclude, EquipmentType>().ReverseMap();
            CreateMap<EquipmentTypeDtoByInclude, EquipmentTypeDto>().ReverseMap();


            CreateMap<EquipmentTypeDtoByInclude, EquipmentTypeDtoLookUpForNames>().ReverseMap();

        }
    }
}


 
