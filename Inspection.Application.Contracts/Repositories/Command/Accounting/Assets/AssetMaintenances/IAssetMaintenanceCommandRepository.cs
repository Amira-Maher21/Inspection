using Inspection.Domain.Models.Accounting.Assets.AssetMaintenances;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Command.Accounting.Assets.AssetMaintenances
{
    public interface IAssetMaintenanceCommandRepository : ICommandRepository<AssetMaintenance>
    {
        Task<ReturnBase> DeleteById(long id);
        Task<ReturnBase> DeleteAssetMaintenanceLinesByIds(List<long> ids);
    }
}