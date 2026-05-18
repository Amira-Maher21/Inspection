using Inspection.Application.Contracts.Dto.AccountingDtos.Payments.JournalEntrys;
using Inspection.Application.Contracts.Dto.SharedDtos;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Services.Accounting.Payments.JournalEntrys
{

    public interface IJournalEntryService
    {
        // CRUD 
        Task<ReturnBase<JournalEntryDto>> Create(JournalEntryCreateDto dto);
        Task<ReturnBase<JournalEntryDto>> Update(JournalEntryUpdateDto dto);
        Task<ReturnBase<JournalEntryDto>> Delete(long id);

        Task<ReturnBase<JournalEntryDto>> GetById(long id);

        Task<ReturnBase<IEnumerable<JournalEntrySearchReturnDto>>> Search(SqlQueryOptions? queryOptions = null);

        Task<ReturnBase<ImportResultDto>> ImportJournalEntries(ExcelImportRequestDto dto);
        Task<ReturnBase<FileResultDto>> DownloadTemplate();
        //Posting
        Task<ReturnBase> PostJournalEntry(long journalEntryId);




    }
}
