using AutoMapper;
using Inspection.Application.Contracts.Dto.AccountingDtos.Assets.Setup.FixedAssetDTOs;
using Inspection.Domain.Models.Accounting.Assets.Setup.FixedAssets;

namespace Inspection.Application.Mapping.Accounting.Assets.Setup.FixedAssets
{
    public class FixedAssetMappingProfile : Profile
    {
        public FixedAssetMappingProfile()
        {
            CreateMap<FixedAsset, FixedAssetCreateDto>().ReverseMap().ForMember(x => x.Tenant_ID, opt => opt.Ignore());
            CreateMap<FixedAsset, FixedAssetUpdateDto>().ReverseMap();
            CreateMap<FixedAsset, FixedAssetDto>().ReverseMap();
            CreateMap<FixedAsset, FixedAssetReturnSearchDto>().ReverseMap();
        }
    }
}