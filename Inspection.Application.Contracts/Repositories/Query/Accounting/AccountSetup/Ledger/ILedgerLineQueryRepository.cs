using Inspection.Domain.Models.Inventory.Ledger;
using NDS.Shared.Application.RepositoryBase;

namespace Inspection.Application.Contracts.Repositories.Query.Accounting.AccountSetup.LedgerQueryRepository
{
    public interface ILedgerLineQueryRepository : IQueryRepository<LedgerLine>
    {
        Task<LedgerLine?> GetByIdAsync(long id);
    }
}
