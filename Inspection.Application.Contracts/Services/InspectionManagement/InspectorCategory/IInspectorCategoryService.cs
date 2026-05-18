using Inspection.Application.Contracts.Dto.InspectionManagement.InspectorCategory;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Services.InspectionManagement.InspectorCategory
{
    public interface IInspectorCategoryService : IAccountServiceBase
    {
        Task<ReturnBase<InspectorCategoryDto>> Create(InspectorCategoryCreateDto createDto);
        Task<ReturnBase<InspectorCategoryDto>> Update(InspectorCategoryUpdateDto updateDto);
        Task<ReturnBase<InspectorCategoryDto>> Delete(long id);
        Task<ReturnBase<InspectorCategoryDto>> GetById(long id);
        Task<ReturnBase<IEnumerable<InspectorCategoryDto>>> Search(SqlQueryOptions sqlQueryOptions);
        Task<ReturnBase<List<InspectorCategoryGetListDto>>> GetInspectorCategoryGetListAsync();
    }
}