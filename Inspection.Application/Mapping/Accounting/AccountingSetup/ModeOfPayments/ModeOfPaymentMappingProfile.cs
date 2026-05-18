using AutoMapper;
using Inspection.Application.Contracts.Dto.AccountingDtos.AccountingSetupDtos.ModeOfPayments;
using Inspection.Domain.Models.Accounting.AccountingSetup.ModeOfPayments;

namespace Inspection.Application.Mapping.Accounting.AccountingSetup.ModeOfPayments
{
    public class ModeOfPaymentMappingProfile : Profile
    {
        public ModeOfPaymentMappingProfile()
        {
            CreateMap<ModeOfPayment, ModeOfPaymentDto>().ReverseMap();
            CreateMap<ModeOfPayment, ModeOfPaymentCreateDto>().ReverseMap();
            CreateMap<ModeOfPayment, ModeOfPaymentUpdateDto>().ReverseMap();
        }
    }
}
