using AutoMapper;
using Inspection.Application.Contracts.Dto.EquipmentManagement.EquipmentsMoreInformations;
using Inspection.Domain.Models.EquipmentManagement.EquipmentsMoreInfo;

namespace Inspection.Application.Mapping.EquipmentManagement.EquipmentsMoreInformations
{
    public class EquipmentsMoreInformationMappingProfile : Profile
    {
        public EquipmentsMoreInformationMappingProfile()
        {
            CreateMap<EquipmentsMoreInformation, CreateEquipmentsMoreInformationDto>().ReverseMap();

            CreateMap<UpdateEquipmentsMoreInformationDto, EquipmentsMoreInformation>().ReverseMap();

            CreateMap<EquipmentsMoreInformationDto, EquipmentsMoreInformation>().ReverseMap();

            //CreateMap<EquipmentsMoreInformationDtoLookUpForNames, EquipmentsMoreInformation>().ReverseMap();

            CreateMap<EquipmentsMoreInformationIncludeDto, EquipmentsMoreInformation>().ReverseMap();
            CreateMap<EquipmentsMoreInformationIncludeDto, EquipmentsMoreInformationDto>().ReverseMap();


            //CreateMap<EquipmentsMoreInformationIncludeDto, EquipmentsMoreInformationDtoLookUpForNames>().ReverseMap();


        }
    }
}
