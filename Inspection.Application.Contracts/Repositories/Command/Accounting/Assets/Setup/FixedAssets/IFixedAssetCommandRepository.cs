using Inspection.Domain.Models.Accounting.Assets.Setup.FixedAssets;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Command.Accounting.Assets.Setup.FixedAssets
{
    public interface IFixedAssetCommandRepository : ICommandRepository<FixedAsset>
    {
        Task<ReturnBase> DeleteById(long id);

    }
}