using Inspection.Domain.Models.Accounting.Assets.AssetTransactions;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Command.Accounting.Assets.AssetTransactions
{
    public interface IAssetTransactionCommandRepository : ICommandRepository<AssetTransaction>
    {
        Task<ReturnBase> DeleteById(long id);

    }
}
