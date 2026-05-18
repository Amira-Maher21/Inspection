using Inspection.Application.Contracts.Dto.InspectionManagement.InspectionChecklists;
using Inspection.Domain.Models.InspectionManagement.InspectionChecklists;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.RepositoryBase;

namespace Inspection.Application.Contracts.Repositories.Query.InspectionManagement.InspectionChecklists
{


    public interface IInspectionChecklistsQueryRepository : IQueryRepository<InspectionChecklist>
    {
        Task<InspectionChecklist?> GetByIdAsync(long id);

        Task<IEnumerable<InspectionChecklistDtoByInclude?>> GetListByIncludeAsync(SqlQueryOptions sqlQueryOptions);

    }
}
