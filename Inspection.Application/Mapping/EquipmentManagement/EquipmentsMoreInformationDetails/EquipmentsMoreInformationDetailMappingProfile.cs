using AutoMapper;
using Inspection.Application.Contracts.Dto.EquipmentManagement.EquipmentsMoreInformationDetails;
 using Inspection.Domain.Models.EquipmentManagement.EquipmentsMoreInformationDetails;
 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Mapping.EquipmentManagement.EquipmentsMoreInformationDetails
{
 
    public class EquipmentsMoreInformationDetailMappingProfile : Profile
    {
        public EquipmentsMoreInformationDetailMappingProfile()
        {
            CreateMap<EquipmentsMoreInformationDetail, CreateEquipmentsMoreInformationDetailDto>().ReverseMap();

            CreateMap<UpdateEquipmentsMoreInformationDetailDto, EquipmentsMoreInformationDetail>().ReverseMap();

            CreateMap<EquipmentsMoreInformationDetailDto, EquipmentsMoreInformationDetail>().ReverseMap();

            //CreateMap<EquipmentsMoreInformationDetailDtoLookUpForNames, EquipmentsMoreInformationDetail>().ReverseMap();

            CreateMap<EquipmentsMoreInformationDetailDtoByInclude, EquipmentsMoreInformationDetail>().ReverseMap();
            CreateMap<EquipmentsMoreInformationDetailDtoByInclude, EquipmentsMoreInformationDetailDto>().ReverseMap();
            CreateMap<EquipmentMoreInformationDetailsKeyValueDto, EquipmentsMoreInformationDetail>().ReverseMap();
            CreateMap<EquipmentMoreInformationDetailsKeyValueDto, EquipmentsMoreInformationDetailDto>().ReverseMap();
            CreateMap<EquipmentMoreInformationDetailsKeyValueDto, EquipmentsMoreInformationDetailDtoByInclude>().ReverseMap();


            //CreateMap<EquipmentsMoreInformationDetailDtoByInclude, EquipmentsMoreInformationDetailDtoLookUpForNames>().ReverseMap();

        }
    }
}
