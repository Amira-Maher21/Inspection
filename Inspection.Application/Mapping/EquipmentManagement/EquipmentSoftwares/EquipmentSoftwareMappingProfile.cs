using AutoMapper;
using Inspection.Application.Contracts.Dto.EquipmentManagement.EquipmentSoftwares;
using Inspection.Domain.Models.EquipmentManagement.EquipmentSoftwares;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Mapping.EquipmentManagement.EquipmentSoftwares
{
 

    public class EquipmentSoftwareMappingProfile : Profile
    {
        public EquipmentSoftwareMappingProfile()
        {
            CreateMap<EquipmentSoftware, CreateEquipmentSoftwareDto>().ReverseMap();

            CreateMap<UpdateEquipmentSoftwareDto, EquipmentSoftware>().ReverseMap();

            CreateMap<EquipmentSoftwareDto, EquipmentSoftware>().ReverseMap();

            //CreateMap<EquipmentSoftwareDtoLookUpForNames, EquipmentSoftware>().ReverseMap();

            CreateMap<EquipmentSoftwareDtoByInclude, EquipmentSoftware>().ReverseMap();
            CreateMap<EquipmentSoftwareDtoByInclude, EquipmentSoftwareDto>().ReverseMap();


            //CreateMap<EquipmentSoftwareDtoByInclude, EquipmentSoftwareDtoLookUpForNames>().ReverseMap();

        }
    }
}

