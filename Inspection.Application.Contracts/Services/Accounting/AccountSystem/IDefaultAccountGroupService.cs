using Inspection.Application.Contracts.Dto.AccountingDtos.AccountSystemDto.DefaultAccountGroup;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Services.Accounting.AccountSystem
{
    public interface IDefaultAccountGroupService
    {
        Task<ReturnBase<DefaultAccountGroupDto>> Create(DefaultAccountGroupCreateDto createDto);
        Task<ReturnBase<DefaultAccountGroupDto>> Update(DefaultAccountGroupUpdateDto updateDto);
        Task<ReturnBase<DefaultAccountGroupDto>> Delete(long id);
        Task<ReturnBase<DefaultAccountGroupDto>> GetById(long id);
        Task<ReturnBase<List<DefaultAccountGroupDto>>> GetAll();
        Task<ReturnBase<IEnumerable<DefaultAccountGroupDto>>> Search(SqlQueryOptions sqlQueryOptions);


    }
}
