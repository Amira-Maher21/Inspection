using Inspection.Application.Contracts.Dto.AccountingDtos.Payments.JournalEntryTemplates;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Services.Accounting.Payments
{
    public interface IJournalEntryTemplateService
    {
        Task<ReturnBase<JournalEntryTemplateDto>> Create(JournalEntryTemplateCreateDto createDto);
        Task<ReturnBase<JournalEntryTemplateDto>> Update(JournalEntryTemplateUpdateDto updateDto);
        Task<ReturnBase<JournalEntryTemplateDto>> Delete(long id);
        Task<ReturnBase<JournalEntryTemplateDto>> GetById(long id);

        Task<ReturnBase<IEnumerable<JournalEntryTemplateSearchReturnDto>>> Search(SqlQueryOptions sqlQueryOptions);
    }
}
