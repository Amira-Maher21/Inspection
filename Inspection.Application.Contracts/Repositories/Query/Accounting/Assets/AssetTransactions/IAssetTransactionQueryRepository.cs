using Inspection.Application.Contracts.Dto.AccountingDtos.Assets.AssetTransactions;
using Inspection.Domain.Models.Accounting.Assets.AssetTransactions;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Query.Accounting.Assets.AssetTransactions
{
    public interface IAssetTransactionQueryRepository : IQueryRepository<AssetTransaction>
    {
        Task<AssetTransaction?> GetById(long id);

        Task<ReturnBase<IEnumerable<AssetTransactionReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions);
    }
}
