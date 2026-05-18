using Inspection.Application.Contracts.Dto.InspectionManagement.InspectionTypes;
using Inspection.Domain.Models.InspectionManagement.InspectionTypes;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Query.InspectionManagement.InspectionTypes
{

    public interface IInspectionTypeQueryRepository : IQueryRepository<InspectionType>
    {
        Task<InspectionType?> GetById(long id);
        Task<ReturnBase<IEnumerable<InspectionTypeDto>>> Search(SqlQueryOptions sqlQueryOptions);
    }
}