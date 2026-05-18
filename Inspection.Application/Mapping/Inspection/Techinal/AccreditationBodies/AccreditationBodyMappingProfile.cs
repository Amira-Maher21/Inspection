using AutoMapper;
using Inspection.Application.Contracts.Dto.InspectionDto.Techinal.AccreditationBodyDTOs;
using Inspection.Application.Contracts.Dto.InspectionDto.Techinal.AccreditationBodyDTOs.AccreditationBodyLineDTOs;
using Inspection.Domain.Models.Inspection.Techinal.AccreditationBodies;

namespace Inspection.Application.Mapping.Inspection.Techinal.AccreditationBodies
{
    public class AccreditationBodyMappingProfile : Profile
    {
        public AccreditationBodyMappingProfile()
        {
            // -------------------- READ --------------------

            CreateMap<AccreditationBody, AccreditationBodyDto>();
            CreateMap<AccreditationBodyLine, AccreditationBodyLineDto>();


            // -------------------- CREATE --------------------

            CreateMap<AccreditationBodyCreateDto, AccreditationBody>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.AccreditationBodyLines, opt => opt.Ignore());

            CreateMap<AccreditationBodyLineCreateDto, AccreditationBodyLine>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.AccreditationBody, opt => opt.Ignore());


            // -------------------- UPDATE --------------------

            CreateMap<AccreditationBodyUpdateDto, AccreditationBody>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.AccreditationBodyLines, opt => opt.Ignore());

            CreateMap<AccreditationBodyLineUpdateDto, AccreditationBodyLine>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.AccreditationBody, opt => opt.Ignore());
        }
    }
}