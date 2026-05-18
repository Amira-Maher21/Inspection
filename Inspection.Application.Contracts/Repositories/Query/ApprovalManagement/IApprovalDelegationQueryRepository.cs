using Inspection.Application.Contracts.Dto.ApprovalManagement.ApprovalDelegation;
using Inspection.Domain.Models.ApprovalManagement;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Contracts.Repositories.Query.ApprovalManagement
{
    public interface IApprovalDelegationQueryRepository : IQueryRepository<Approval_Delegation>
    {
        Task<ReturnBase<IEnumerable<ApprovalDelegationIndexItemDto>>> GetApprovalDelegationIndexAsync(SqlQueryOptions queryOptions);
        Task<ReturnBase<IEnumerable<ApprovalDelegationApprovalDLookUpDto>>> GetApprovalDelegationApprovalDLookUpAsync(SqlQueryOptions queryOptions);
    }
}
