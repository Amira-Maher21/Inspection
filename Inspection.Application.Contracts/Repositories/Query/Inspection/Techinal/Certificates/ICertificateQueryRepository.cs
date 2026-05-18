using Inspection.Application.Contracts.Dto.InspectionDto.Techinal.CertificateDTOs;
using Inspection.Domain.Models.Inspection.Techinal.Certificates;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Query.Inspection.Techinal.Certificates
{
    public interface ICertificateQueryRepository : IQueryRepository<Certificate>
    {
        IQueryable<Certificate> GetAll();
        Task<Certificate?> GetById(long id);
        Task<ReturnBase<IEnumerable<CertificateReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions, string tenantId, long companyId);
    }
}