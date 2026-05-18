using Inspection.Domain.Models.Accounting.Payment.CreditNotes;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Command.Accounting.Payments.CreditNotes
{
    public interface ICreditNoteCommandRepository : ICommandRepository<CreditNote>
    {
        Task<ReturnBase> DeleteById(long id);

        Task<ReturnBase> DeleteCreditNoteLinesByCreditNoteIds(List<long> ids);
        Task<ReturnBase> DeleteCreditNoteAdjustmentsByCreditNoteIds(List<long> ids);
    }
}