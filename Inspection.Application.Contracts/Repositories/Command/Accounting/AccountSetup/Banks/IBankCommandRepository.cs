using Inspection.Domain.Models.Accounting.AccountingSetup.Banks;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Command.Accounting.AccountSetup.Banks
{
    public interface IBankCommandRepository : ICommandRepository<Bank>
    {
        Task<ReturnBase> DeleteById(long id);

    }
}
