using AutoMapper;
using Inspection.Application.Contracts.Dto.AccountingDtos.Assets.AssetDepreciationSchedules;
using Inspection.Domain.Models.Accounting.Assets;
using Inspection.Domain.Models.Accounting.Assets.FixedAssets;

namespace Inspection.Application.Mapping.Accounting.Assets.AssetDepreciationSchedules
{
    public class AssetDepreciationScheduleMappingProfile : Profile
    {
        public AssetDepreciationScheduleMappingProfile()
        {
            CreateMap<AssetDepreciationSchedule, AssetDepreciationScheduleDto>().ReverseMap();

            CreateMap<AssetDepreciationScheduleCreateDto, AssetDepreciationSchedule>().ReverseMap();

            CreateMap<AssetDepreciationScheduleUpdateDto, AssetDepreciationSchedule>().ReverseMap();
            CreateMap<AssetDepreciationScheduleReturnSearchDto, AssetDepreciationSchedule>().ReverseMap();
        }
    }
}
