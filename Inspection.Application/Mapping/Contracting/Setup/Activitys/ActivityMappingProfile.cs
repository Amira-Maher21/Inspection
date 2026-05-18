using AutoMapper;
using Inspection.Application.Contracts.Dto.ContractingDTOs.Setup.Activitys;
using Inspection.Domain.Models.Contracting.Setup.Activitys;

namespace Inspection.Application.Mapping.Contracting.Setup.Activitys
{
    public class ActivityMappingProfile : Profile
    {
        public ActivityMappingProfile()
        {
            CreateMap<ActivityCreateDto, Activity>().ReverseMap();
            CreateMap<ActivityUpdaeDto, Activity>().ReverseMap();
            CreateMap<Activity, ActivityDto>().ReverseMap();
        }
    }
}