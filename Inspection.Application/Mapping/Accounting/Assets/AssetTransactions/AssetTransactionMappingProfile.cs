using AutoMapper;
using Inspection.Application.Contracts.Dto.AccountingDtos.Assets.AssetTransactions;
using Inspection.Domain.Models.Accounting.Assets.AssetTransactions;

namespace Inspection.Application.Mapping.Accounting.Assets.AssetTransactions
{
    public class AssetTransactionMappingProfile : Profile
    {
        public AssetTransactionMappingProfile()
        {
            //  CreateMap<AssetTransaction, AssetTransactionCreateDto>().ReverseMap()/*.ForMember(x => x.Tenant_ID, opt => opt.Ignore()*/;
            CreateMap<AssetTransaction, AssetTransactionUpdateDto>().ReverseMap();
            CreateMap<AssetTransaction, AssetTransactionDto>().ReverseMap();




            CreateMap<AssetTransactionCreateDto, AssetTransaction>();
            CreateMap<AssetTransactionReturnSearchDto, AssetTransaction>();

        }


    }
}
