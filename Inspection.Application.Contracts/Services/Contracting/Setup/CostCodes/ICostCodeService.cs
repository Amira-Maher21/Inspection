using Inspection.Application.Contracts.Dto.ContractingDTOs.Setup.CostCodes;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Services.Contracting.Setup.CostCodes
{
    public interface ICostCodeService
    {
        Task<ReturnBase<CostCodeDto>> Create(CostCodeCreateDto createDto);
        Task<ReturnBase<CostCodeDto>> Update(CostCodeUpdateDto updateDto);
        Task<ReturnBase<CostCodeDto>> Delete(long id);
        Task<ReturnBase<CostCodeDto>> GetById(long id);
        Task<ReturnBase<IEnumerable<CostCodeReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions);
    }
}