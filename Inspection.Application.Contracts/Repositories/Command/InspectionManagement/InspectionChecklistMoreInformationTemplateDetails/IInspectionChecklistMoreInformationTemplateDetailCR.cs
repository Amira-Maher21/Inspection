using Inspection.Domain.Models.InspectionManagement.InspectionChecklistMoreInformationTemplateDetails;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Command.InspectionManagement.InspectionChecklistMoreInformationTemplateDetails
{


    public interface IInspectionChecklistMoreInformationTemplateDetailCR : ICommandRepository<InspectionChecklistMoreInformationTemplateDetail>
    {
        Task<ReturnBase> DeleteByIdAsync(long id);
    }
}
