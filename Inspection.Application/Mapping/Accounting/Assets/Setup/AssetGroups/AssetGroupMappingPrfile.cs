using AutoMapper;
using Inspection.Application.Contracts.Dto.AccountingDtos.Assets.Setup.AssetGroupDTOs;
using Inspection.Domain.Models.Accounting.Assets.Setup.AssetGroups;

namespace Inspection.Application.Mapping.Accounting.Assets.Setup.AssetGroups
{
    public class AssetGroupMappingPrfile : Profile
    {
        public AssetGroupMappingPrfile()
        {


            // -------------------- READ --------------------

            CreateMap<AssetGroup, AssetGroupDto>();


            // -------------------- CREATE --------------------

            CreateMap<AssetGroupCreateDto, AssetGroup>()
                .ForMember(d => d.Id, opt => opt.Ignore());



            // -------------------- UPDATE --------------------

            CreateMap<AssetGroupUpdateDto, AssetGroup>()
          .ForMember(d => d.Id, opt => opt.Ignore());
        }
    }
}
