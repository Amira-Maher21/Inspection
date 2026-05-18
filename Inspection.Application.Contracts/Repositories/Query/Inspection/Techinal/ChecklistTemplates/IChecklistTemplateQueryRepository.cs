using Inspection.Application.Contracts.Dto.InspectionDto.Techinal.ChecklistTemplates;
using Inspection.Domain.Models.Inspection.Techinal.ChecklistTemplates;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Query.Inspection.Techinal.ChecklistTemplates
{
    public interface IChecklistTemplateQueryRepository : IQueryRepository<ChecklistTemplate>
    {
        Task<ChecklistTemplate?> GetById(long id);
        Task<ChecklistTemplate?> GetByCode(string code);

        Task<ReturnBase<IEnumerable<ChecklistTemplateSearchReturnDto>>> Search(SqlQueryOptions sqlQueryOptions);
    }
}

