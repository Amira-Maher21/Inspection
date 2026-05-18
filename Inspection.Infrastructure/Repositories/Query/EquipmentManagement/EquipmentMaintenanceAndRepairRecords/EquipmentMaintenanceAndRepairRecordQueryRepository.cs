using Inspection.Application.Contracts.Dto.EquipmentManagement.EquipmentMaintenanceAndRepairRecords;
using Inspection.Application.Contracts.Repositories.Query.EquipmentManagement.EquipmentMaintenanceAndRepairRecords;
using Inspection.Domain.Models.EquipmentManagement.EquipmentMaintenanceAndRepairRecords;
using Inspection.Infrastructure.QueryObjects.EquipmentManagment.EquipmentMaintenanceAndRepairRecords;
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

namespace Inspection.Infrastructure.Repositories.Query.EquipmentManagement.EquipmentMaintenanceAndRepairRecords
{
 

    public class EquipmentMaintenanceAndRepairRecordQueryRepository : QueryRepositoryBase<EquipmentMaintenanceAndRepairRecord>, IEquipmentMaintenanceAndRepairRecordQueryRepository
    {
        public EquipmentMaintenanceAndRepairRecordQueryRepository(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(queryBuilder, dapper, context, tenantResolver, exceptionManager)
        {
        }



        public async Task<EquipmentMaintenanceAndRepairRecord?> GetByIdAsync(long id)
        {
            return await _context.Set<EquipmentMaintenanceAndRepairRecord>().Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<ReturnBase<IEnumerable<EquipmentMaintenanceAndRepairRecordDtoByInclude>>> GetListAsync(SqlQueryOptions sqlQueryOptions)
        {
            var EquipmentMaintenanceAndRepairRecordQueryRepository = new EquipmentMaintenanceAndRepairRecordQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);
            return await EquipmentMaintenanceAndRepairRecordQueryRepository.Query(sqlQueryOptions);//Query(EquipmentMaintenanceAndRepairRecordDto, sqlQueryOptions);
        }

        public async Task<ReturnBase<IEnumerable<EquipmentMaintenanceAndRepairRecordDtoByInclude>>> GetListIncludeNameAsync(SqlQueryOptions sqlQueryOptions)
        {

            var EquipmentMaintenanceAndRepairRecordQuery = new EquipmentMaintenanceAndRepairRecordQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);
            return await Query(EquipmentMaintenanceAndRepairRecordQuery, sqlQueryOptions);

        }

        public async Task<ReturnBase<IEnumerable<EquipmentMaintenanceAndRepairRecordDtoByInclude>>> GetLookUpEquipmentMaintenanceAndRepairRecordForNamesAsync(SqlQueryOptions queryOptions)
        {
            var EquipmentMaintenanceAndRepairRecordQueryRepository = new EquipmentMaintenanceAndRepairRecordQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);

            return await EquipmentMaintenanceAndRepairRecordQueryRepository.Query(queryOptions);


        }

        //public async Task<ReturnBase<IEnumerable<EquipmentMaintenanceAndRepairRecordDto>>> GetListAsync(SqlQueryOptions sqlQueryOptions)
        //{
        //    //var EquipmentMaintenanceAndRepairRecordQueryRepository = new EquipmentMaintenanceAndRepairRecordQueryRepository(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);
        //    //return await Query(EquipmentMaintenanceAndRepairRecordQueryRepository, sqlQueryOptions);
        //}
    }

}
