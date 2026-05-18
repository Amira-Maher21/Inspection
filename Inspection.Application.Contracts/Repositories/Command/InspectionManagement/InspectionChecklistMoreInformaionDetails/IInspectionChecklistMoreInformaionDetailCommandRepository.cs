using Inspection.Domain.Models.InspectionManagement.InspectionChecklistMoreInformationDetails;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Command.InspectionManagement.InspectionChecklistMoreInformationDetails
{


    public interface IInspectionChecklistMoreInformationDetailCommandRepository : ICommandRepository<InspectionChecklistMoreInformationDetail>
    {
        Task<ReturnBase> DeleteByIdAsync(long id);
    }
}
