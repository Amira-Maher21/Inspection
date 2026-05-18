using Inspection.Application.Contracts.Dto.DMSDTOs.DocumentCommentDTOs;
using Inspection.Domain.Models.DMS.DocumentComments;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Query.DMS.DocumentComments
{
    public interface IDocumentCommentQueryRepository : IQueryRepository<DocumentComment>
    {
        Task<DocumentComment?> GetById(long id);
        Task<ReturnBase<IEnumerable<DocumentCommentReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions);
    }
}