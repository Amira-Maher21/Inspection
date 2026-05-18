using Inspection.Application.Contracts.Dto.AccountingDtos.AccountBalance;
using Inspection.Domain.Models.Accounting.AccountBalance;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Services.Accounting.AccountBalances
{
    public interface IAccountBalanceService
    {
        Task<ReturnBase<AccountBalanceDto>> Create(AccountBalanceCreateDto createDto);
        Task<ReturnBase<AccountBalanceDto>> Update(AccountBalanceUpdateDto updateDto);
        Task<ReturnBase<AccountBalanceDto>> Delete(long id);
        Task<ReturnBase<AccountBalanceDto>> GetById(long id);
        Task<AccountBalance?> GetByItemAsync(string tenantId, long companyId, long? chartOfAccountId);
        //Task<ReturnBase<IEnumerable<AccountBalanceReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions);
    }
}