using AutoMapper;
using Inspection.Application.Contracts.Dto.AccountingDtos.AccountingSetupDtos.Cashing;
using Inspection.Domain.Models.Accounting.AccountingSetup.Cashing;

namespace Inspection.Application.Mapping.Accounting.AccountingSetup.Cashing
{
    public class CashMappingProfile : Profile
    {
        public CashMappingProfile()
        {
            CreateMap<Cash, CashDto>().ReverseMap();

            CreateMap<CashCreateDto, Cash>().ReverseMap();

            CreateMap<CashUpdateDto, Cash>().ReverseMap();
            CreateMap<CashReturnSearchDto, Cash>().ReverseMap();
        }
    }
}
