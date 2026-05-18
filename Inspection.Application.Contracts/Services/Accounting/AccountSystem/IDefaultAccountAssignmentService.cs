using Inspection.Application.Contracts.Dto.AccountingDtos.AccountSystemDto.DefaultAccountAssignment;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Services.Accounting.AccountSystem
{
    public interface IDefaultAccountAssignmentService
    {
        Task<ReturnBase<DefaultAccountAssignmentDto>> Create(DefaultAccountAssignmentCreateDto createDto);
        Task<ReturnBase<DefaultAccountAssignmentDto>> Update(DefaultAccountAssignmentUpdateDto updateDto);
        Task<ReturnBase<DefaultAccountAssignmentDto>> Delete(long id);
        Task<ReturnBase<DefaultAccountAssignmentDto>> GetById(long id);
        Task<ReturnBase<List<DefaultAccountAssignmentDto>>> GetAll();
        Task<ReturnBase<IEnumerable<DefaultAccountAssignmentReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions);


    }
}
