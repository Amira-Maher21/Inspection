using AutoMapper;
using Inspection.Application.Contracts.Dto.EquipmentManagement.EquipmentAccessories;
using Inspection.Domain.Models.EquipmentManagement.EquipmentAccessories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Mapping.EquipmentManagement.EquipmentAccessories
{
    public class EquipmentAccessoryMappingProfile : Profile
    {
        public EquipmentAccessoryMappingProfile()
        {
            CreateMap<EquipmentAccessory, CreateEquipmentAccessoryDto>().ReverseMap();

            CreateMap<UpdateEquipmentAccessoryDto, EquipmentAccessory>().ReverseMap();

            CreateMap<EquipmentAccessoryDto, EquipmentAccessory>().ReverseMap();

            //CreateMap<EquipmentAccessoryDtoLookUpForNames, EquipmentAccessory>().ReverseMap();

            CreateMap<EquipmentAccessoryDtoByInclude, EquipmentAccessory>().ReverseMap();
            CreateMap<EquipmentAccessoryDtoByInclude, EquipmentAccessoryDto>().ReverseMap();


            //CreateMap<EquipmentAccessoryDtoByInclude, EquipmentAccessoryDtoLookUpForNames>().ReverseMap();
        }
    }
}
