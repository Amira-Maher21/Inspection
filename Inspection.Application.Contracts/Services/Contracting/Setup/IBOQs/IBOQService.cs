using Inspection.Application.Contracts.Dto.ContractingDTOs.Setup.BOQDTOs;
using Inspection.Application.Contracts.Dto.ContractingDTOs.Setup.BOQDTOs.BOQLineDTOs;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Services.Contracting.Setup.IBOQs
{
    public interface IBOQService
    {
        Task<ReturnBase<BOQDto>> Create(BOQCreateDto createDto);
        Task<ReturnBase<BOQDto>> Update(BOQUpdateDto updateDto);
        Task<ReturnBase<BOQDto>> Delete(long id);
        Task<ReturnBase<BOQDto>> GetById(long id);
        //Task<ReturnBase<List<BOQDto>>> GetAll();
        Task<ReturnBase<IEnumerable<BOQReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions);
        Task<ReturnBase<IEnumerable<BOQLineDto>>> SearchBOQLines(SqlQueryOptions sqlQueryOptions);
    }
}