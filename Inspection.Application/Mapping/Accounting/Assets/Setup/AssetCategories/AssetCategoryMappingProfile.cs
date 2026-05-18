using AutoMapper;
using Inspection.Application.Contracts.Dto.AccountingDtos.Assets.Setup.AssetCategories;
using Inspection.Domain.Models.Accounting.Assets.Setup.AssetCategories;

namespace Inspection.Application.Mapping.Accounting.Assets.Setup.AssetCategories
{
    public class AssetCategoryMappingProfile : Profile
    {
        public AssetCategoryMappingProfile()
        {

            // -------------------- READ --------------------

            CreateMap<AssetCategory, AssetCategoryDto>().ReverseMap();

            // -------------------- CREATE --------------------

            CreateMap<AssetCategory, AssetCategoryCreateDto>().ReverseMap().ForMember(x => x.Tenant_ID, opt => opt.Ignore());


            // -------------------- UPDATE --------------------

            CreateMap<AssetCategory, AssetCategoryUpdateDto>().ReverseMap();



        }
    }
}
