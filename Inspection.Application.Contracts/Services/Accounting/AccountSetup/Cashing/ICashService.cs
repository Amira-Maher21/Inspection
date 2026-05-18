using Inspection.Application.Contracts.Dto.AccountingDtos.AccountingSetupDtos.Cashing;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Services.Accounting.AccountSetup.Cashing
{
    public interface ICashService
    {
        Task<ReturnBase<CashDto>> Create(CashCreateDto createDto);
        Task<ReturnBase<CashDto>> Update(CashUpdateDto updateDto);
        Task<ReturnBase<CashDto>> Delete(long id);
        Task<ReturnBase<CashDto>> GetById(long id);
        Task<ReturnBase<List<CashDto>>> GetAll();
        Task<ReturnBase<IEnumerable<CashReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions);
    }
}
