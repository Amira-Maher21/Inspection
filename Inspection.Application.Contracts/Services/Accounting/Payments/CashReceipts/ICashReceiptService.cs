using Inspection.Application.Contracts.Dto.AccountingDtos.Payments.CashReceiptDTOs;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Services.Accounting.Payments.CashReceipts
{
    public interface ICashReceiptService
    {
        Task<ReturnBase<CashReceiptDto>> Create(CashReceiptCreateDto createDto);
        Task<ReturnBase<CashReceiptDto>> Update(CashReceiptUpdateDto updateDto);
        Task<ReturnBase<CashReceiptDto>> Delete(long id);
        Task<ReturnBase<CashReceiptDto>> GetById(long id);
        //Task<ReturnBase<List<CashReceiptDto>>> GetAll();
        Task<ReturnBase<IEnumerable<CashReceiptReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions);
    }
}