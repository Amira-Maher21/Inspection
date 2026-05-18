using Inspection.Domain.Models.Inventory.Transaction.GoodsIssues;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Command.Inventory.Transaction.GoodsIssues
{
    public interface IGoodsIssueCommandRepository : ICommandRepository<GoodsIssue>
    {
        Task<ReturnBase> DeleteById(long id);
        Task<ReturnBase> DeleteGoodsIssueLineByGoodsIssueId(long goodsIssueId);
        Task<ReturnBase> DeleteGoodsIssueLineByIds(List<long> ids);
    }
}