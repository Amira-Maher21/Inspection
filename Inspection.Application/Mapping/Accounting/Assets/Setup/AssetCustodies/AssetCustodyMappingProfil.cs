using AutoMapper;
using Inspection.Application.Contracts.Dto.AccountingDtos.Assets.Setup.AssetCustodies;
using Inspection.Application.Contracts.Dto.AccountingDtos.Assets.Setup.AssetCustodies.AssetCustodyLines;
using Inspection.Domain.Models.Accounting.Assets.Setup.AssetCustodies;

namespace Inspection.Application.Mapping.Accounting.Assets.Setup.AssetCustodies
{
    public class AssetCustodyMappingProfil : Profile
    {
        public AssetCustodyMappingProfil()
        {
            // -------------------- READ --------------------

            CreateMap<AssetCustody, AssetCustodyDto>();
            CreateMap<AssetCustodyLine, AssetCustodyLineDto>();

            // -------------------- CREATE --------------------

            CreateMap<AssetCustodyCreateDto, AssetCustody>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.AssetCustodyLines, opt => opt.Ignore());

            CreateMap<AssetCustodyLineCreateDto, AssetCustodyLine>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.AssetCustody, opt => opt.Ignore());

            // -------------------- UPDATE --------------------

            CreateMap<AssetCustodyUpdateDto, AssetCustody>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.AssetCustodyLines, opt => opt.Ignore());

            CreateMap<AssetCustodyLineUpdateDto, AssetCustodyLine>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.AssetCustody, opt => opt.Ignore());
        }
    }
}
