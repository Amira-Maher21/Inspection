using Inspection.Domain.Models.InspectionManagement.InspectionChecklists;
using NDS.Shared.Application.RepositoryBase;

namespace Inspection.Application.Contracts.Repositories.Command.InspectionManagement.InspectionChecklists
{

    public interface IInspectionChecklistCommandRepository : ICommandRepository<InspectionChecklist>
    {
    }
}
