using Inspection.Domain.Models.Accounting.Assets.Setup.AssetCategories;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Command.Accounting.Assets.Setup.AssetComponents
{
    public interface IAssetComponentCommandRepository : ICommandRepository<AssetComponent>
    {
        Task<ReturnBase> DeleteById(long id);

    }
}
