using Inspection.Domain.Models.Accounting.Assets;
using Inspection.Domain.Models.Accounting.Assets.FixedAssets;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Command.Accounting.Assets.AssetDepreciationSchedules
{
    public interface IAssetDepreciationScheduleCommandRepository : ICommandRepository<AssetDepreciationSchedule>
    {
        Task<ReturnBase> DeleteById(long id);
    }
}

