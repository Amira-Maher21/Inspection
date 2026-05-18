using Inspection.Domain.Models.Accounting.AccountingSetup.Branches;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Command.Accounting.AccountSetup.Branches
{
    public interface IBranchCommandRepository : ICommandRepository<Branch>
    {
        Task<ReturnBase> DeleteById(long id);
    }
}