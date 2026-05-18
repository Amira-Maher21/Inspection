using Inspection.Application.Contracts.Dto.SalesManagment.sales.Transactions.DeliveryNotes;
using Inspection.Application.Contracts.Dto.SharedDtos;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Services.SalesManagment.sales.DeliveryNotes
{
    public interface IDeliveryNoteService : IAccountServiceBase
    {

        Task<ReturnBase<DeliveryNoteDto>> Create(DeliveryNoteCreateDto createDto);
        Task<ReturnBase<DeliveryNoteDto>> Update(DeliveryNoteUpdateDto updateDto);
        Task<ReturnBase<DeliveryNoteDto>> Delete(long id);
        Task<ReturnBase<DeliveryNoteDto>> GetById(long id);
        Task<ReturnBase<IEnumerable<DeliveryNoteReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions);



        Task<ReturnBase<ImportResultDto>> ImportDeliveryNote(ExcelImportRequestDto dto);
        Task<ReturnBase<FileResultDto>> DownloadDeliveryNoteTemplate();
    }
}
