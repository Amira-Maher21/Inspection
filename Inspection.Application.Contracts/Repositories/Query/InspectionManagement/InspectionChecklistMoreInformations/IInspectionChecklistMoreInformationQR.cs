using Inspection.Application.Contracts.Dto.InspectionManagement.InspectionChecklists;
using Inspection.Domain.Models.InspectionManagement.InspectionChecklistMoreInformations;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.RepositoryBase;

namespace Inspection.Application.Contracts.Repositories.Query.InspectionManagement.InspectionChecklistMoreInformations
{

    public interface IInspectionChecklistMoreInformationQR : IQueryRepository<InspectionChecklistMoreInformation>
    {
        Task<InspectionChecklistMoreInformation?> GetByIdAsync(long id);
        Task<IEnumerable<InspectionChecklistMoreInformationDtoByInclude?>> GetListByIncludeAsync(SqlQueryOptions sqlQueryOptions);

    }
}
