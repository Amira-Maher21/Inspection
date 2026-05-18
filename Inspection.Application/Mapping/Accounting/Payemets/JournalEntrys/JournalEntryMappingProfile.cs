using AutoMapper;
using Inspection.Application.Contracts.Dto.AccountingDtos.Payments.JournalEntryLines;
using Inspection.Application.Contracts.Dto.AccountingDtos.Payments.JournalEntrys;
using Inspection.Domain.Models.Accounting.Payment.JonrnalEntrys;
using Inspection.Domain.Models.Accounting.Payment.JournalEntryLines;

namespace Inspection.Application.Mapping.Accounting.Payemets.JournalEntrys
{

    public class JournalEntryMappingProfile : Profile
    {
        public JournalEntryMappingProfile()
        {


            // Master Table
            CreateMap<JournalEntry, JournalEntryCreateDto>().ReverseMap();
            CreateMap<JournalEntryUpdateDto, JournalEntry>().ReverseMap();
            CreateMap<JournalEntrySearchReturnDto, JournalEntry>().ReverseMap();
            CreateMap<JournalEntry, JournalEntryDto>()
                .ForMember(dest => dest.JournalEntryLines, opt => opt.MapFrom(src => src.JournalEntryLines));



            // Detail Table (Contacts)
            CreateMap<JournalEntryLine, JournalEntryLineCreateDto>().ReverseMap();
            CreateMap<JournalEntryLineUpdateDto, JournalEntryLine>().ReverseMap();
            CreateMap<JournalEntryLine, JournalEntryLineDto>().ReverseMap();




        }
    }
}
