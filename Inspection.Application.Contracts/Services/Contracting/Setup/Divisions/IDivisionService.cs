using Inspection.Application.Contracts.Dto.ContractingDTOs.Setup.Divisions;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Services.Contracting.Setup.Divisions
{
    public interface IDivisionService
    {
        Task<ReturnBase<DivisionDto>> Create(DivisionCreateDto createDto);
        Task<ReturnBase<DivisionDto>> Update(DivisionUpdateDto updateDto);
        Task<ReturnBase<DivisionDto>> Delete(long id);
        Task<ReturnBase<DivisionDto>> GetById(long id);
        Task<ReturnBase<IEnumerable<DivisionReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions);
    }
}