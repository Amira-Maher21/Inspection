using Inspection.Domain.Models.Inspection.Techinal.Certificates;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Command.Inspection.Techinal.Certificates
{
    public interface ICertificateCommandRepository : ICommandRepository<Certificate>
    {
        Task<ReturnBase> DeleteById(long id);
    }
}