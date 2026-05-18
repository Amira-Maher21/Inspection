using AutoMapper;
using Inspection.Application.Contracts.Dto.EquipmentManagement.Series;
using Inspection.Application.Contracts.Dto.MenuManagement.AreaF;
using Inspection.Domain.Models.MenuManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Mapping.MenuManagement.AreaF
{
    public class AreaMappingProfile : Profile
    {
        public AreaMappingProfile()
        {
            CreateMap<Area, AreaDto>().ReverseMap();
            CreateMap<Area, CreateAreaDto>().ReverseMap();
            CreateMap<Area, UpdateAreaDto>().ReverseMap();
            CreateMap<AreaLookupDefaultDto, AreaIncludeDto>().ReverseMap();
          

        }
    }
}
