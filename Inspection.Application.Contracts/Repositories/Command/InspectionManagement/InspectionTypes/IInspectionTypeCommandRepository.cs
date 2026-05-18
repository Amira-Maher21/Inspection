using Inspection.Domain.Models.InspectionManagement.InspectionTypes;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Command.InspectionManagement.InspectionTypes
{

    public interface IInspectionTypeCommandRepository : ICommandRepository<InspectionType>
    {
        Task<ReturnBase> DeleteById(long id);
    }
}