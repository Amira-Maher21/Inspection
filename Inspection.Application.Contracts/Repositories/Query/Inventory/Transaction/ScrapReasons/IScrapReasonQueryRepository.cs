using Inspection.Application.Contracts.Dto.Inventory.Transaction.ScrapReasons;
using Inspection.Domain.Models.Inventory.Transaction.ScrapReasons;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Query.Inventory.Transaction.ScrapReasons
{
    public interface IScrapReasonQueryRepository : IQueryRepository<ScrapReason>
    {
        Task<ScrapReason?> GetById(long id);
        Task<ScrapReason?> GetByCode(string code);
        Task<ReturnBase<IEnumerable<ScrapReasonReturnSearchDto>>> Search(SqlQueryOptions options);
    }
}