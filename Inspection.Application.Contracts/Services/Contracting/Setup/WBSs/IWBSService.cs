using Inspection.Application.Contracts.Dto.ContractingDTOs.Setup.WBSs;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Services.Contracting.Setup.WBSs
{
    public interface IWBSService
    {
        Task<ReturnBase<WBSDto>> Create(WBSCreateDto createDto);
        Task<ReturnBase<WBSDto>> Update(WBSUpdateDto updateDto);
        Task<ReturnBase<WBSDto>> Delete(long id);
        Task<ReturnBase<WBSDto>> GetById(long id);
        Task<ReturnBase<IEnumerable<WBSReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions);
    }
}