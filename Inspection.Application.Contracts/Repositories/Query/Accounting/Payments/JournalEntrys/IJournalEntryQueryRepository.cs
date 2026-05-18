using Inspection.Application.Contracts.Dto.AccountingDtos.Payments.JournalEntrys;
using Inspection.Domain.Models.Accounting.Payment.JonrnalEntrys;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Query.Accounting.Payments.JournalEntrys
{

    public interface IJournalEntryQueryRepository : IQueryRepository<JournalEntry>
    {
        Task<JournalEntry?> GetById(long id);
        Task<ReturnBase<IEnumerable<JournalEntrySearchReturnDto>>> Search(SqlQueryOptions sqlQueryOptions);
        Task<JournalEntry?> GetByCode(string code);
        Task<IEnumerable<JournalEntry>> GetUnpostedDocumentsAsync();


    }
}
