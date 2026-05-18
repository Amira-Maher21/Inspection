using Inspection.Domain.Models.Contracting.Setup.Commitment;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Command.Constracting.Setup.Commitments
{
    public interface ICommitmentCommandRepository : ICommandRepository<Commitment>
    {
        Task<ReturnBase> DeleteById(long id);

        Task<ReturnBase> DeleteCommitmentLinesByCommitmentIds(List<long> ids);
    }
}

