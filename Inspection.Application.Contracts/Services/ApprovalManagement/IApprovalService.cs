using Inspection.Application.Contracts.Dto;
using Inspection.Application.Contracts.Dto.ApprovalManagement;
using Inspection.Application.Contracts.Dto.ApprovalManagement.LookUpDto;
using Inspection.Application.Contracts.Dto.ApprovalManagement.UserApproval;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.SharedModels;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Services.ApprovalManagement
{
    public interface IApprovalService
    {
        Task<ReturnBase<IEnumerable<ApprovalDto>>> GetApprovalIndexAsync(SqlQueryOptions queryOptions);
        Task<ReturnBase<ApprovalUpdateDto>> GetApprovalEntityForUpdate(EntityKeyValueDictionary keys);
        Task<ReturnBase<ApprovalDto>> Delete(long id);

        Task<ReturnBase<ApprovalDto>> InsertApprovalAsync(ApprovalInsertDto insertDto);

        Task<ReturnBase<ApprovalDto>> UpdateApprovalAsync(ApprovalUpdateDto updateDto);
        Task<ReturnBase<ApprovalDto>> GetById(long id);

        //void requestApproval(RequestApprovalDto requestApprovalDto);

        Task<ReturnBase<IEnumerable<ApprovalHlpScrScreenCodedApprovalLookUpDto>>> GetApprovalHlpScrScreenCodedApprovalLookUpAsync(SqlQueryOptions queryOptions);
        Task<ReturnBase<IEnumerable<ApprovalUser_CodeMLookUpDto>>> GetApprovalUser_CodeMLookUpAsync(SqlQueryOptions queryOptions);

        Task<ReturnBase<IEnumerable<ApprovalUser_CodeDLookUpDto>>> GetApprovalUser_CodeDLookUpAsync(SqlQueryOptions queryOptions);
        Task<ReturnBase<IEnumerable<ApprovalUserCountLookUpDto>>> GetApprovalUserCountLookUpAsync(SqlQueryOptions queryOptions);

        List<ApprovalUser_CodeDLookUpDto> filterHlp(LookUpRequest request, ReturnBase<IEnumerable<ApprovalUser_CodeDLookUpDto>> lookupData);
        Task<ReturnBase<UserApprovalInsertDto>> RequestApproval(RequestApprovalDto requestApprovalDto);
        Task<ReturnBase<UserApprovalInsertDto>> DoApproval(DoApprovalDto doApprovalDto);
        Task<ReturnBase<IEnumerable<DeleteResultDto>>> BulkDeleteApprovalAsync(IEnumerable<EntityKeyValueDictionary> keysList);
    }
}
