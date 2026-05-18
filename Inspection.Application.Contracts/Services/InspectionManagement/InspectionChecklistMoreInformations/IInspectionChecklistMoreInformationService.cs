using Inspection.Application.Contracts.Dto.InspectionManagement.InspectionChecklists;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Services.InspectionManagement.InspectionChecklistMoreInformations
{


    public interface IInspectionChecklistMoreInformationService : IAccountServiceBase
    {
        Task<ReturnBase<InspectionChecklistMoreInformationDto>> GetAsync(long id);

        Task<ReturnBase<List<InspectionChecklistMoreInformationDtoByInclude>>> GetListByIncludeAsync(SqlQueryOptions sqlQueryOptions);

        Task<ReturnBase<List<InspectionChecklistMoreInformationDto>>> GetListAsync();
        Task<ReturnBase<UpdateInspectionChecklistMoreInformationDto>> CreateAsync(CreateInspectionChecklistMoreInformationDto input);

        Task<ReturnBase<UpdateInspectionChecklistMoreInformationDto>> UpdateAsync(long id, UpdateInspectionChecklistMoreInformationDto input);
        Task<ReturnBase<bool>> DeleteAsync(long id);
    }
}
