using Inspection.Domain.Models.Accounting.Assets.AssetAccountingEvents;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Command.Accounting.Assets.AssetAccountingEvents
{
    public interface IAssetAccountingEventCommandRepository : ICommandRepository<AssetAccountingEvent>
    {
        Task<ReturnBase> DeleteById(long id);

    }
}