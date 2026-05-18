using Inspection.Application.Contracts.Dto.InspectionManagement.InspectionMethodDTOs;
using Inspection.Domain.Models.InspectionManagement.InspectionMethods;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Query.InspectionManagement.InspectionMethods
{
    public interface IInspectionMethodQueryRepository : IQueryRepository<InspectionMethod>
    {
        Task<ReturnBase<List<InspectionMethod>>> GetAll();
        Task<InspectionMethod?> GetById(long id);
        Task<ReturnBase<IEnumerable<InspectionMethodReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions);
    }
}