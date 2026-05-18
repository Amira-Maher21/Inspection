using Inspection.Domain.Models.SystemConfigurations.Operations;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Command.SystemConfigurations.Operations
{
    public interface IOperationCommandRepository : ICommandRepository<Operation>
    {
        Task<ReturnBase> DeleteById(long id);

    }
}
