using Inspection.Application.Contracts.Dto.EquipmentManagement.EquipmentPreventiveMaintenances;
using Inspection.Application.Contracts.Repositories.Query.EquipmentManagement.EquipmentPreventiveMaintenances;
using Inspection.Domain.Models.EquipmentManagement.EquipmentPreventiveMaintenances;
using Inspection.Infrastructure.QueryObjects.EquipmentManagment.EquipmentPreventiveMaintenances;
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

namespace Inspection.Infrastructure.Repositories.Query.EquipmentManagement.EquipmentPreventiveMaintenances
{
 

    public class EquipmentPreventiveMaintenanceQueryRepository : QueryRepositoryBase<EquipmentPreventiveMaintenance>, IEquipmentPreventiveMaintenanceQueryRepository
    {
        public EquipmentPreventiveMaintenanceQueryRepository(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(queryBuilder, dapper, context, tenantResolver, exceptionManager)
        {
        }



        public async Task<EquipmentPreventiveMaintenance?> GetByIdAsync(long id)
        {
            return await _context.Set<EquipmentPreventiveMaintenance>().Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<ReturnBase<IEnumerable<EquipmentPreventiveMaintenanceDtoByInclude>>> GetListAsync(SqlQueryOptions sqlQueryOptions)
        {
            var EquipmentPreventiveMaintenanceQueryRepository = new EquipmentPreventiveMaintenanceQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);
            return await EquipmentPreventiveMaintenanceQueryRepository.Query(sqlQueryOptions);//Query(EquipmentPreventiveMaintenanceDto, sqlQueryOptions);
        }

        public async Task<ReturnBase<IEnumerable<EquipmentPreventiveMaintenanceDtoByInclude>>> GetListIncludeNameAsync(SqlQueryOptions sqlQueryOptions)
        {

            var EquipmentPreventiveMaintenanceQuery = new EquipmentPreventiveMaintenanceQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);
            return await Query(EquipmentPreventiveMaintenanceQuery, sqlQueryOptions);

        }

        public async Task<ReturnBase<IEnumerable<EquipmentPreventiveMaintenanceDtoByInclude>>> GetLookUpEquipmentPreventiveMaintenanceForNamesAsync(SqlQueryOptions queryOptions)
        {
            var EquipmentPreventiveMaintenanceQueryRepository = new EquipmentPreventiveMaintenanceQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);

            return await EquipmentPreventiveMaintenanceQueryRepository.Query(queryOptions);


        }

        //public async Task<ReturnBase<IEnumerable<EquipmentPreventiveMaintenanceDto>>> GetListAsync(SqlQueryOptions sqlQueryOptions)
        //{
        //    //var EquipmentPreventiveMaintenanceQueryRepository = new EquipmentPreventiveMaintenanceQueryRepository(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);
        //    //return await Query(EquipmentPreventiveMaintenanceQueryRepository, sqlQueryOptions);
        //}
    }

}
