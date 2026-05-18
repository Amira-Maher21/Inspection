using Inspection.Application.Contracts.Dto.EquipmentManagement.EquipmentSoftwares;
using Inspection.Application.Contracts.Repositories.Query.EquipmentManagement.EquipmentSoftwares;
using Inspection.Domain.Models.EquipmentManagement.EquipmentSoftwares;
using Inspection.Infrastructure.QueryObjects.EquipmentManagment.EquipmentSoftwares;
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

namespace Inspection.Infrastructure.Repositories.Query.EquipmentManagement.EquipmentSoftwares
{
    
    public class EquipmentSoftwareQueryRepository : QueryRepositoryBase<EquipmentSoftware>, IEquipmentSoftwareQueryRepository
    {
        public EquipmentSoftwareQueryRepository(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(queryBuilder, dapper, context, tenantResolver, exceptionManager)
        {
        }



        public async Task<EquipmentSoftware?> GetByIdAsync(long id)
        {
            return await _context.Set<EquipmentSoftware>().Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<ReturnBase<IEnumerable<EquipmentSoftwareDtoByInclude>>> GetListAsync(SqlQueryOptions sqlQueryOptions)
        {
            var EquipmentSoftwareQueryRepository = new EquipmentSoftwareQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);
            return await EquipmentSoftwareQueryRepository.Query(sqlQueryOptions);//Query(EquipmentSoftwareDto, sqlQueryOptions);
        }

        public async Task<ReturnBase<IEnumerable<EquipmentSoftwareDtoByInclude>>> GetListIncludeNameAsync(SqlQueryOptions sqlQueryOptions)
        {

            var EquipmentSoftwareQuery = new EquipmentSoftwareQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);
            return await Query(EquipmentSoftwareQuery, sqlQueryOptions);

        }

        public async Task<ReturnBase<IEnumerable<EquipmentSoftwareDtoByInclude>>> GetLookUpEquipmentSoftwareForNamesAsync(SqlQueryOptions queryOptions)
        {
            var EquipmentSoftwareQueryRepository = new EquipmentSoftwareQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);

            return await EquipmentSoftwareQueryRepository.Query(queryOptions);


        }

        //public async Task<ReturnBase<IEnumerable<EquipmentSoftwareDto>>> GetListAsync(SqlQueryOptions sqlQueryOptions)
        //{
        //    //var EquipmentSoftwareQueryRepository = new EquipmentSoftwareQueryRepository(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);
        //    //return await Query(EquipmentSoftwareQueryRepository, sqlQueryOptions);
        //}
    }

}
