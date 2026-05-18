using Inspection.Application.Contracts.Dto.EquipmentManagement.EquipmentsMoreInformations;
using Inspection.Application.Contracts.Dto.MenuManagement.BranchF;
using Inspection.Application.Contracts.Repositories.Query.EquipmentManagement.EquipmentsMoreInformations;
using Inspection.Application.Contracts.Repositories.Query.MenuManagement.BranchF;
using Inspection.Domain.Models.EquipmentManagement.EquipmentsMoreInfo;
using Inspection.Domain.Models.MenuManagement;
using Inspection.Infrastructure.QueryObjects.EquipmentManagment.EquipmentsMoreInformations;
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

namespace Inspection.Infrastructure.Repositories.Query.EquipmentManagement.EquipmentsMoreInformations
{
    public class EquipmentsMoreInformationQueryRepository : QueryRepositoryBase<EquipmentsMoreInformation>, IEquipmentsMoreInformationQueryRepository
    {

        public EquipmentsMoreInformationQueryRepository(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(queryBuilder, dapper, context, tenantResolver, exceptionManager)
        {

        }

        public async Task<EquipmentsMoreInformation?> GetByIdAsync(long id)
            => await _dbSet.Include(x => x.EquipmentsMoreInformationDetails).FirstOrDefaultAsync(x => x.Id == id);

      
        public async Task<IEnumerable<EquipmentsMoreInformationIncludeDto?>> GetListByIncludeAsync(SqlQueryOptions sqlQueryOptions)
        {
            var EquipmentsMoreInformationQueryRepository = new EquipmentsMoreInformationQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);
            var result = await EquipmentsMoreInformationQueryRepository.Query(sqlQueryOptions);
            return result.Result;
        }


    }
}
