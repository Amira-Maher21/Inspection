using AutoMapper;
using Inspection.Application.Contracts.Dto.AccountingDtos.AccountSystemDto.PaymentTermDto;
using Inspection.Domain.Models.Accounting.AccountingSystem.PaymentTerms;

namespace Inspection.Application.Mapping.Accounting.AccountSystem.PaymentTerms
{
    public class PaymentTermMappingProfile : Profile
    {
        public PaymentTermMappingProfile()
        {
            CreateMap<PaymentTerm, PaymentTermDto>().ReverseMap();

            CreateMap<PaymentTermCreateDto, PaymentTerm>().ReverseMap();

            CreateMap<PaymentTermUpdateDto, PaymentTerm>().ReverseMap();
        }
    }
}
