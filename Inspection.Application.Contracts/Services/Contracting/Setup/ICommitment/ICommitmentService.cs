using Inspection.Application.Contracts.Dto.ContractingDTOs.Setup.CommitmentDTOs;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Services.Constracting.Setup.Commitment
{
    public interface ICommitmentService
    {
        Task<ReturnBase<CommitmentDto>> Create(CommitmentCreateDto createDto);
        Task<ReturnBase<CommitmentDto>> Update(CommitmentUpdateDto updateDto);
        Task<ReturnBase<CommitmentDto>> Delete(long id);
        Task<ReturnBase<CommitmentDto>> GetById(long id);
        Task<ReturnBase<IEnumerable<CommitmentReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions);
    }
}