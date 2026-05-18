using Inspection.Application.Contracts.Dto.ApprovalManagement.UserApproval;
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
    public interface IUserApprovalQueryRepository : IQueryRepository<User_Approval>
    {
        Task<ReturnBase<IEnumerable<UserApprovalIndexItemDto>>> GetUserApprovalIndexAsync(SqlQueryOptions queryOptions);
    }
}
