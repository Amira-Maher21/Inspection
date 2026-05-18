using Inspection.Application.Contracts.Dto.DMSDTOs.DocumentCommentDTOs;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Services.DMS.DocumentComments
{
    public interface IDocumentCommentService
    {
        Task<ReturnBase<DocumentCommentDto>> Create(DocumentCommentCreateDto createDto);
        Task<ReturnBase<DocumentCommentDto>> Update(DocumentCommentUpdateDto updateDto);
        Task<ReturnBase<DocumentCommentDto>> Delete(long id);
        Task<ReturnBase<DocumentCommentDto>> GetById(long id);
        Task<ReturnBase<IEnumerable<DocumentCommentReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions);
    }
}
