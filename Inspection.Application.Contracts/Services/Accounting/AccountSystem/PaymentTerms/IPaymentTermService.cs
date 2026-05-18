using Inspection.Application.Contracts.Dto.AccountingDtos.AccountSystemDto.PaymentTermDto;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Services.Accounting.AccountSystem.PaymentTerms
{
    public interface IPaymentTermService
    {
        Task<ReturnBase<PaymentTermDto>> Create(PaymentTermCreateDto createDto);
        Task<ReturnBase<PaymentTermDto>> Update(PaymentTermUpdateDto updateDto);
        Task<ReturnBase<PaymentTermDto>> Delete(long id);
        Task<ReturnBase<PaymentTermDto>> GetById(long id);
        Task<ReturnBase<List<PaymentTermDto>>> GetAll();
        Task<ReturnBase<IEnumerable<PaymentTermDto>>> Search(SqlQueryOptions sqlQueryOptions);
    }
}
