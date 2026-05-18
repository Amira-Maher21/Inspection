using AutoMapper;
using Inspection.Application.Contracts.Dto.AccountingDtos.Assets.AssetAccountingEvents;
using Inspection.Domain.Models.Accounting.Assets.AssetAccountingEvents;

namespace Inspection.Application.Mapping.Accounting.Assets.AssetAccountingEvents
{
    public class AssetAccountingEventMappingProfile : Profile
    {
        public AssetAccountingEventMappingProfile()
        {
            CreateMap<AssetAccountingEvent, AssetAccountingEventDto>().ReverseMap();

            CreateMap<AssetAccountingEventCreateDto, AssetAccountingEvent>().ReverseMap();

            CreateMap<AssetAccountingEventUpdateDto, AssetAccountingEvent>().ReverseMap();
        }
    }
}
