using AutoMapper;
using Inspection.Application.Contracts.Dto.ContractingDTOs.Setup.BOQDTOs;
using Inspection.Application.Contracts.Dto.ContractingDTOs.Setup.BOQDTOs.BOQLineDTOs;
using Inspection.Domain.Models.Contracting.Setup.BOQs;

namespace Inspection.Application.Mapping.Contracting.Setup.BOQs
{
    public class BOQMappingProfile : Profile
    {
        public BOQMappingProfile()
        {
            // -------------------- READ --------------------

            CreateMap<BOQ, BOQDto>();
            CreateMap<BOQLine, BOQLineDto>();

            // -------------------- CREATE --------------------

            CreateMap<BOQCreateDto, BOQ>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.BOQLines, opt => opt.Ignore());

            CreateMap<BOQLineCreateDto, BOQLine>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.BOQ, opt => opt.Ignore());

            // -------------------- UPDATE --------------------

            CreateMap<BOQUpdateDto, BOQ>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.BOQLines, opt => opt.Ignore());

            CreateMap<BOQLineUpdateDto, BOQLine>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.BOQ, opt => opt.Ignore());
        }
    }
}