using Inspection.Application.Contracts.Dto.AccountingDtos.PR.MasterData.SupplierGroups;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Services.Accounting.PR.MasterData.SupplierGroups
{
    public interface ISupplierGroupService
    {
        Task<ReturnBase<SupplierGroupDto>> Create(SupplierGroupCreateDto createDto);
        Task<ReturnBase<SupplierGroupDto>> Update(SupplierGroupUpdateDto updateDt);
        Task<ReturnBase<SupplierGroupDto>> Delete(long id);
        Task<ReturnBase<SupplierGroupDto>> GetById(long id);
        Task<ReturnBase<List<SupplierGroupDto>>> GetAll();
        Task<ReturnBase<IEnumerable<SupplierGroupReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions);
    }
}
