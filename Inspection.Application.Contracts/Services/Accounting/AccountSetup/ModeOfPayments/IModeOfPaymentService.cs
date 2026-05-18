using Inspection.Application.Contracts.Dto.AccountingDtos.AccountingSetupDtos.ModeOfPayments;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Services.Accounting.AccountSetup.ModeOfPayments
{
    public interface IModeOfPaymentService
    {
        Task<ReturnBase<ModeOfPaymentDto>> Create(ModeOfPaymentCreateDto createDto);
        Task<ReturnBase<ModeOfPaymentDto>> Update(ModeOfPaymentUpdateDto updateDto);
        Task<ReturnBase<ModeOfPaymentDto>> Delete(long id);
        Task<ReturnBase<ModeOfPaymentDto>> GetById(long id);
        Task<ReturnBase<IEnumerable<ModeOfPaymentSearchReturnDto>>> Search(SqlQueryOptions sqlQueryOptions);
    }
}
