using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Command.InspectionManagement.InspectorCategory
{
    public interface IInspectorCategoryCommandRepository : ICommandRepository<Domain.Models.InspectionManagement.InspectorCategories.InspectorCategory>
    {
        Task<ReturnBase> DeleteById(long id);
    }
}