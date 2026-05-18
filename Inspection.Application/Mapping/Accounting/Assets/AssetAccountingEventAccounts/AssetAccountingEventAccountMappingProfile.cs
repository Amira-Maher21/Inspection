using AutoMapper;
using Inspection.Application.Contracts.Dto.AccountingDtos.Assets.AssetAccountingEventAccounts;
using Inspection.Domain.Models.Accounting.Assets.AssetAccountingEventAccounts;

public class AssetAccountingEventAccountMappingProfile : Profile
{
    public AssetAccountingEventAccountMappingProfile()
    {
        CreateMap<AssetAccountingEventAccount, AssetAccountingEventAccountDto>().ReverseMap();

        CreateMap<AssetAccountingEventAccountCreateDto, AssetAccountingEventAccount>().ReverseMap();

        CreateMap<AssetAccountingEventAccountUpdateDto, AssetAccountingEventAccount>().ReverseMap();
    }
}
