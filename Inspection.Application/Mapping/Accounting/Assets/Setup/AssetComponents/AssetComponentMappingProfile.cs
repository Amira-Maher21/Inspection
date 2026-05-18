using AutoMapper;
using Inspection.Application.Contracts.Dto.AccountingDtos.Assets.Setup.AssetCategories;
using Inspection.Application.Contracts.Dto.AccountingDtos.Assets.Setup.AssetComponents;
using Inspection.Domain.Models.Accounting.Assets.Setup.AssetCategories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Mapping.Accounting.Assets.Setup.AssetComponents
{
    public class AssetComponentMappingProfile : Profile
    {
        public AssetComponentMappingProfile()
        {

            // -------------------- READ --------------------

            CreateMap<AssetComponent, AssetComponentDto>().ReverseMap();
            CreateMap<AssetComponent, AssetComponentReturnSearchDto>().ReverseMap();

            // -------------------- CREATE --------------------

            CreateMap<AssetComponent, AssetComponentCreateDto>().ReverseMap().ForMember(x => x.Tenant_ID, opt => opt.Ignore());


            // -------------------- UPDATE --------------------

            CreateMap<AssetComponent, AssetComponentUpdateDto>().ReverseMap();

        }
    }
}