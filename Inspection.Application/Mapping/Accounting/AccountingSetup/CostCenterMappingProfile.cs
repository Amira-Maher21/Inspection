using AutoMapper;
using Inspection.Application.Contracts.Dto.AccountingDtos.AccountingSetupDtos.CostCenterDTOs;
using Inspection.Domain.Models.Accounting.AccountingSetup;

namespace Inspection.Application.Mapping.Accounting.AccountingSetup
{
    public class CostCenterMappingProfile : Profile
    {

        public CostCenterMappingProfile()
        {
            CreateMap<CostCenter, CostCenterDto>().ReverseMap();
            CreateMap<CostCenterCreateDto, CostCenter>().ReverseMap();
            CreateMap<CostCenterUpdateDto, CostCenter>().ReverseMap();
            CreateMap<CostCenterReturnSearchDto, CostCenter>().ReverseMap();
        }

    }
}