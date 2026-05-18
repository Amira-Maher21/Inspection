using Inspection.Application.Contracts.Dto.InspectionManagement.InspectorCategory;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Query.InspectionManagement.InspectorCategory
{
    public interface IInspectorCategoryQueryRepository : IQueryRepository<Domain.Models.InspectionManagement.InspectorCategories.InspectorCategory>
    {

        Task<Domain.Models.InspectionManagement.InspectorCategories.InspectorCategory?> GetById(long id);
        Task<Domain.Models.InspectionManagement.InspectorCategories.InspectorCategory?> GetByCode(string code);
        Task<ReturnBase<IEnumerable<InspectorCategoryDto>>> Search(SqlQueryOptions sqlQueryOptions);
        Task<IEnumerable<InspectorCategoryGetListDto>> GetListAsync();
    }
}