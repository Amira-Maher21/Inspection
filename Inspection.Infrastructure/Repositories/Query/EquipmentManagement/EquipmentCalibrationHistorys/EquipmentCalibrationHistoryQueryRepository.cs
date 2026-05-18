using Inspection.Application.Contracts.Dto.EquipmentManagement.EquipmentCalibrationHistorys;
using Inspection.Application.Contracts.Repositories.Query.EquipmentManagement.EquipmentCalibrationHistorys;
using Inspection.Domain.Models.EquipmentManagement.EquipmentCalibrationHistorys;
using Inspection.Infrastructure.QueryObjects.EquipmentManagment.EquipmentCalibrationHistorys;
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

namespace Inspection.Infrastructure.Repositories.Query.EquipmentManagement.EquipmentCalibrationHistorys
{
   

    public class EquipmentCalibrationHistoryQueryRepository : QueryRepositoryBase<EquipmentCalibrationHistory>, IEquipmentCalibrationHistoryQueryRepository
    {
        public EquipmentCalibrationHistoryQueryRepository(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(queryBuilder, dapper, context, tenantResolver, exceptionManager)
        {
        }



        public async Task<EquipmentCalibrationHistory?> GetByIdAsync(long id)
        {
            return await _context.Set<EquipmentCalibrationHistory>().Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<ReturnBase<IEnumerable<EquipmentCalibrationHistoryDtoByInclude>>> GetListAsync(SqlQueryOptions sqlQueryOptions)
        {
            var EquipmentCalibrationHistoryQueryRepository = new EquipmentCalibrationHistoryQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);
            return await EquipmentCalibrationHistoryQueryRepository.Query(sqlQueryOptions);//Query(EquipmentCalibrationHistoryDto, sqlQueryOptions);
        }

        public async Task<ReturnBase<IEnumerable<EquipmentCalibrationHistoryDtoByInclude>>> GetListIncludeNameAsync(SqlQueryOptions sqlQueryOptions)
        {

            var EquipmentCalibrationHistoryQuery = new EquipmentCalibrationHistoryQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);
            return await Query(EquipmentCalibrationHistoryQuery, sqlQueryOptions);

        }

        public async Task<ReturnBase<IEnumerable<EquipmentCalibrationHistoryDtoByInclude>>> GetLookUpEquipmentCalibrationHistoryForNamesAsync(SqlQueryOptions queryOptions)
        {
            var EquipmentCalibrationHistoryQueryRepository = new EquipmentCalibrationHistoryQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);

            return await EquipmentCalibrationHistoryQueryRepository.Query(queryOptions);


        }

        //public async Task<ReturnBase<IEnumerable<EquipmentCalibrationHistoryDto>>> GetListAsync(SqlQueryOptions sqlQueryOptions)
        //{
        //    //var EquipmentCalibrationHistoryQueryRepository = new EquipmentCalibrationHistoryQueryRepository(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);
        //    //return await Query(EquipmentCalibrationHistoryQueryRepository, sqlQueryOptions);
        //}
    }

}
