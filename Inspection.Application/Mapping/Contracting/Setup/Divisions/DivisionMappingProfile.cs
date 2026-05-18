using AutoMapper;
using Inspection.Application.Contracts.Dto.ContractingDTOs.Setup.Divisions;
using Inspection.Domain.Models.Contracting.Setup.Divisions;

namespace Inspection.Application.Mapping.Contracting.Setup.Divisions
{
    public class DivisionMappingProfile : Profile
    {
        public DivisionMappingProfile()
        {
            CreateMap<DivisionCreateDto, Division>().ReverseMap();
            CreateMap<DivisionUpdateDto, Division>().ReverseMap();
            CreateMap<Division, DivisionDto>().ReverseMap();
        }
    }
}