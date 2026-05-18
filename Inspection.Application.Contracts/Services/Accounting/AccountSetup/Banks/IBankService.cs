using Inspection.Application.Contracts.Dto.AccountingDtos.AccountingSetupDtos.BankDTOs;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Services.Accounting.AccountSetup.Banks
{
    public interface IBankService
    {
        Task<ReturnBase<BankDto>> Create(BankCreateDto createDto);
        Task<ReturnBase<BankDto>> Update(BankUpdateDto updateDto);
        Task<ReturnBase<BankDto>> Delete(long id);
        Task<ReturnBase<BankDto>> GetById(long id);
        Task<ReturnBase<IEnumerable<BankDto>>> Search(SqlQueryOptions sqlQueryOptions);
    }
}
