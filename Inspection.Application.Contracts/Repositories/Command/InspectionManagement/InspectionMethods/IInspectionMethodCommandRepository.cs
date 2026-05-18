using Inspection.Domain.Models.InspectionManagement.InspectionMethods;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Command.InspectionManagement.InspectionMethods
{
    public interface IInspectionMethodCommandRepository : ICommandRepository<InspectionMethod>
    {
        Task<ReturnBase> DeleteById(long id);
    }
}