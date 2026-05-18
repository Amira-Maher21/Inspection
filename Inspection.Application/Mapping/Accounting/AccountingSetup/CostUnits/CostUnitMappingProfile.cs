using AutoMapper;
using Inspection.Application.Contracts.Dto.AccountingDtos.AccountingSetupDtos.CostUnitDTOs;
using Inspection.Domain.Models.Accounting.AccountingSetup.CostUnits;

namespace Inspection.Application.Mapping.Accounting.AccountingSetup.CostUnits
{
    public class CostUnitMappingProfile : Profile
    {
        public CostUnitMappingProfile()
        {
            CreateMap<CostUnit, CostUnitCreateDto>().ReverseMap().ForMember(x => x.Tenant_ID, opt => opt.Ignore());
            CreateMap<CostUnitUpdateDto, CostUnit>().ReverseMap();
            CreateMap<CostUnitDto, CostUnit>().ReverseMap();
            //CreateMap<CostUnitReturnSearchDto, CostUnit>().ReverseMap();
        }
    }
}