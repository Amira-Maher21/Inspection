using Inspection.Application.Contracts.Dto.EquipmentManagement.Series;
using Inspection.Application.Contracts.Dto.MenuManagement.AreaF;
using Inspection.Application.Contracts.Dto.MenuManagement.BranchF;
using Inspection.Domain.Models.MenuManagement;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Kernel.BaseReturnTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Contracts.Services.MenuManagement.AreaF
{
    public interface IAreaService : IAccountServiceBase
    {
        Task<ReturnBase<AreaDto>> GetAsync(long id);

        Task<ReturnBase<List<AreaIncludeDto>>> GetListByIncludeAsync(SqlQueryOptions sqlQueryOptions);
        Task<ReturnBase<List<AreaLookupDefaultDto>>> AreaLookupDefault(SqlQueryOptions sqlQueryOptions);
        Task<ReturnBase<List<AreaDto>>> GetListAsync();
        Task<ReturnBase<UpdateAreaDto>> CreateAsync(CreateAreaDto input);

        Task<ReturnBase<UpdateAreaDto>> UpdateAsync(long id, UpdateAreaDto input);
        Task<ReturnBase<bool>> DeleteAsync(long id);
    }
}
