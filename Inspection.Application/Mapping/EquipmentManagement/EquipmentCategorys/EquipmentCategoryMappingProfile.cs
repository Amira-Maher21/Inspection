using AutoMapper;
using Inspection.Application.Contracts.Dto.EquipmentManagement.EquipmentCategorys;
using Inspection.Domain.Models.EquipmentManagement.EquipmentCategorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Mapping.EquipmentManagement.EquipmentCategorys
{
   
 
    public class EquipmentCategoryMappingProfile : Profile
    {
        public EquipmentCategoryMappingProfile()
        {
            CreateMap<EquipmentCategory, CreateEquipmentCategoryDto>().ReverseMap();

            CreateMap<UpdateEquipmentCategoryDto, EquipmentCategory>().ReverseMap();

            CreateMap<EquipmentCategoryDto, EquipmentCategory>().ReverseMap();

            CreateMap<EquipmentCategoryDtoLookUpForNames, EquipmentCategory>().ReverseMap();

            CreateMap<EquipmentCategoryDtoByInclude, EquipmentCategory>().ReverseMap();
            CreateMap<EquipmentCategoryDtoByInclude, EquipmentCategoryDto>().ReverseMap();


            CreateMap<EquipmentCategoryDtoByInclude, EquipmentCategoryDtoLookUpForNames>().ReverseMap();

        }
    }
}



