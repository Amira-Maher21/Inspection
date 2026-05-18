using Inspection.Domain.Models.Accounting.AccountingSystem;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Command.Accounting.AccountSystem
{
    public interface IDefaultAccountGroupCommandRepository : ICommandRepository<DefaultAccountGroup>
    {
        Task<ReturnBase> DeleteById(long id);
    }
}
