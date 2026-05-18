using AutoMapper;
using Inspection.Application.Contracts.Dto.AccountingDtos.Payments.DebitNoteDTOs;
using Inspection.Application.Contracts.Dto.AccountingDtos.Payments.DebitNoteDTOs.DebitNoteAdjustmentDTOs;
using Inspection.Application.Contracts.Dto.AccountingDtos.Payments.DebitNoteDTOs.DebitNoteLineDTOs;
using Inspection.Domain.Models.Accounting.Payment.DebitNotes;

namespace Inspection.Application.Mapping.Accounting.Payemets.DebitNotes
{
    public class DebitNoteMappingProfile : Profile
    {
        public DebitNoteMappingProfile()
        {
            // -------------------- READ --------------------

            CreateMap<DebitNote, DebitNoteDto>();
            CreateMap<DebitNoteLine, DebitNoteLineDto>();
            CreateMap<DebitNoteAdjustment, DebitNoteAdjustmentDto>();

            // -------------------- CREATE --------------------

            CreateMap<DebitNoteCreateDto, DebitNote>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.DebitNoteLines, opt => opt.Ignore())
                .ForMember(d => d.DebitNoteAdjustments, opt => opt.Ignore());

            CreateMap<DebitNoteLineCreateDto, DebitNoteLine>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.DebitNote, opt => opt.Ignore());

            CreateMap<DebitNoteAdjustmentCreateDto, DebitNoteAdjustment>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.DebitNote, opt => opt.Ignore());

            // -------------------- UPDATE --------------------

            CreateMap<DebitNoteUpdateDto, DebitNote>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.DebitNoteLines, opt => opt.Ignore())
                .ForMember(d => d.DebitNoteAdjustments, opt => opt.Ignore());

            CreateMap<DebitNoteLineUpdateDto, DebitNoteLine>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.DebitNote, opt => opt.Ignore());

            CreateMap<DebitNoteAdjustmentUpdateDto, DebitNoteAdjustment>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.DebitNote, opt => opt.Ignore());
        }
    }
}