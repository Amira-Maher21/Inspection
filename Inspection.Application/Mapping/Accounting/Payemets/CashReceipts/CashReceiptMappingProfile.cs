using AutoMapper;
using Inspection.Application.Contracts.Dto.AccountingDtos.Payments.CashReceiptDTOs;
using Inspection.Application.Contracts.Dto.AccountingDtos.Payments.CashReceiptDTOs.CashReceiptAdjustmentDTOs;
using Inspection.Application.Contracts.Dto.AccountingDtos.Payments.CashReceiptDTOs.CashReceiptLineDTOs;
using Inspection.Application.Contracts.Dto.AccountingDtos.Payments.CashReceiptDTOs.SalesInvoiceAllocationDTOs;
using Inspection.Domain.Models.Accounting.Payment.CashReceipts;

namespace Inspection.Application.Mapping.Accounting.Payemets.CashReceipts
{
    public class CashReceiptMappingProfile : Profile
    {
        public CashReceiptMappingProfile()
        {
            // -------------------- READ --------------------

            CreateMap<CashReceipt, CashReceiptDto>();
            CreateMap<CashReceiptLine, CashReceiptLineDto>();
            CreateMap<CashReceiptAdjustment, CashReceiptAdjustmentDto>();
            CreateMap<SalesInvoiceAllocation, SalesInvoiceAllocationDto>();

            // -------------------- CREATE --------------------

            CreateMap<CashReceiptCreateDto, CashReceipt>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.CashReceiptLines, opt => opt.Ignore())
                .ForMember(d => d.CashReceiptAdjustments, opt => opt.Ignore())
                .ForMember(d => d.SalesInvoiceAllocations, opt => opt.Ignore());

            CreateMap<CashReceiptLineCreateDto, CashReceiptLine>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.CashReceipt, opt => opt.Ignore());

            CreateMap<CashReceiptAdjustmentCreateDto, CashReceiptAdjustment>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.CashReceipt, opt => opt.Ignore());

            CreateMap<SalesInvoiceAllocationCreateDto, SalesInvoiceAllocation>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.CashReceipt, opt => opt.Ignore());

            // -------------------- UPDATE --------------------

            CreateMap<CashReceiptUpdateDto, CashReceipt>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.CashReceiptLines, opt => opt.Ignore())
                .ForMember(d => d.CashReceiptAdjustments, opt => opt.Ignore())
                .ForMember(d => d.SalesInvoiceAllocations, opt => opt.Ignore());

            CreateMap<CashReceiptLineUpdateDto, CashReceiptLine>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.CashReceipt, opt => opt.Ignore());

            CreateMap<CashReceiptAdjustmentUpdateDto, CashReceiptAdjustment>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.CashReceipt, opt => opt.Ignore());

            CreateMap<SalesInvoiceAllocationUpdateDto, SalesInvoiceAllocation>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.CashReceipt, opt => opt.Ignore());
        }
    }
}