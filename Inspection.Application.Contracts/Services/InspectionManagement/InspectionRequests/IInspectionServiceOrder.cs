using Inspection.Application.Contracts.Dto.InspectionManagement.InspectionRequests;
using Inspection.Domain.Enums;
using Inspection.Domain.Models.InspectionManagement.InspectionRequests.Transaction.DTOs;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Services.InspectionManagement.InspectionRequests
{
    public interface IInspectionServiceOrder : IAccountServiceBase
    {

        Task<ReturnBase<InspectionRequestDto>> InsertInspectionRequestAsync(CreateInspectionRequestDto insertDto);
        Task<ReturnBase<InspectionRequestDto>> UpdateInspectionRequestAsync(UpdateInspectionRequestDto updateDto);
        Task<ReturnBase<InspectionRequestDto>> DeleteInspectionRequestAsync(long id);
        Task<ReturnBase<InspectionRequestDto>> GetInspectionRequestByIdAsync(long id);
        //Task<ReturnBase<IEnumerable<InspectionRequestDtoByInclude>>> GetInspectionRequestListAsync(SqlQueryOptions sqlQueryOptions);
        Task<List<InspectionRequestDtoByInclude>> GetListAsync();
        Task<ReturnBase<IEnumerable<InspectionRequestDtoByInclude>>> GetInspectionRequestListByIncludeAsync(SqlQueryOptions sqlQueryOptions);
        Task<ReturnBase<IEnumerable<InspectionRequestDtoLookUpForNames>>> GetLookUpInspectionRequestForNamesAsync(SqlQueryOptions sqlQueryOptions);
        Task<ReturnBase<List<InspectionRequestDtoLookUpForRequestDetails>>> GetRequestDetailsAsync(long id);
        Task<ReturnBase<bool>> ChangeStatus(long id, ChangeInspectionApprovalStatus Status);
        Task<ReturnBase<List<InspectionRequestLookupDto>>> GetRequestNumbersForDropdownAsync();
        Task<ReturnBase<bool>> ChangeDocumentStatusAsync(ChangeInspectionRequestDocumentStatusDto dto);

    }
}
