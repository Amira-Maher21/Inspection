using AutoMapper;
using Inspection.Application.Contracts.Dto.ContractingDTOs.Setup.SubcontractBOQDTOs;
using Inspection.Application.Contracts.Dto.ContractingDTOs.Setup.SubcontractBOQDTOs.SubcontractBOQLineDTOs;
using Inspection.Domain.Models.Contracting.Setup.SubcontractBOQs;

namespace Inspection.Application.Mapping.Contracting.Setup.SubcontractBOQs
{
    public class SubcontractBOQMappingProfile : Profile
    {
        public SubcontractBOQMappingProfile()
        {
            // -------------------- READ --------------------

            CreateMap<SubcontractBOQ, SubcontractBOQDto>();
            CreateMap<SubcontractBOQLine, SubcontractBOQLineDto>();

            // -------------------- CREATE --------------------

            CreateMap<SubcontractBOQCreateDto, SubcontractBOQ>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.SubcontractBOQLines, opt => opt.Ignore());

            CreateMap<SubcontractBOQLineCreateDto, SubcontractBOQLine>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.SubcontractBOQ, opt => opt.Ignore());

            // -------------------- UPDATE --------------------

            CreateMap<SubcontractBOQUpdateDto, SubcontractBOQ>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.SubcontractBOQLines, opt => opt.Ignore());

            CreateMap<SubcontractBOQLineUpdateDto, SubcontractBOQLine>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.SubcontractBOQ, opt => opt.Ignore());
        }
    }
}