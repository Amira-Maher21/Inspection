using Inspection.Application.Contracts.Dto.TestTableMasters;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Services.TestTableMasters
{
    public interface ITestTableMasterService : IAccountServiceBase
    {
        Task<ReturnBase> DeleteByIdAsync(long id);
        Task<ReturnBase<CreateTestTableMasterDto>> InsertTestTableMasterAsync(CreateTestTableMasterDto insertDto);
        Task<ReturnBase<UpdateTestTableMasterDto>> UpdateTestTableMasterAsync(UpdateTestTableMasterDto updatetDto);

    }
}
