using AutoMapper;
using Inspection.Application.Contracts.Dto.LocalizationDto;
using Inspection.Domain.Models.Localizations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Mapping.LocalizationManagement
{
    public class LocalizationMappingProfile: Profile
    {
        public LocalizationMappingProfile()
        {
            CreateMap<CreateLocalizationDto, Localization>().ReverseMap();
            CreateMap<UpdateLocalizationDto, Localization>().ReverseMap();
        }
    }
}
