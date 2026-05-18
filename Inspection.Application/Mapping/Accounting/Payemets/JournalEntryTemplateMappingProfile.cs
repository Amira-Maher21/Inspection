using AutoMapper;
using Inspection.Application.Contracts.Dto.AccountingDtos.Payments.JournalEntryTemplateLines;
using Inspection.Application.Contracts.Dto.AccountingDtos.Payments.JournalEntryTemplates;
using Inspection.Domain.Models.Accounting.Payment.JournalEntryTemplates;

namespace Inspection.Application.Mapping.Accounting.Payemets
{
    public class JournalEntryTemplateMappingProfile : Profile
    {
        public JournalEntryTemplateMappingProfile()
        {

            CreateMap<JournalEntryTemplate, JournalEntryTemplateDto>();
            CreateMap<JournalEntryTemplateLine, JournalEntryTemplateLineDto>();


            CreateMap<JournalEntryTemplateCreateDto, JournalEntryTemplate>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.JournalEntryTemplateLines, opt => opt.Ignore());

            CreateMap<JournalEntryTemplateLineCreateDto, JournalEntryTemplateLine>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.JournalEntryTemplate, opt => opt.Ignore());


            CreateMap<JournalEntryTemplateUpdateDto, JournalEntryTemplate>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.JournalEntryTemplateLines, opt => opt.Ignore());

            CreateMap<JournalEntryTemplateLineUpdateDto, JournalEntryTemplateLine>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.JournalEntryTemplate, opt => opt.Ignore());
        }
    }
}
