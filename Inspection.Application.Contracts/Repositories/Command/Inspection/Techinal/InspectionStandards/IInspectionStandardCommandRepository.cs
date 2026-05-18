using Inspection.Domain.Models.Inspection.Techinal.InspectionStandards;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Command.Inspection.Techinal.InspectionStandards
{
    public interface IInspectionStandardCommandRepository : ICommandRepository<InspectionStandard>
    {
        Task<ReturnBase> DeleteById(long id);
        Task<ReturnBase> DeleteDetailsByInspectionStandardId(long InspectionStandardId);
        Task<ReturnBase> DeleteDetailsByIds(List<long> ids);

    }
}
