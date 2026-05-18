using Inspection.Domain.Models.Accounting.AccountingSetup.BankAccounts;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Command.Accounting.AccountSetup.BankAccounts
{
    public interface IBankAccountCommandRepository : ICommandRepository<BankAccount>
    {
        Task<ReturnBase> HardDeleteById(long id);

    }
}
