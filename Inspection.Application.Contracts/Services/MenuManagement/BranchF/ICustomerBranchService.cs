using Inspection.Application.Contracts.Dto.MenuManagement.BranchF;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Services.MenuManagement.BranchF
{
    public interface ICustomerBranchService : IAccountServiceBase
    {
        Task<ReturnBase<CustomerBranchDto>> GetAsync(long id);

        Task<ReturnBase<List<CustomerBranchIncludeDto>>> GetListByIncludeAsync(SqlQueryOptions sqlQueryOptions);
        Task<ReturnBase<List<CustomerBranchLookupDefualtDto>>> BranchLookupDefualt(SqlQueryOptions sqlQueryOptions);
        Task<ReturnBase<List<CustomerBranchDto>>> GetListAsync();
        Task<ReturnBase<UpdateCustomerBranchDto>> CreateAsync(CreateCustomerBranchDto input);

        Task<ReturnBase<UpdateCustomerBranchDto>> UpdateAsync(long id, UpdateCustomerBranchDto input);
        Task<ReturnBase<bool>> DeleteAsync(long id);
    }
}
