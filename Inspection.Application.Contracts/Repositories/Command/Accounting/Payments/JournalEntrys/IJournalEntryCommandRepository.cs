using Inspection.Domain.Models.Accounting.Payment.JonrnalEntrys;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Command.Accounting.Payments.JournalEntrys
{

    public interface IJournalEntryCommandRepository : ICommandRepository<JournalEntry>
    {
        Task<ReturnBase> DeleteById(long id);


        // Delete related entities
        Task<ReturnBase> DeleteJournalEntryLineByJournalEntryId(long supplierId);
        Task<ReturnBase> DeleteJournalEntryLineByIds(List<long> ids);
    }
}
