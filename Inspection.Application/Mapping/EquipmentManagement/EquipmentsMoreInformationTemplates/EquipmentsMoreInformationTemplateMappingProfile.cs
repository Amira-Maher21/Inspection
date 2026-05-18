using AutoMapper;
using Inspection.Application.Contracts.Dto.EquipmentManagement.EquipmentsMoreInformationTemplates;
using Inspection.Domain.Models.EquipmentManagement.EquipmentsMoreInfoTemplates;

namespace Inspection.Application.Mapping.EquipmentManagement.EquipmentsMoreInformationTemplates
{

    public class EquipmentsMoreInformationTemplateMappingProfile : Profile
    {
        public EquipmentsMoreInformationTemplateMappingProfile()
        {
            CreateMap<EquipmentsMoreInformationTemplate, CreateEquipmentsMoreInformationTemplateDto>().ReverseMap();

            CreateMap<UpdateEquipmentsMoreInformationTemplateDto, EquipmentsMoreInformationTemplate>().ReverseMap();

            CreateMap<EquipmentsMoreInformationTemplateDto, EquipmentsMoreInformationTemplate>().ReverseMap();


            CreateMap<EquipmentsMoreInformationTemplateDtoByInclude, EquipmentsMoreInformationTemplate>().ReverseMap();
            CreateMap<EquipmentsMoreInformationTemplateDtoByInclude, EquipmentsMoreInformationTemplateDto>().ReverseMap();



        }
    }
}
