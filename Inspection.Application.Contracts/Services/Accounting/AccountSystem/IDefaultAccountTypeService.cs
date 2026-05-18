using Inspection.Application.Contracts.Dto.AccountingDtos.AccountSystemDto.DefaultAccountTypeDto;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Services.Accounting.AccountSystem
{
    public interface IDefaultAccountTypeService
    {
        Task<ReturnBase<DefaultAccountTypeDto>> Create(DefaultAccountTypeCreateDto createDto);
        Task<ReturnBase<DefaultAccountTypeDto>> Update(DefaultAccountTypeUpdateDto updateDto);
        Task<ReturnBase<DefaultAccountTypeDto>> Delete(long id);
        Task<ReturnBase<DefaultAccountTypeDto>> GetById(long id);
        Task<ReturnBase<List<DefaultAccountTypeDto>>> GetAll();
        Task<ReturnBase<IEnumerable<DefaultAccountTypeReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions);


    }
}
