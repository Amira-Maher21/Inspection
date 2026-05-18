using AutoMapper;
using Inspection.Application.Contracts.Dto.AccountingDtos.AccountSystemDto.DefaultAccountAssignment;
using Inspection.Domain.Models.Accounting.AccountingSystem.DefaultAccountAssignment;

namespace Inspection.Application.Mapping.Accounting.AccountSystem
{
    public class DefaultAccountAssignmentMappingProfile : Profile
    {
        public DefaultAccountAssignmentMappingProfile()
        {
            CreateMap<DefaultAccountAssignment, DefaultAccountAssignmentDto>().ReverseMap();

            CreateMap<DefaultAccountAssignmentCreateDto, DefaultAccountAssignment>().ReverseMap();

            CreateMap<DefaultAccountAssignmentUpdateDto, DefaultAccountAssignment>().ReverseMap();
            CreateMap<DefaultAccountAssignmentReturnSearchDto, DefaultAccountAssignment>().ReverseMap();
        }
    }
}


