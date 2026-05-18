using Inspection.Application.Contracts.Dto.MenuManagement.AreaF;
using Inspection.Application.Contracts.Repositories.Query.MenuManagement.AreaF;
using Inspection.Application.Contracts.Repositories.Query.MenuManagement.BranchF;
using Inspection.Domain.Models.MenuManagement;
using Inspection.Infrastructure.QueryObjects.MenuManagement.AreaF;
using Inspection.Infrastructure.QueryObjects.MenuManagement.BranchF;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Infrastructure.Repositories.Query.MenuManagement.AreaF
{
    public class AreaQueryRepository : QueryRepositoryBase<Area>, IAreaQueryRepository
    {

        public AreaQueryRepository(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(queryBuilder, dapper, context, tenantResolver, exceptionManager)
        {

        }

        public async Task<Area?> GetByIdAsync(long id) => await _dbSet.FirstOrDefaultAsync(x => x.Id == id);

        public async Task<IEnumerable<AreaIncludeDto?>> GetListByIncludeAsync(SqlQueryOptions sqlQueryOptions)
        {
            var AreaesQueryRepository = new AreaesQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);
            var result = await AreaesQueryRepository.Query(sqlQueryOptions);
            return result.Result;
        }
    }
}
