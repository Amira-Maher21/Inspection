using AutoMapper;
using Inspection.Application.Contracts.Dto.AccountingDtos.AR.MasterData.CustomerGroup;

namespace Inspection.Application.Mapping.Accounting.AR.MasterData.CustomerGroup
{
    public class CustomerGroupMappingProfile : Profile
    {
        public CustomerGroupMappingProfile()
        {
            CreateMap<Domain.Models.Accounting.AR.MasterData.CustomerGroup, CustomerGroupDto>().ReverseMap();

            CreateMap<CustomerGroupCreateDto, Domain.Models.Accounting.AR.MasterData.CustomerGroup>().ReverseMap();

            CreateMap<CustomerGroupUpdateDto, Domain.Models.Accounting.AR.MasterData.CustomerGroup>().ReverseMap();
            CreateMap<CustomerGroupReturnSearchDto, Domain.Models.Accounting.AR.MasterData.CustomerGroup>().ReverseMap();
        }
    }
}

