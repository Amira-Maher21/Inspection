using Inspection.Domain.Models.Inspection.Techinal.Checklists;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Command.Inspection.Techinal.Checklists
{
    public interface IChecklistCommandRepository : ICommandRepository<Checklist>
    {
        Task<ReturnBase> DeleteById(long id);
        Task<ReturnBase> DeleteDetailsByChecklistId(long ChecklistId);
        Task<ReturnBase> DeleteDetailsByIds(List<long> ids);

    }
}
