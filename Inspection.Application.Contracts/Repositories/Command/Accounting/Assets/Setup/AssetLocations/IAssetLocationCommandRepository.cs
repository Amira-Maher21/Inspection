using Inspection.Domain.Models.Accounting.Assets.Setup.AssetLocations;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Command.Accounting.Assets.Setup.AssetLocations
{

    public interface IAssetLocationCommandRepository : ICommandRepository<AssetLocation>
    {
        Task<ReturnBase> DeleteById(long id);
        Task<bool> HasChildren(long parentId);
    }
}
