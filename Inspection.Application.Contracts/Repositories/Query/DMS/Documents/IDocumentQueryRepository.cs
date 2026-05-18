using Inspection.Application.Contracts.Dto.DMSDTOs.DocumentDTOs;
using Inspection.Domain.Models.DMS.Documents;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Query.DMS.Documents
{
    public interface IDocumentQueryRepository : IQueryRepository<Document>
    {
        Task<Document?> GetById(long id);
        Task<ReturnBase<IEnumerable<DocumentSearchReturnDto>>> Search(SqlQueryOptions sqlQueryOptions, string tenantId, long companyId);
    }
}