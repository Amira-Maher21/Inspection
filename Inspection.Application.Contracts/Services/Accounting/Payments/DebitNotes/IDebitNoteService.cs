using Inspection.Application.Contracts.Dto.AccountingDtos.Payments.DebitNoteDTOs;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Services.Accounting.Payments.DebitNotes
{
    public interface IDebitNoteService
    {
        Task<ReturnBase<DebitNoteDto>> Create(DebitNoteCreateDto createDto);
        Task<ReturnBase<DebitNoteDto>> Update(DebitNoteUpdateDto updateDto);
        Task<ReturnBase<DebitNoteDto>> Delete(long id);
        Task<ReturnBase<DebitNoteDto>> GetById(long id);
        //Task<ReturnBase<List<DebitNoteDto>>> GetAll();
        Task<ReturnBase<IEnumerable<DebitNoteReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions);
    }
}