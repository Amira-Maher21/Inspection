using Inspection.Domain.Models.InspectionManagement.InspectionRequests;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Command.InspectionManagement.InspectionRequestDetailF
{


    public interface IInspectionRequestLinesCommandRepository : ICommandRepository<InspectionRequestLines>
    {
        Task<ReturnBase> DeleteByIdAsync(long id);
    }
}
