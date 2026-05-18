using AutoMapper;
using Inspection.Application.Contracts.Dto.AccountingDtos.AR.MasterData;
using Inspection.Application.Contracts.Dto.AccountingDtos.AR.MasterData.CustomerContacts;
using Inspection.Domain.Models.Accounting.AR.MasterData;

namespace Inspection.Application.Mapping.Accounting.AR.MasterData
{
    public class CustomerMappingProfile : Profile
    {
        public CustomerMappingProfile()
        {
            CreateMap<CustomerCreateDto, Customer>();
            CreateMap<CustomerReturnSearchDto, Customer>();


            CreateMap<CustomerUpdateDto, Customer>();
            CreateMap<Customer, CustomerDto>()
                .ForMember(dest => dest.CustomerContact, opt => opt.MapFrom(src => src.CustomerContact));



            CreateMap<CustomerContactDto, CustomerContact>();
            CreateMap<CustomerContact, CustomerContactDto>();


            CreateMap<CustomerContactCreateDto, CustomerContact>();
            CreateMap<CustomerContactUpdateDto, CustomerContact>();




        }
    }
}
