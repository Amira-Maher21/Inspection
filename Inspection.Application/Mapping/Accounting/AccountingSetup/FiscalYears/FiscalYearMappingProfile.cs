using AutoMapper;
using Inspection.Application.Contracts.Dto.AccountingDtos.AccountingSetupDtos.FiscalYearDTOs;
using Inspection.Domain.Models.Accounting.AccountingSetup.FiscalYears;

namespace Inspection.Application.Mapping.Accounting.AccountingSetup.FiscalYears
{
    public class FiscalYearMappingProfile : Profile
    {
        public FiscalYearMappingProfile()
        {
            CreateMap<FiscalYear, FiscalYearCreateDto>().ReverseMap().ForMember(x => x.Tenant_ID, opt => opt.Ignore());
            CreateMap<FiscalYearUpdateDto, FiscalYear>().ReverseMap();
            CreateMap<FiscalYearDto, FiscalYear>().ReverseMap();
        }
    }
}