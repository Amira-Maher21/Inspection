using Inspection.Application.Contracts.Dto.ContractingDTOs.Setup.CommitmentDTOs;
using Inspection.Domain.Models.Contracting.Setup.Commitment;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Query.Constracting.Setup.Commitments
{
    public interface ICommitmentQueryRepository : IQueryRepository<Commitment>
    {
        Task<ReturnBase<List<Commitment>>> GetAll();
        Task<Commitment?> GetById(long id);
        Task<ReturnBase<IEnumerable<CommitmentReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions);
    }
}