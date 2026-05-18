using Inspection.Application.Contracts.Dto.ContractingDTOs.Setup.SubcontractBOQDTOs;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Services.Contracting.Setup.ISubcontractBOQs
{
    public interface ISubcontractBOQService
    {
        Task<ReturnBase<SubcontractBOQDto>> Create(SubcontractBOQCreateDto createDto);
        Task<ReturnBase<SubcontractBOQDto>> Update(SubcontractBOQUpdateDto updateDto);
        Task<ReturnBase<SubcontractBOQDto>> Delete(long id);
        Task<ReturnBase<SubcontractBOQDto>> GetById(long id);
        //Task<ReturnBase<List<SubcontractBOQDto>>> GetAll();
        Task<ReturnBase<IEnumerable<SubcontractBOQReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions);
    }
}