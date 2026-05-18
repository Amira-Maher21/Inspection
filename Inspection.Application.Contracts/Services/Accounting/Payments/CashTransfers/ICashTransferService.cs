using Inspection.Application.Contracts.Dto.AccountingDtos.Payments.CashTransferDTOs;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Services.Accounting.Payments.CashTransfers
{
    public interface ICashTransferService
    {
        Task<ReturnBase<CashTransferDto>> Create(CashTransferCreateDto createDto);
        Task<ReturnBase<CashTransferDto>> Update(CashTransferUpdateDto updateDto);
        Task<ReturnBase<CashTransferDto>> Delete(long id);
        Task<ReturnBase<CashTransferDto>> GetById(long id);
        //Task<ReturnBase<List<CashTransferDto>>> GetAll();
        Task<ReturnBase<IEnumerable<CashTransferReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions);
    }
}