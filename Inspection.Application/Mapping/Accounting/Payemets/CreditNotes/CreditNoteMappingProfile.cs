using AutoMapper;
using Inspection.Application.Contracts.Dto.AccountingDtos.Payments.CreditNoteDTOs;
using Inspection.Application.Contracts.Dto.AccountingDtos.Payments.CreditNoteDTOs.CreditNoteAdjustmentDTOs;
using Inspection.Application.Contracts.Dto.AccountingDtos.Payments.CreditNoteDTOs.CreditNoteLineDTOs;
using Inspection.Domain.Models.Accounting.Payment.CreditNotes;

namespace Inspection.Application.Mapping.Accounting.Payemets.CreditNotes
{
    public class CreditNoteMappingProfile : Profile
    {
        public CreditNoteMappingProfile()
        {
            // -------------------- READ --------------------

            CreateMap<CreditNote, CreditNoteDto>();
            CreateMap<CreditNoteLine, CreditNoteLineDto>();
            CreateMap<CreditNoteAdjustment, CreditNoteAdjustmentDto>();

            // -------------------- CREATE --------------------

            CreateMap<CreditNoteCreateDto, CreditNote>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.CreditNoteLines, opt => opt.Ignore())
                .ForMember(d => d.CreditNoteAdjustments, opt => opt.Ignore());

            CreateMap<CreditNoteLineCreateDto, CreditNoteLine>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.CreditNote, opt => opt.Ignore());

            CreateMap<CreditNoteAdjustmentCreateDto, CreditNoteAdjustment>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.CreditNote, opt => opt.Ignore());

            // -------------------- UPDATE --------------------

            CreateMap<CreditNoteUpdateDto, CreditNote>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.CreditNoteLines, opt => opt.Ignore())
                .ForMember(d => d.CreditNoteAdjustments, opt => opt.Ignore());

            CreateMap<CreditNoteLineUpdateDto, CreditNoteLine>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.CreditNote, opt => opt.Ignore());

            CreateMap<CreditNoteAdjustmentUpdateDto, CreditNoteAdjustment>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.CreditNote, opt => opt.Ignore());
        }
    }
}