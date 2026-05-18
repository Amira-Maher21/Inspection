using Inspection.Domain.Models.Inventory.Transaction.ScrapReasons;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Command.Inventory.Transaction.ScrapReasons
{
    public interface IScrapReasonCommandRepository : ICommandRepository<ScrapReason>
    {
        Task<ReturnBase> DeleteById(long id);
    }
}