using Inspection.Domain.Models.Accounting.PR.MasterData.Suppliers;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Command.Accounting.PR.MasterData.SupplierGroups
{
    public interface ISupplierGroupCommandRepository : ICommandRepository<SupplierGroup>
    {
        Task<ReturnBase> DeleteById(long id);
    }
}

