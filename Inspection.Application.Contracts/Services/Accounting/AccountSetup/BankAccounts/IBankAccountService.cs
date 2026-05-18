using Inspection.Application.Contracts.Dto.AccountingDtos.AccountingSetupDtos.BankAccountDTOs;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Services.Accounting.AccountSetup.BankAccounts
{
    public interface IBankAccountService
    {
        Task<ReturnBase<BankAccountDto>> Create(BankAccountCreateDto createDto);
        Task<ReturnBase<BankAccountDto>> Update(BankAccountUpdateDto updateDto);
        Task<ReturnBase<BankAccountDto>> Delete(long id);
        Task<ReturnBase<BankAccountDto>> GetById(long id);
        Task<ReturnBase<IEnumerable<BankAccountReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions);
    }
}
