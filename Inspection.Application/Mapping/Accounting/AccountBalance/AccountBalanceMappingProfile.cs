using AutoMapper;
using Inspection.Application.Contracts.Dto.AccountingDtos.AccountBalance;
using Inspection.Domain.Models.Accounting.AccountBalance;

namespace Inspection.Application.Mapping.Inventory.System.AccountBalances
{

    public class AccountBalanceMappingProfile : Profile
    {

        public AccountBalanceMappingProfile()
        {
            CreateMap<AccountBalanceCreateDto, AccountBalance>();

            CreateMap<AccountBalance, AccountBalanceDto>();

            CreateMap<AccountBalanceUpdateDto, AccountBalance>();
        }


    }
}

