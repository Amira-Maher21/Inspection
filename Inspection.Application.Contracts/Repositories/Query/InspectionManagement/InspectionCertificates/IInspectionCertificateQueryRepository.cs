using Inspection.Application.Contracts.Dto.InspectionManagement.InspectionCertificates;
using Inspection.Domain.Models.InspectionManagement.InspectionCertificates;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.RepositoryBase;

namespace Inspection.Application.Contracts.Repositories.Query.InspectionManagement.InspectionCertificates
{
    public interface IInspectionCertificateQueryRepository : IQueryRepository<InspectionCertificate>
    {
        Task<InspectionCertificate?> GetByIdAsync(long id);
        Task<IEnumerable<InspectionCertificateDtoByInclude?>> GetListByIncludeAsync(SqlQueryOptions sqlQueryOptions);

    }
}
