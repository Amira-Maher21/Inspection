using AutoMapper;
using Inspection.Application.Contracts.Dto.AccountingDtos.AR.SalesInvoiceLines;
using Inspection.Application.Contracts.Dto.AccountingDtos.AR.SalesInvoices;
using Inspection.Application.Contracts.Dto.AccountingDtos.AR.SalesInvoiceSalesAdjustments;
using Inspection.Application.Contracts.Dto.AccountingDtos.AR.SalesInvoiceSalesPersons;
using Inspection.Domain.Models.Accounting.AR.SalesInvoices;

namespace Inspection.Application.Mapping.Accounting.AR.SalesInvoices
{

    public class SalesInvoiceMappingProfile : Profile
    {
        public SalesInvoiceMappingProfile()
        {
            // -------------------- READ --------------------

            CreateMap<SalesInvoice, SalesInvoiceDto>();

            CreateMap<SalesInvoiceLine, SalesInvoiceLineDto>();
            CreateMap<SalesInvoiceSalesAdjustment, SalesInvoiceSalesAdjustmentDto>();
            CreateMap<SalesInvoiceSalesPerson, SalesInvoiceSalesPersonDto>();


            // -------------------- CREATE --------------------

            CreateMap<SalesInvoiceCreateDto, SalesInvoice>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.SalesInvoiceLines, opt => opt.Ignore())
                .ForMember(d => d.SalesInvoiceSalesAdjustments, opt => opt.Ignore())
                .ForMember(d => d.SalesInvoiceSalesPersons, opt => opt.Ignore());

            CreateMap<SalesInvoiceLineCreateDto, SalesInvoiceLine>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.SalesInvoice, opt => opt.Ignore());

            CreateMap<SalesInvoiceSalesAdjustmentCreateDto, SalesInvoiceSalesAdjustment>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.SalesInvoice, opt => opt.Ignore());

            CreateMap<SalesInvoiceSalesPersonCreateDto, SalesInvoiceSalesPerson>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.SalesInvoice, opt => opt.Ignore());


            // -------------------- UPDATE --------------------

            CreateMap<SalesInvoiceUpdateDto, SalesInvoice>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.SalesInvoiceLines, opt => opt.Ignore())
                .ForMember(d => d.SalesInvoiceSalesAdjustments, opt => opt.Ignore())
                .ForMember(d => d.SalesInvoiceSalesPersons, opt => opt.Ignore());

            CreateMap<SalesInvoiceLineUpdateDto, SalesInvoiceLine>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.SalesInvoice, opt => opt.Ignore());

            CreateMap<SalesInvoiceSalesAdjustmentUpdateDto, SalesInvoiceSalesAdjustment>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.SalesInvoice, opt => opt.Ignore());

            CreateMap<SalesInvoiceSalesPersonUpdateDto, SalesInvoiceSalesPerson>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.SalesInvoice, opt => opt.Ignore());
        }
    }
}