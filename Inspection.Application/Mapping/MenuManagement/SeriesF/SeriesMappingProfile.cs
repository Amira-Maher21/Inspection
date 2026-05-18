using AutoMapper;
using Inspection.Application.Contracts.Dto.EquipmentManagement.Series;
using Inspection.Application.Contracts.Dto.MenuManagement.Series;
using Inspection.Domain.Models.MenuManagement;

namespace Inspection.Application.Mapping.MenuManagement.SeriesF
{
    public class SeriesMappingProfile : Profile
    {
        public SeriesMappingProfile()
        {
            CreateMap<Series, SeriesDto>().ReverseMap();
            CreateMap<Series, CreateSeriesDto>().ReverseMap();
            CreateMap<Series, UpdateSeriesDto>().ReverseMap();
            CreateMap<Screen_Code, ScreenCodeDto>().ReverseMap();
        }
    }
}
