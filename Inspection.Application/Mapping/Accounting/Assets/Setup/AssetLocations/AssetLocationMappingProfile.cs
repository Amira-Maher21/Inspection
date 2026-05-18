using AutoMapper;
using Inspection.Application.Contracts.Dto.AccountingDtos.Assets.Setup.AssetLocations;
using Inspection.Domain.Models.Accounting.Assets.Setup.AssetLocations;

namespace Inspection.Application.Mapping.Accounting.Assets.Setup.AssetLocations
{
    public class AssetLocationMappingProfile : Profile
    {
        public AssetLocationMappingProfile()
        {

            // -------------------- READ --------------------

            CreateMap<AssetLocation, AssetLocationDto>().ReverseMap();

            // -------------------- CREATE --------------------

            CreateMap<AssetLocation, AssetLocationCreateDto>().ReverseMap().ForMember(x => x.Tenant_ID, opt => opt.Ignore());


            // -------------------- UPDATE --------------------

            CreateMap<AssetLocation, AssetLocationUpdateDto>().ReverseMap();



        }
    }
}
