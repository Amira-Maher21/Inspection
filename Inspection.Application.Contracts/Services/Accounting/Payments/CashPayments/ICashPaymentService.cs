using Inspection.Application.Contracts.Dto.AccountingDtos.Payments.CashPaymentDTOs;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Services.Accounting.Payments.CashPayments
{

    public interface ICashPaymentService
    {
        Task<ReturnBase<CashPaymentDto>> Create(CashPaymentCreateDto createDto);
        Task<ReturnBase<CashPaymentDto>> Update(CashPaymentUpdateDto updateDto);
        Task<ReturnBase<CashPaymentDto>> Delete(long id);
        Task<ReturnBase<CashPaymentDto>> GetById(long id);
        //Task<ReturnBase<List<CashPaymentDto>>> GetAll();
        Task<ReturnBase<IEnumerable<CashPaymentReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions);
    }
}