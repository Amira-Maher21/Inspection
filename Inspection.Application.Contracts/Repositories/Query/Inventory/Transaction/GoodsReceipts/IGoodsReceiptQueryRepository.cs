using Inspection.Application.Contracts.Dto.Inventory.Transaction.GoodsReceipts;
using Inspection.Domain.Models.Inventory.Transaction.GoodsReceipts;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Query.Inventory.Transaction.GoodsReceipts
{
    public interface IGoodsReceiptQueryRepository
        : IQueryRepository<GoodsReceipt>
    {
        Task<ReturnBase<List<GoodsReceipt>>> GetAll();
        Task<GoodsReceipt?> GetById(long id);
        Task<ReturnBase<IEnumerable<GoodsReceiptReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions);
    }
}