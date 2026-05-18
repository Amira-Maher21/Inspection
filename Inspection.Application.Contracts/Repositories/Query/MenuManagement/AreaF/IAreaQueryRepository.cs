using Inspection.Application.Contracts.Dto.MenuManagement.AreaF;
using Inspection.Application.Contracts.Dto.MenuManagement.BranchF;
using Inspection.Domain.Models.MenuManagement;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.RepositoryBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Contracts.Repositories.Query.MenuManagement.AreaF
{
    public interface IAreaQueryRepository : IQueryRepository<Area>
    {
        Task<Area?> GetByIdAsync(long id);
        Task<IEnumerable<AreaIncludeDto?>> GetListByIncludeAsync(SqlQueryOptions sqlQueryOptions);

    }
}
