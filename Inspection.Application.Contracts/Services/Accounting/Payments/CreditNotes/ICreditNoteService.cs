using Inspection.Application.Contracts.Dto.AccountingDtos.Payments.CreditNoteDTOs;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Services.Accounting.Payments.CreditNotes
{
    public interface ICreditNoteService
    {
        Task<ReturnBase<CreditNoteDto>> Create(CreditNoteCreateDto createDto);
        Task<ReturnBase<CreditNoteDto>> Update(CreditNoteUpdateDto updateDto);
        Task<ReturnBase<CreditNoteDto>> Delete(long id);
        Task<ReturnBase<CreditNoteDto>> GetById(long id);
        //Task<ReturnBase<List<CreditNoteDto>>> GetAll();
        Task<ReturnBase<IEnumerable<CreditNoteReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions);
    }
}