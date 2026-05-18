using AutoMapper;
using Inspection.Application.Contracts.Dto.AccountingDtos.PR.PurchaseInvoices;
using Inspection.Application.Contracts.Dto.AccountingDtos.PR.PurchaseInvoices.PurchaseInvoiceAdjustments;
using Inspection.Application.Contracts.Dto.AccountingDtos.PR.PurchaseInvoices.PurchaseInvoiceLines;
using Inspection.Domain.Models.Accounting.PR.PurchaseInvoices;

namespace Inspection.Application.Mapping.Accounting.PR.PurchaseInvoices
{
    public class PurchaseInvoiceMappingProfile : Profile
    {
        public PurchaseInvoiceMappingProfile()
        {
            // ==================== READ ====================

            CreateMap<PurchaseInvoice, PurchaseInvoiceDto>();

            CreateMap<PurchaseInvoiceLine, PurchaseInvoiceLineDto>();
            CreateMap<PurchaseInvoiceAdjustment, PurchaseInvoiceAdjustmentDto>();


            // ==================== CREATE ====================

            CreateMap<PurchaseInvoiceCreateDto, PurchaseInvoice>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.InvoiceLines, opt => opt.Ignore())
                .ForMember(d => d.Adjustments, opt => opt.Ignore());

            CreateMap<PurchaseInvoiceLineCreateDto, PurchaseInvoiceLine>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.PurchaseInvoice, opt => opt.Ignore());

            CreateMap<PurchaseInvoiceAdjustmentCreateDto, PurchaseInvoiceAdjustment>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.PurchaseInvoice, opt => opt.Ignore());


            // ==================== UPDATE ====================

            CreateMap<PurchaseInvoiceUpdateDto, PurchaseInvoice>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.InvoiceLines, opt => opt.Ignore())
                .ForMember(d => d.Adjustments, opt => opt.Ignore());

            CreateMap<PurchaseInvoiceLineUpdateDto, PurchaseInvoiceLine>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.PurchaseInvoice, opt => opt.Ignore());

            CreateMap<PurchaseInvoiceAdjustmentUpdateDto, PurchaseInvoiceAdjustment>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.PurchaseInvoice, opt => opt.Ignore());
        }
    }
}