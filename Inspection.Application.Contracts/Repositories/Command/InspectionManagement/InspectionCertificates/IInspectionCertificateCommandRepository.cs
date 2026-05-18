using Inspection.Domain.Models.InspectionManagement.InspectionCertificates;
using NDS.Shared.Application.RepositoryBase;

namespace Inspection.Application.Contracts.Repositories.Command.InspectionManagement.InspectionCertificates
{
    public interface IInspectionCertificateCommandRepository : ICommandRepository<InspectionCertificate>
    {

    }
}
