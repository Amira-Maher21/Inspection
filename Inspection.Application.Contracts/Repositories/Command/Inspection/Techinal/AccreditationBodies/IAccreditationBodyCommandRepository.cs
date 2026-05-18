using Inspection.Domain.Models.Inspection.Techinal.AccreditationBodies;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Command.Inspection.Techinal.AccreditationBodies
{
    public interface IAccreditationBodyCommandRepository : ICommandRepository<AccreditationBody>
    {
        Task<ReturnBase> DeleteById(long id);
        Task<ReturnBase> DeleteLinesByAccreditationBodyId(long id);
        Task<ReturnBase> DeleteLinesByIds(List<long> ids);
    }
}