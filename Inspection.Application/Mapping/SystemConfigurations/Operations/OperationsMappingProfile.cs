using AutoMapper;
using Inspection.Application.Contracts.Dto.SystemConfigurationDTOs.OperationDTOs;
using Inspection.Domain.Models.SystemConfigurations.Operations;

namespace Inspection.Application.Mapping.SystemConfigurations.Operations
{
    public class OperationsMappingProfile : Profile
    {
        public OperationsMappingProfile()
        {
            CreateMap<Operation, OperationCreateDto>().ReverseMap();
            CreateMap<OperationUpdateDto, Operation>().ReverseMap();
            CreateMap<OperationDto, Operation>().ReverseMap();
        }
    }

}
