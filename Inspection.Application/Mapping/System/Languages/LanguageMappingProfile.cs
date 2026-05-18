using AutoMapper;
using Inspection.Application.Contracts.Dto.SystemDto.Languages;
using Inspection.Domain.Models.System.Languages;

namespace Inspection.Application.Mapping.System.Languages
{
    public class LanguageMappingProfile : Profile
    {
        public LanguageMappingProfile()
        {
            CreateMap<Language, LanguageCreateDto>().ReverseMap();
            CreateMap<LanguageDto, Language>().ReverseMap();

            CreateMap<LanguageUpdateDto, Language>().ReverseMap();
            CreateMap<LanguageReturnSearchDto, Language>().ReverseMap();






        }
    }
}
