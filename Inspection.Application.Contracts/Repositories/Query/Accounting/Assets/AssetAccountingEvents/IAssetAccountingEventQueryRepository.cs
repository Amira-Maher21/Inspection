using Inspection.Domain.Models.Accounting.Assets.AssetAccountingEvents;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Query.Accounting.Assets.AssetAccountingEvents
{
    public interface IAssetAccountingEventQueryRepository : IQueryRepository<AssetAccountingEvent>
    {
        Task<ReturnBase<List<AssetAccountingEvent>>> GetAll();
        Task<AssetAccountingEvent?> GetById(long id);
        Task<ReturnBase<IEnumerable<AssetAccountingEvent>>> Search(SqlQueryOptions sqlQueryOptions);
    }
}