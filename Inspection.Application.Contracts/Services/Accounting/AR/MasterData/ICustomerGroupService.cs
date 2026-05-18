
using Inspection.Application.Contracts.Dto.AccountingDtos.AR.MasterData.CustomerGroup;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Services.Accounting.AR.MasterData
{
    public interface ICustomerGroupService
    {
        Task<ReturnBase<CustomerGroupDto>> Create(CustomerGroupCreateDto createDto);
        Task<ReturnBase<CustomerGroupDto>> Update(CustomerGroupUpdateDto updateDto);
        Task<ReturnBase<CustomerGroupDto>> Delete(long id);
        Task<ReturnBase<CustomerGroupDto>> GetById(long id);
        Task<ReturnBase<List<CustomerGroupDto>>> GetAll();
        Task<ReturnBase<IEnumerable<CustomerGroupReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions);
    }
}
