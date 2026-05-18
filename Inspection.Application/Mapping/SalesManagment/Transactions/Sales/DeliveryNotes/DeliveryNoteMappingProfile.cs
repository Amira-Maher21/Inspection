using AutoMapper;
using Inspection.Application.Contracts.Dto.SalesManagment.sales.Transactions.DeliveryNoteLines;
using Inspection.Application.Contracts.Dto.SalesManagment.sales.Transactions.DeliveryNotes;
using Inspection.Domain.Models.SalesManagment.Transaction.DeliveryNotes;

namespace Inspection.Application.Mapping.SalesManagment.Transactions.Sales.DeliveryNotes
{
    public class DeliveryNoteMappingProfile : Profile
    {
        public DeliveryNoteMappingProfile()
        {
            // -------------------- READ --------------------

            CreateMap<DeliveryNote, DeliveryNoteDto>();
            CreateMap<DeliveryNoteLine, DeliveryNoteLineDto>();


            // -------------------- CREATE --------------------

            CreateMap<DeliveryNoteCreateDto, DeliveryNote>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.DeliveryNoteLines, opt => opt.Ignore());

            CreateMap<DeliveryNoteLineCreateDto, DeliveryNoteLine>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.DeliveryNote, opt => opt.Ignore());


            // -------------------- UPDATE --------------------

            CreateMap<DeliveryNoteUpdateDto, DeliveryNote>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.DeliveryNoteLines, opt => opt.Ignore());

            CreateMap<DeliveryNoteLineUpdateDto, DeliveryNoteLine>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.DeliveryNote, opt => opt.Ignore());
        }
    }
}