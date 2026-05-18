using Inspection.Domain.Models.Accounting.AR.MasterData;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Command.Accounting.AR.MasterData
{
    public interface ICustomerGroupCommandRepository : ICommandRepository<CustomerGroup>
    {
        Task<ReturnBase> DeleteById(long id);
    }
}
