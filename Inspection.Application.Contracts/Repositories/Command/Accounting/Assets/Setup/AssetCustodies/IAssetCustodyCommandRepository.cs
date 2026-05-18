using Inspection.Domain.Models.Accounting.Assets.Setup.AssetCustodies;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Command.Accounting.Assets.Setup.AssetCustodies
{
    public interface IAssetCustodyCommandRepository : ICommandRepository<AssetCustody>
    {
        Task<ReturnBase> DeleteById(long id);

        Task<ReturnBase> DeleteAssetCustodyLinesByAssetCustodyIds(List<long> ids);
    }
}
