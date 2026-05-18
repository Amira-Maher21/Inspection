using Inspection.Application.Contracts.Dto;
using Inspection.Application.Contracts.Dto.ApprovalManagement.ApprovalDelegation;
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
    public interface IApprovalDelegationService : IAccountServiceBase
    {
        Task<ReturnBase<IEnumerable<ApprovalDelegationIndexItemDto>>> GetApprovalDelegationIndexAsync(SqlQueryOptions queryOptions);
        Task<ReturnBase<ApprovalDelegationUpdateDto>> GetApprovalDelegationEntityAsync(EntityKeyValueDictionary keys);
        //Task<ReturnBase<ApprovalDelegationUpdateDto>> DeleteApprovalDelegationAsync(EntityKeyValueDictionary keys);
        Task<ReturnBase<ApprovalDelegationIndexItemDto>> InsertApprovalDelegationAsync(ApprovalDelegationInsertDto insertDto);
        Task<ReturnBase<ApprovalDelegationUpdateDto>> UpdateApprovalDelegationAsync(ApprovalDelegationUpdateDto updateDto);
        Task<ReturnBase<IEnumerable<DeleteResultDto>>> BulkDeleteApprovalDelegationsAsync(IEnumerable<EntityKeyValueDictionary> keysList);
        Task<ReturnBase<IEnumerable<ApprovalDelegationApprovalDLookUpDto>>> GetApprovalDelegationApprovalDLookUpAsync(SqlQueryOptions queryOptions);
    }
}
