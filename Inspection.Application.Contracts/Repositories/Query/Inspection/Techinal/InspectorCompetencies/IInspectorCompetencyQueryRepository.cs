using Inspection.Application.Contracts.Dto.InspectionDto.Techinal.InspectorCompetencyDTOs;
using Inspection.Domain.Models.Inspection.Techinal.InspectorCompetencies;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Query.Inspection.Techinal.InspectorCompetencies
{
    public interface IInspectorCompetencyQueryRepository : IQueryRepository<InspectorCompetency>
    {
        IQueryable<InspectorCompetency> GetAll();
        Task<InspectorCompetency?> GetById(long id);
        Task<ReturnBase<IEnumerable<InspectorCompetencyReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions);
    }
}