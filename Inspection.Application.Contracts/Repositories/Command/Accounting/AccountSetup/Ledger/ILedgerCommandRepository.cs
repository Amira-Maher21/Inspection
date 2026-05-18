using Inspection.Domain.Models.Inventory.Ledger;
using NDS.Shared.Application.RepositoryBase;

namespace Inspection.Application.Contracts.Repositories.Command.Accounting.AccountSetup.ILedgerCommandRepository
{
    public interface ILedgerCommandRepository : ICommandRepository<Ledger>
    {

    }
}
