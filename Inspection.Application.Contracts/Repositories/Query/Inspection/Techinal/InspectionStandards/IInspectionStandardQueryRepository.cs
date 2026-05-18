using Inspection.Application.Contracts.Dto.InspectionDto.Techinal.InspectionStandards;
using Inspection.Domain.Models.Inspection.Techinal.InspectionStandards;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Query.Inspection.Techinal.InspectionStandards
{
    public interface IInspectionStandardQueryRepository : IQueryRepository<InspectionStandard>
    {
        Task<ReturnBase<List<InspectionStandard>>> GetAll();
        Task<InspectionStandard?> GetById(long id);
        Task<InspectionStandard?> GetByCode(string code);
        Task<ReturnBase<IEnumerable<InspectionStandardReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions);
    }
}
