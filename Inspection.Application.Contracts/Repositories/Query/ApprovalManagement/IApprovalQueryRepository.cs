using Inspection.Application.Contracts.Dto.ApprovalManagement;
using Inspection.Application.Contracts.Dto.ApprovalManagement.LookUpDto;
using Inspection.Domain.Models.ApprovalManagement;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Query.ApprovalManagement
{
    public interface IApprovalQueryRepository : IQueryRepository<Approval>
    {
        Task<Approval?> GetById(long id);
        Task<ReturnBase<IEnumerable<ApprovalDto>>> GetApprovalIndexAsync(SqlQueryOptions queryOptions);

        Task<ReturnBase<IEnumerable<ApprovalHlpScrScreenCodedApprovalLookUpDto>>> GetApprovalHlpScrScreenCodedApprovalLookUpAsync(SqlQueryOptions queryOptions);
        Task<ReturnBase<IEnumerable<ApprovalUser_CodeMLookUpDto>>> GetApprovalUser_CodeMLookUpAsync(SqlQueryOptions queryOptions);

        Task<ReturnBase<IEnumerable<ApprovalUser_CodeDLookUpDto>>> GetApprovalUser_CodeDLookUpAsync(SqlQueryOptions queryOptions);
        Task<ReturnBase<IEnumerable<ApprovalUserCountLookUpDto>>> GetApprovalUserCountLookUpAsync(SqlQueryOptions queryOptions);
    }
}