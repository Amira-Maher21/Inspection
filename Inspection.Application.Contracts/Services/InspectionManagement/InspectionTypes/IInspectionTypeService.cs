using Inspection.Application.Contracts.Dto.InspectionManagement.InspectionTypes;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Services.InspectionManagement.InspectionTypes
{

    public interface IInspectionTypeService : IAccountServiceBase
    {

        Task<ReturnBase<InspectionTypeDto>> Create(InspectionTypeCreateDto createDto);
        Task<ReturnBase<InspectionTypeDto>> Update(InspectionTypeUpdateDto updateDto);
        Task<ReturnBase<InspectionTypeDto>> Delete(long id);
        Task<ReturnBase<InspectionTypeDto>> GetById(long id);
        Task<ReturnBase<IEnumerable<InspectionTypeDto>>> Search(SqlQueryOptions sqlQueryOptions);
    }
}