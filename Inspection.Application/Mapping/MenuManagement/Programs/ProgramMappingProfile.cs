using AutoMapper;
using Inspection.Application.Contracts.Dto.MenuManagement.Programs;
using Inspection.Domain.Models.MenuManagement;

namespace Inspection.Application.Mapping.MenuManagement.Programs
{

    public class ProgramMappingProfile : Profile
    {
        public ProgramMappingProfile()
        {
            CreateMap<Program, ProgramDto>().ReverseMap();

        }
    }
}
