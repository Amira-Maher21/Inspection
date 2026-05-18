 using Inspection.Application.Contracts.Dto.InspectionManagement.ServicesItemsF;
using Inspection.Application.Contracts.Repositories.Query.InspectionManagement.ServicesItemsF;
using Inspection.Domain.Models.InspectionManagement.ServicesItems;
 using Inspection.Infrastructure.QueryObjects.InspectionManagement.ServicesItemsF;
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

namespace Inspection.Infrastructure.Repositories.Query.InspectionManagement.ServicesItemsF
{
    
    public class ServiceItemQueryRepository : QueryRepositoryBase<ServiceItem>, IServiceItemQueryRepository
    {
        public ServiceItemQueryRepository(ISqlQueryBuilder sqlQueryBuilder, DapperDbContext dapperDbContext, DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(sqlQueryBuilder, dapperDbContext, context, tenantResolver, exceptionManager)
        {
        }

     
        public async Task<ServiceItem?> GetByIdAsync(long id) => await _dbSet.FirstOrDefaultAsync(x => x.Id == id);

        public async Task<IEnumerable<ServiceItemIncludeDto?>> GetListByIncludeAsync(SqlQueryOptions sqlQueryOptions)
        {
            var ServicesItemsQueryRepository = new ServicesItemsQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);
            var result = await ServicesItemsQueryRepository.Query(sqlQueryOptions);
            return result.Result;
        }

       
        
    }
}
