using Inspection.Application.Contracts.Dto.InspectionManagement.InspectionChecklists;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Services.InspectionManagement.InspectionChecklists
{


    public interface IInspectionChecklistService : IAccountServiceBase
    {
        Task<ReturnBase<InspectionChecklistDto>> GetAsync(long id);
        Task<ReturnBase<List<InspectionChecklistDto>>> GetListAsync();
        Task<ReturnBase<UpdateInspectionChecklistDto>> CreateAsync(CreateInspectionChecklistDto input);
        Task<ReturnBase<UpdateInspectionChecklistDto>> UpdateAsync(long id, UpdateInspectionChecklistDto input);
        Task<ReturnBase<bool>> DeleteAsync(long id);
        Task<ReturnBase<List<InspectionChecklistDtoByInclude>>> GetListByIncludeAsync(SqlQueryOptions sqlQueryOptions);


    }
}
