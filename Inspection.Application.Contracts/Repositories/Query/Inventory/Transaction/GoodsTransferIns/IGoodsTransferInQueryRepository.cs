using Inspection.Application.Contracts.Dto.Inventory.Transaction.GoodsTransferInDTOs;
using Inspection.Domain.Models.Inventory.Transaction.GoodsTransferIns;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Query.Inventory.Transaction.GoodsTransferIns
{
    public interface IGoodsTransferInQueryRepository : IQueryRepository<GoodsTransferIn>
    {
        Task<ReturnBase<List<GoodsTransferIn>>> GetAll();
        Task<GoodsTransferIn?> GetById(long id);
        Task<GoodsTransferIn?> GetByGoodsTransferInNumber(string goodsTransferInNumber);
        Task<ReturnBase<IEnumerable<GoodsTransferInReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions);
    }
}