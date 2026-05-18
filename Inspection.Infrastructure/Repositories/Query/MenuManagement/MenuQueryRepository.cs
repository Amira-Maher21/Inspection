using Inspection.Application.Contracts.Dto.MenuManagement;
using Inspection.Application.Contracts.Repositories.Query.MenuManagement;
 using Inspection.Domain.Models.MenuManagement;
using Inspection.Infrastructure.QueryObjects.MenuManagement;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Infrastructure.Repositories.Query.MenuManagement
{
    public class MenuQueryRepository : QueryRepositoryBase<MenuDto>, IMenuQueryRepository
    {
        public MenuQueryRepository(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(queryBuilder, dapper, context, tenantResolver, exceptionManager)
        {
        }

        public async Task<ReturnBase<IEnumerable<MenuDto>>> GetMenuListAsync(MenuRequest requestDto)
        {
            var menuList = new MenuQuery(_queryBuilder, _dapper,_tenantResolver, _exceptionManager);
            return await Query(menuList, requestDto.SqlQueryOptions, requestDto.FunctionParameters);
        }
        
        public async Task<Menu?> GetByIdAsync(string id)
        {
            return await _context.Set<Menu>().Where(x => x.Menu_ID == id).FirstOrDefaultAsync();
        }

    }
}
