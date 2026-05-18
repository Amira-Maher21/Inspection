using AutoMapper;
using Inspection.Application.Contracts.Dto.EquipmentManagement.CompanyEquipments;
 using Inspection.Domain.Models.EquipmentManagement.CompanyEquipments;
 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Mapping.EquipmentManagement.CompanyEquipments
{
   
    public class CompanyEquipmentMappingProfile : Profile
    {
        public CompanyEquipmentMappingProfile()
        {
            CreateMap<CompanyEquipment, CreateCompanyEquipmentDto>().ReverseMap();

            CreateMap<UpdateCompanyEquipmentDto, CompanyEquipment>().ReverseMap();

            CreateMap<CompanyEquipmentDto, CompanyEquipment>().ReverseMap();

            //CreateMap<CompanyEquipmentDtoLookUpForNames, CompanyEquipment>().ReverseMap();

            CreateMap<CompanyEquipmentDtoByInclude, CompanyEquipment>().ReverseMap();
            CreateMap<CompanyEquipmentDtoByInclude, CompanyEquipmentDto>().ReverseMap();


            //CreateMap<CompanyEquipmentDtoByInclude, CompanyEquipmentDtoLookUpForNames>().ReverseMap();

        }
    }
}
