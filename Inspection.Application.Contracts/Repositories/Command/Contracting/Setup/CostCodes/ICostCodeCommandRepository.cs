using Inspection.Domain.Models.Contracting.Setup.CostCodes;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Command.Contracting.Setup.CostCodes
{
    public interface ICostCodeCommandRepository : ICommandRepository<CostCode>
    {
        Task<ReturnBase> DeleteById(long id);
        Task<bool> HasChildren(long parentId);
    }
}