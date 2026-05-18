using Inspection.Application.Contracts.Dto.DMSDTOs.DocumentShares;
using Inspection.Domain.Models.DMS.DocumentShares;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Query.DMS.DocumentShares
{

    public interface IDocumentShareQueryRepository
    {
        Task<DocumentShare?> GetById(long id);
        Task<IEnumerable<DocumentShare>> GetList(SqlQueryOptions sqlQueryOptions = null);
        Task<ReturnBase<IEnumerable<DocumentShareReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions);

    }

}
