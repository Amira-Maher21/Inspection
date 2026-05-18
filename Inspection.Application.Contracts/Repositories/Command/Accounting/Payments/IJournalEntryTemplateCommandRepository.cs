using Inspection.Domain.Models.Accounting.Payment.JournalEntryTemplates;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Command.Accounting.Payments
{
    public interface IJournalEntryTemplateCommandRepository : ICommandRepository<JournalEntryTemplate>
    {
        Task<ReturnBase> DeleteById(long id);
        Task<ReturnBase> DeleteDetailsByJournalEntryTemplateId(long journalEntryTemplateId);
        Task<ReturnBase> DeleteDetailsByIds(List<long> ids);

    }
}