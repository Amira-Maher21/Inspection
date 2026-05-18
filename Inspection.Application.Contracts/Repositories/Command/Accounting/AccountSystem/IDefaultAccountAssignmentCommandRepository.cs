using Inspection.Domain.Models.Accounting.AccountingSystem.DefaultAccountAssignment;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Command.Accounting.AccountSystem
{
    public interface IDefaultAccountAssignmentCommandRepository : ICommandRepository<DefaultAccountAssignment>
    {
        Task<ReturnBase> DeleteById(long id);
    }
}
