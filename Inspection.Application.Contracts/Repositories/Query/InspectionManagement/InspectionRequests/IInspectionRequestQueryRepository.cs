using Inspection.Application.Contracts.Dto.InspectionManagement.InspectionRequests;
using Inspection.Domain.Models.InspectionManagement.InspectionRequests;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;


namespace Inspection.Application.Contracts.Repositories.Query.InspectionManagement.InspectionRequests
{
    public interface IInspectionRequestQueryRepository : IQueryRepository<InspectionRequest>
    {
        Task<InspectionRequest?> GetByIdAsync(long id);

        Task<ReturnBase<IEnumerable<InspectionRequestDtoByInclude>>> GetListAsync(SqlQueryOptions sqlQueryOptions);
        Task<ReturnBase<IEnumerable<InspectionRequestDtoByInclude>>> GetListIncldeNameAsync(SqlQueryOptions sqlQueryOptions);
        Task<ReturnBase<IEnumerable<InspectionRequestDtoByInclude>>> GetLookUpInspectionRequestForNamesAsync(SqlQueryOptions sqlQueryOptions);
        Task<List<InspectionRequestDtoLookUpForRequestDetails?>> GetRequestDetailsAsync(long id);
        Task<ReturnBase<List<InspectionRequestLookupDto>>> GetRequestNumbersForDropdownAsync();

    }

}
