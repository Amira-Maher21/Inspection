using Inspection.Application.Contracts.Dto.Inventory.Transaction.GoodsIssues;
using Inspection.Domain.Models.Inventory.Transaction.GoodsIssues;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Query.Inventory.Transaction.GoodsIssues
{
    public interface IGoodsIssueQueryRepository : IQueryRepository<GoodsIssue>
    {
        Task<GoodsIssue?> GetById(long id);
        Task<GoodsIssue?> GetByCode(string code);
        Task<ReturnBase<IEnumerable<GoodsIssueReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions);
    }
}

