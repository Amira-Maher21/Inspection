using Inspection.Application.Contracts.Dto.DMSDTOs.DocumentShares;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Services.DMS.DocumentShares
{
    public interface IDocumentShareService
    {
        Task<ReturnBase<DocumentShareDto>> Create(DocumentShareCreateDto dto);
        Task<ReturnBase<DocumentShareDto>> Update(DocumentShareUpdateDto dto);
        Task<ReturnBase<DocumentShareDto>> Delete(long id);

        Task<ReturnBase<DocumentShareDto>> GetById(long id);
        Task<ReturnBase<IEnumerable<DocumentShareDto>>> GetList(SqlQueryOptions? sqlQueryOptions = null);

        Task<ReturnBase<IEnumerable<DocumentShareReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions);
    }
}
