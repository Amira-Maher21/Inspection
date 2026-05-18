using AutoMapper;
using Inspection.Application.Contracts.Dto.AccountingDtos.AccountingSetupDtos.BankAccountDTOs;
using Inspection.Domain.Models.Accounting.AccountingSetup.BankAccounts;

namespace Inspection.Application.Mapping.Accounting.AccountingSetup.BankAccounts
{
    public class BankAccountMappingProfile : Profile
    {
        public BankAccountMappingProfile()
        {

            CreateMap<BankAccount, BankAccountDto>();


            CreateMap<BankAccountCreateDto, BankAccount>();
            CreateMap<BankAccountUpdateDto, BankAccount>();
            CreateMap<BankAccountReturnSearchDto, BankAccount>();

        }
    }


}
