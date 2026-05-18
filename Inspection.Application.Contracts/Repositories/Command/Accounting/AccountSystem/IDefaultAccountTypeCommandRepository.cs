using Inspection.Domain.Models.Accounting.AccountingSystem;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Command.Accounting.AccountSystem
{
    public interface IDefaultAccountTypeCommandRepository : ICommandRepository<DefaultAccountType>
    {
        Task<ReturnBase> DeleteById(long id);
    }
}
