using Inspection.Application.Contracts.Dto.AccountingDtos.AccountingSetupDtos.Branches;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Services.Accounting.AccountSetup.Branches
{
    public interface IBranchService
    {
        Task<ReturnBase<BranchDto>> Create(BranchCreateDto createDto);
        Task<ReturnBase<BranchDto>> Update(BranchUpdateDto updateDto);
        Task<ReturnBase<BranchDto>> Delete(long id);
        Task<ReturnBase<BranchDto>> GetById(long id);
        Task<ReturnBase<List<BranchDto>>> GetAll();
        Task<ReturnBase<IEnumerable<BranchReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions);
    }
}
