using Inspection.Application.Contracts.Dto.AccountingDtos.Payments.JournalEntryTemplates;
using Inspection.Domain.Models.Accounting.Payment.JournalEntryTemplates;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Query.Accounting.Payments
{
    public interface IJournalEntryTemplateQueryRepository : IQueryRepository<JournalEntryTemplate>
    {
        Task<ReturnBase<List<JournalEntryTemplate>>> GetAll();
        Task<JournalEntryTemplate?> GetById(long id);
        Task<ReturnBase<IEnumerable<JournalEntryTemplateSearchReturnDto>>> Search(SqlQueryOptions sqlQueryOptions);
        Task<JournalEntryTemplate?> GetByNumber(string Number);
    }
}
