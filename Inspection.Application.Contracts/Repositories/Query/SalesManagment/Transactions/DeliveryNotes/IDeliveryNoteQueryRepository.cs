using Inspection.Application.Contracts.Dto.SalesManagment.sales.Transactions.DeliveryNotes;
using Inspection.Domain.Models.SalesManagment.Transaction.DeliveryNotes;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Query.SalesManagment.Transactions.DeliveryNotes
{

    public interface IDeliveryNoteQueryRepository
    {
        Task<DeliveryNote?> GetById(long id);
        Task<ReturnBase<IEnumerable<DeliveryNoteReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions);
        Task<DeliveryNote?> GetByCode(string code);



    }
}
