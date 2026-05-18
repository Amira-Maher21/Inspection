using Inspection.Domain.Models.Accounting.Assets.AssetAccountingEventAccounts;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Command.Accounting.Assets.AssetAccountingEventAccounts
{
    public interface IAssetAccountingEventAccountCommandRepository : ICommandRepository<AssetAccountingEventAccount>
    {
        Task<ReturnBase> DeleteById(long id);

    }
}