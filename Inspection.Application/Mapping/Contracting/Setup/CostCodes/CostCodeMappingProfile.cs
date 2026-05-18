using AutoMapper;
using Inspection.Application.Contracts.Dto.ContractingDTOs.Setup.CostCodes;
using Inspection.Domain.Models.Contracting.Setup.CostCodes;

namespace Inspection.Application.Mapping.Contracting.Setup.CostCodes
{
    public class CostCodeMappingProfile : Profile
    {
        public CostCodeMappingProfile()
        {
            CreateMap<CostCodeCreateDto, CostCode>().ReverseMap();
            CreateMap<CostCodeUpdateDto, CostCode>().ReverseMap();
            CreateMap<CostCode, CostCodeDto>().ReverseMap();
        }
    }
}