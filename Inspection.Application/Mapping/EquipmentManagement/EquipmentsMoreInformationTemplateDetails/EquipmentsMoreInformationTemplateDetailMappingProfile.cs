using AutoMapper;
using Inspection.Application.Contracts.Dto.EquipmentManagement.EquipmentsMoreInformationTemplateDetails;
using Inspection.Domain.Models.EquipmentManagement.EquipmentsMoreInformationTemplateDetails;

namespace Inspection.Application.Mapping.EquipmentManagement.EquipmentsMoreInformationTemplateDetails
{
    public class EquipmentsMoreInformationTemplateDetailMappingProfile : Profile
    {
        public EquipmentsMoreInformationTemplateDetailMappingProfile()
        {
            CreateMap<EquipmentsMoreInformationTemplateDetail, CreateEquipmentsMoreInformationTemplateDetailDto>().ReverseMap();

            CreateMap<UpdateEquipmentsMoreInformationTemplateDetailDto, EquipmentsMoreInformationTemplateDetail>().ReverseMap();

            CreateMap<EquipmentsMoreInformationTemplateDetailDto, EquipmentsMoreInformationTemplateDetail>().ReverseMap();

            CreateMap<EquipmentsMoreInformationTemplateDetailDtoLookUpForNames, EquipmentsMoreInformationTemplateDetail>().ReverseMap();

            CreateMap<EquipmentsMoreInformationTemplateDetailDtoByInclude, EquipmentsMoreInformationTemplateDetail>().ReverseMap();
            CreateMap<EquipmentsMoreInformationTemplateDetailDtoByInclude, EquipmentsMoreInformationTemplateDetailDto>().ReverseMap();

            CreateMap<EquipmentsMoreInformationTemplateDetailDtoByInclude, EquipmentsMoreInformationTemplateDetailDtoLookUpForNames>().ReverseMap();

            CreateMap<EquipmentMoreInformationTemplateDetailsKeyValueDto, EquipmentsMoreInformationTemplateDetail>().ReverseMap();
            CreateMap<EquipmentMoreInformationTemplateDetailsKeyValueDto, EquipmentsMoreInformationTemplateDetailDto>().ReverseMap();
            CreateMap<EquipmentMoreInformationTemplateDetailsKeyValueDto, EquipmentsMoreInformationTemplateDetailDtoByInclude>().ReverseMap();

        }
    }
}
