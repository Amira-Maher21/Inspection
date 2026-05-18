using Inspection.Domain.Models.Accounting.AccountBalance;
using Inspection.Domain.Models.Inventory.System.InventoryLedgers;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Command.Accounting.AccountBalances
{
    public interface IAccountBalanceCommandRepository : ICommandRepository<AccountBalance>
    {
        Task<ReturnBase> DeleteById(long id);
    }
}