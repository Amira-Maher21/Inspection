using Inspection.Domain.Models.Accounting.Payment.DebitNotes;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Command.Accounting.Payments.DebitNotes
{
    public interface IDebitNoteCommandRepository : ICommandRepository<DebitNote>
    {
        Task<ReturnBase> DeleteById(long id);

        Task<ReturnBase> DeleteDebitNoteLinesByDebitNoteIds(List<long> ids);
        Task<ReturnBase> DeleteDebitNoteAdjustmentsByDebitNoteIds(List<long> ids);
    }
}