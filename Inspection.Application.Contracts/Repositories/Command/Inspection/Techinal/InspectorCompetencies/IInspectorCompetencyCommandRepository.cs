using Inspection.Domain.Models.Inspection.Techinal.InspectorCompetencies;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Command.Inspection.Techinal.InspectorCompetencies
{
    public interface IInspectorCompetencyCommandRepository : ICommandRepository<InspectorCompetency>
    {
        Task<ReturnBase> DeleteById(long id);
        Task<ReturnBase> DeleteLinesByInspectorCompetencyId(long id);
        Task<ReturnBase> DeleteLinesByIds(List<long> ids);
        Task<ReturnBase> DeleteAccreditationsByInspectorCompetencyId(long id);

        Task<ReturnBase> DeleteAccreditationsByIds(List<long> ids);
    }
}