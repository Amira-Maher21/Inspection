using AutoMapper;
using Inspection.Application.Contracts.Dto.ContractingDTOs.Setup.CommitmentDTOs;
using Inspection.Application.Contracts.Dto.ContractingDTOs.Setup.CommitmentDTOs.CommitmentLineDTOs;
using Inspection.Domain.Models.Contracting.Setup.Commitment;

namespace Inspection.Application.Mapping.Contracting.Setup.Commitments
{
    public class CommitmentMappingProfile : Profile
    {
        public CommitmentMappingProfile()
        {
            // -------------------- READ --------------------

            CreateMap<Commitment, CommitmentDto>();
            CreateMap<CommitmentLine, CommitmentLineDto>();

            // -------------------- CREATE --------------------

            CreateMap<CommitmentCreateDto, Commitment>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.CommitmentLines, opt => opt.Ignore());

            CreateMap<CommitmentLineCreateDto, CommitmentLine>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.Commitment, opt => opt.Ignore());

            // -------------------- UPDATE --------------------

            CreateMap<CommitmentUpdateDto, Commitment>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.CommitmentLines, opt => opt.Ignore());

            CreateMap<CommitmentLineUpdateDto, CommitmentLine>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.Commitment, opt => opt.Ignore());
        }
    }
}