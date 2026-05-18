using Inspection.Application.Contracts.Dto.MenuManagement.Screen_permissions;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Services.MenuManagement.Screen_permissions
{

    public interface IScreen_permissionService : IAccountServiceBase
    {

        Task<ReturnBase<Screen_permissionDto>> InsertScreen_permissionAsync(CreateScreen_permissionDto insertDto);
        Task<ReturnBase<Screen_permissionDto>> UpdateScreen_permissionAsync(UpdateScreen_permissionDto updateDto);
        Task<ReturnBase<Screen_permissionDto>> DeleteScreen_permissionAsync(string id);
        Task<ReturnBase<Screen_permissionDto>> GetScreen_permissionByIdAsync(string id);
        //Task<ReturnBase<IEnumerable<Screen_permissionDtoByInclude>>> GetScreen_permissionListAsync(SqlQueryOptions sqlQueryOptions);
        Task<List<Screen_permissionDto>> GetListAsync();
        Task<ReturnBase<IEnumerable<Screen_permissionReturnSearchDto>>> GetScreen_permissionListByIncludeAsync(SqlQueryOptions sqlQueryOptions);

        //Task<ReturnBase<IEnumerable<Screen_permissionDtoLookUpForNames>>> GetLookUpScreen_permissionForNamesAsync(SqlQueryOptions queryOptions);

    }
}
