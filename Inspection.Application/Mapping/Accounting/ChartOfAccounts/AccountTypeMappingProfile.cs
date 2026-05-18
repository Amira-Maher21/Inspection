using AutoMapper;
using Inspection.Application.Contracts.Dto.AccountingDtos.ChartOfAccounts.AccountTypeDTOs;
using Inspection.Domain.Models.Accounting.ChartOfAccounts;

namespace Inspection.Application.Mapping.Accounting.ChartOfAccounts
{
    public class AccountTypeMappingProfile : Profile
    {
        public AccountTypeMappingProfile()
        {
            CreateMap<AccountType, AcountTypeDto>().ReverseMap();
        }
    }
}
