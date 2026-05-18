using Inspection.Domain.Models.Accounting.AccountingSetup.Cashing;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Command.Accounting.AccountSetup.Cashing
{
    public interface ICashCommandRepository : ICommandRepository<Cash>
    {
        Task<ReturnBase> DeleteById(long id);
    }
}
