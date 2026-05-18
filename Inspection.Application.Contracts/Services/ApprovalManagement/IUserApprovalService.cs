using Inspection.Application.Contracts.Dto;
using Inspection.Application.Contracts.Dto.ApprovalManagement.UserApproval;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.SharedModels;
using NDS.Shared.Kernel.BaseReturnTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Contracts.Services.ApprovalManagement
{
    public interface IUserApprovalService : IAccountServiceBase
    {
        Task<ReturnBase<IEnumerable<UserApprovalIndexItemDto>>> GetUserApprovalIndexAsync(SqlQueryOptions queryOptions);
        Task<ReturnBase<UserApprovalUpdateDto>> GetUserApprovalEntityForUpdate(EntityKeyValueDictionary keys);

        Task<ReturnBase<UserApprovalInsertDto>> InsertUserApprovalAsync(UserApprovalInsertDto insertDto);

        Task<ReturnBase<UserApprovalUpdateDto>> UpdateUserApprovalAsync(UserApprovalUpdateDto updateDto);
        Task<ReturnBase<IEnumerable<DeleteResultDto>>> BulkDeleteUserApprovalAsync(IEnumerable<EntityKeyValueDictionary> keysList);
    }
}
