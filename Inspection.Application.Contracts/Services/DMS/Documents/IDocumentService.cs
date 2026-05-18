using Inspection.Application.Contracts.Dto.DMSDTOs.DocumentDTOs;
using Inspection.Application.Contracts.Dto.DMSDTOs.DocumentDTOs.DocumentEntityLinkDTOs;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Services.DMS.Documents
{
    public interface IDocumentService
    {
        Task<ReturnBase<DocumentEntityLinkDto>> CreateDocumentEntityLink(DocumentEntityLinkCreateWithOutDocumentIdDto createDto);
        Task<ReturnBase<DocumentDto>> Create(DocumentCreateDto createDto);
        Task<ReturnBase<DocumentDto>> Update(DocumentUpdateDto updateDto);
        Task<ReturnBase<DocumentDto>> Delete(long id);
        Task<ReturnBase<DocumentDto>> GetById(long id);
        Task<ReturnBase<IEnumerable<DocumentSearchReturnDto>>> Search(SqlQueryOptions sqlQueryOptions);
    }
}