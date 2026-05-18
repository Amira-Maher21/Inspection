using AutoMapper;
using Inspection.Application.Contracts.Dto.ContractingDTOs.Setup.WBSs;
using Inspection.Domain.Models.Contracting.Setup.WBSs;

namespace Inspection.Application.Mapping.Contracting.Setup.WBSs
{
    public class WBSMappingProfile : Profile
    {
        public WBSMappingProfile()
        {
            CreateMap<WBSCreateDto, WBS>().ReverseMap();
            CreateMap<WBSUpdateDto, WBS>().ReverseMap();
            CreateMap<WBS, WBSDto>().ReverseMap();
        }
    }
}