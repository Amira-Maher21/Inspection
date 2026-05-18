using Inspection.Domain.Models.SalesManagment.Transaction.DeliveryNotes;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Command.SalesManagment.sales.DeliveryNotes
{

    public interface IDeliveryNoteCommandRepository : ICommandRepository<DeliveryNote>
    {
        Task<ReturnBase> DeleteById(long Id);


        // ===== Delivery Note  Lines =====
        Task<ReturnBase> DeleteDeliveryNoteLinesByDeliveryNoteId(long DeliveryNoteId);
        Task<ReturnBase> DeleteDeliveryNoteLinesByIds(List<long> ids);





    }
}
