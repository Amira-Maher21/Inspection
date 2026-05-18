using AutoMapper;
using Inspection.Application.Contracts.Dto.Setting.ModuleSettings;
using Inspection.Domain.Models.Seeting.ModuleSettings;

namespace Inspection.Application.Mapping.Setting.ModuleSettings
{
    public class ModuleSettingMappingProfile : Profile
    {
        public ModuleSettingMappingProfile()
        {
            CreateMap<ModuleSetting, ModuleSettingCreateDto>().ReverseMap();
            CreateMap<ModuleSettingDto, ModuleSetting>().ReverseMap();
            CreateMap<ModuleSettingUpdateDto, ModuleSetting>().ReverseMap();
            CreateMap<ModuleSettingReturnSearchDto, ModuleSetting>().ReverseMap();
        }
    }
}
