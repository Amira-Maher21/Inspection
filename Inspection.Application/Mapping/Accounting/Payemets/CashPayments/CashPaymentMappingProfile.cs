using AutoMapper;
using Inspection.Application.Contracts.Dto.AccountingDtos.Payments.CashPaymentDTOs;
using Inspection.Application.Contracts.Dto.AccountingDtos.Payments.CashPaymentDTOs.CashPaymentAdjustmentDTOs;
using Inspection.Application.Contracts.Dto.AccountingDtos.Payments.CashPaymentDTOs.CashPaymentLineDTOs;
using Inspection.Application.Contracts.Dto.AccountingDtos.Payments.CashPaymentDTOs.PurchaseInvoiceAllocationDTOs;
using Inspection.Domain.Models.Accounting.Payment.CashPayments;

namespace Inspection.Application.Mapping.Accounting.Payemets.CashPayments
{
    public class CashPaymentMappingProfile : Profile
    {
        public CashPaymentMappingProfile()
        {
            // -------------------- READ --------------------

            CreateMap<CashPayment, CashPaymentDto>();
            CreateMap<CashPaymentLine, CashPaymentLineDto>();
            CreateMap<CashPaymentAdjustment, CashPaymentAdjustmentDto>();
            CreateMap<PurchaseInvoiceAllocation, PurchaseInvoiceAllocationDto>();

            // -------------------- CREATE --------------------

            CreateMap<CashPaymentCreateDto, CashPayment>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.CashPaymentLines, opt => opt.Ignore())
                .ForMember(d => d.CashPaymentAdjustments, opt => opt.Ignore())
                .ForMember(d => d.PurchaseInvoiceAllocations, opt => opt.Ignore());

            CreateMap<CashPaymentLineCreateDto, CashPaymentLine>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.CashPayment, opt => opt.Ignore());

            CreateMap<CashPaymentAdjustmentCreateDto, CashPaymentAdjustment>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.CashPayment, opt => opt.Ignore());

            CreateMap<PurchaseInvoiceAllocationCreateDto, PurchaseInvoiceAllocation>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.CashPayment, opt => opt.Ignore());

            // -------------------- UPDATE --------------------

            CreateMap<CashPaymentUpdateDto, CashPayment>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.CashPaymentLines, opt => opt.Ignore())
                .ForMember(d => d.CashPaymentAdjustments, opt => opt.Ignore())
                .ForMember(d => d.PurchaseInvoiceAllocations, opt => opt.Ignore());

            CreateMap<CashPaymentLineUpdateDto, CashPaymentLine>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.CashPayment, opt => opt.Ignore());

            CreateMap<CashPaymentAdjustmentUpdateDto, CashPaymentAdjustment>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.CashPayment, opt => opt.Ignore());

            CreateMap<PurchaseInvoiceAllocationUpdateDto, PurchaseInvoiceAllocation>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.CashPayment, opt => opt.Ignore());
        }
    }
}