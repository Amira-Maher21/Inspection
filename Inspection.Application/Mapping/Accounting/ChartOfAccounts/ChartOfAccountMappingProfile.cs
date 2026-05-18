using AutoMapper;
using Inspection.Application.Contracts.Dto.AccountingDtos.ChartOfAccounts.ChartOfAccountDTOs;
using Inspection.Domain.Models.Accounting.ChartOfAccounts;

namespace Inspection.Application.Mapping.Accounting.ChartOfAccounts
{
    internal class ChartOfAccountMappingProfile : Profile
    {
        public ChartOfAccountMappingProfile()
        {
            CreateMap<ChartOfAccount, ChartOfAccountCreateDto>().ReverseMap().ForMember(x => x.Tenant_ID, opt => opt.Ignore());
            CreateMap<ChartOfAccount, ChartOfAccountUpdateDto>().ReverseMap();
            CreateMap<ChartOfAccount, ChartOfAccountDto>().ReverseMap();
            CreateMap<ChartOfAccount, ChartOfAccountReturnSearchDto>().ReverseMap();
        }
    }
}

