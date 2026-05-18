using Inspection.Domain.Models.Inspection.Techinal.ChecklistTemplates;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Command.Inspection.Techinal.ChecklistTemplates
{
    public interface IChecklistTemplateCommandRepository : ICommandRepository<ChecklistTemplate>
    {
        Task<ReturnBase> DeleteById(long id);
        Task<ReturnBase> DeleteDetailsByChecklistTemplateId(long ChecklistTemplateId);
        Task<ReturnBase> DeleteDetailsByIds(List<long> ids);

    }
}
