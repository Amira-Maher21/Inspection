using Inspection.Domain.Models.Accounting.Assets.AssetAccountingEventAccounts;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Query.Accounting.Assets.AssetAccountingEventAccounts
{
    public interface IAssetAccountingEventAccountQueryRepository : IQueryRepository<AssetAccountingEventAccount>
    {
        Task<ReturnBase<List<AssetAccountingEventAccount>>> GetAll();
        Task<AssetAccountingEventAccount?> GetById(long id);
        Task<ReturnBase<IEnumerable<AssetAccountingEventAccount>>> Search(SqlQueryOptions sqlQueryOptions);
    }
}