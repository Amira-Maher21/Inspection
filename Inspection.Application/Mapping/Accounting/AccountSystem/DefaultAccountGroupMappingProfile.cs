using AutoMapper;
using Inspection.Application.Contracts.Dto.AccountingDtos.AccountSystemDto.DefaultAccountGroup;
using Inspection.Domain.Models.Accounting.AccountingSystem;

namespace Inspection.Application.Mapping.Accounting.AccountSystem
{
    public class DefaultAccountGroupMappingProfile : Profile
    {
        public DefaultAccountGroupMappingProfile()
        {
            CreateMap<DefaultAccountGroup, DefaultAccountGroupDto>().ReverseMap();

            CreateMap<DefaultAccountGroupCreateDto, DefaultAccountGroup>().ReverseMap();

            CreateMap<DefaultAccountGroupUpdateDto, DefaultAccountGroup>().ReverseMap();
        }
    }
}

