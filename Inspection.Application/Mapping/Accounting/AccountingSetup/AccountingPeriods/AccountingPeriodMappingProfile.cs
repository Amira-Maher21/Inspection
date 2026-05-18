using AutoMapper;
using Inspection.Application.Contracts.Dto.AccountingDtos.AccountingSetupDtos.AccountingPeriodDTOs;
using Inspection.Domain.Models.Accounting.AccountingSetup.AccountingPeriods;

namespace Inspection.Application.Mapping.Accounting.AccountingSetup.AccountingPeriods
{
    public class AccountingPeriodMappingProfile : Profile
    {
        public AccountingPeriodMappingProfile()
        {
            CreateMap<AccountingPeriod, AccountingPeriodCreateDto>().ReverseMap().ForMember(x => x.Tenant_ID, opt => opt.Ignore());
            CreateMap<AccountingPeriod, AccountingPeriodUpdateDto>().ReverseMap();
            CreateMap<AccountingPeriod, AccountingPeriodDto>().ReverseMap();
            CreateMap<AccountingPeriod, AccountingPeriodReturnSearchDto>().ReverseMap();
        }
    }
}