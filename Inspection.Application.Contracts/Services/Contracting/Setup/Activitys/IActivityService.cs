using Inspection.Application.Contracts.Dto.ContractingDTOs.Setup.Activitys;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Services.Contracting.Setup.Activitys
{
    public interface IActivityService
    {
        Task<ReturnBase<ActivityDto>> Create(ActivityCreateDto createDto);
        Task<ReturnBase<ActivityDto>> Update(ActivityUpdaeDto updateDto);
        Task<ReturnBase<ActivityDto>> Delete(long id);
        Task<ReturnBase<ActivityDto>> GetById(long id);
        Task<ReturnBase<IEnumerable<ActivityReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions);
    }
}