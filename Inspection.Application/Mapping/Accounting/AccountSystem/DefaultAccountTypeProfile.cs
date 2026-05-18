using AutoMapper;
using Inspection.Application.Contracts.Dto.AccountingDtos.AccountSystemDto.DefaultAccountTypeDto;
using Inspection.Domain.Models.Accounting.AccountingSystem;

namespace Inspection.Application.Mapping.Accounting.AccountSystem
{
    public class DefaultAccountTypeProfile : Profile
    {
        public DefaultAccountTypeProfile()
        {
            CreateMap<DefaultAccountType, DefaultAccountTypeDto>().ReverseMap();

            CreateMap<DefaultAccountTypeCreateDto, DefaultAccountType>().ReverseMap();

            CreateMap<DefaultAccountTypeUpdateDto, DefaultAccountType>().ReverseMap();
            CreateMap<DefaultAccountTypeReturnSearchDto, DefaultAccountType>().ReverseMap();
        }
    }
}
