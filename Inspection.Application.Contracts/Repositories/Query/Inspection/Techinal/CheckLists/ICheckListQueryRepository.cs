using Inspection.Application.Contracts.Dto.InspectionDto.Techinal.Checklists;
using Inspection.Domain.Models.Inspection.Techinal.Checklists;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Query.Inspection.Techinal.Checklists
{
    public interface IChecklistQueryRepository : IQueryRepository<Checklist>
    {
        Task<ReturnBase<List<Checklist>>> GetAll();
        Task<Checklist?> GetById(long id);
        Task<Checklist?> GetChecklistTemplateById(long id);
        Task<ReturnBase<IEnumerable<ChecklistSearchReturnDto>>> Search(SqlQueryOptions sqlQueryOptions);
    }
}