using Inspection.Application.Contracts.Dto.Inventory.Transaction.GoodsTransferOutDTOs;
using Inspection.Domain.Models.Inventory.Transaction.GoodsTransferOuts;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Query.Inventory.Transaction.GoodsTransferOuts
{
    public interface IGoodsTransferOutQueryRepository : IQueryRepository<GoodsTransferOut>
    {
        Task<ReturnBase<List<GoodsTransferOut>>> GetAll();
        Task<GoodsTransferOut?> GetById(long id);
        Task<GoodsTransferOut?> GetByGoodsTransferOutNumber(string goodsTransferOutNumber);
        Task<ReturnBase<IEnumerable<GoodsTransferOutReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions);
    }
}