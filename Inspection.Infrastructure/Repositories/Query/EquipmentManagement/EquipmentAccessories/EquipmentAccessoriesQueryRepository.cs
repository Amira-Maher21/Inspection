using Inspection.Application.Contracts.Dto.EquipmentManagement.EquipmentAccessories;
using Inspection.Application.Contracts.Repositories.Query.EquipmentManagement.EquipmentAccessories;
using Inspection.Domain.Models.EquipmentManagement.EquipmentAccessories;
using Inspection.Infrastructure.QueryObjects.EquipmentManagment.EquipmentAccessories;
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

namespace Inspection.Infrastructure.Repositories.Query.EquipmentManagement.EquipmentAccessories
{

    public class EquipmentAccessoriesQueryRepository : QueryRepositoryBase<EquipmentAccessory>, IEquipmentAccessoryQueryRepository
    {
        public EquipmentAccessoriesQueryRepository(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(queryBuilder, dapper, context, tenantResolver, exceptionManager)
        {
        }



        public async Task<EquipmentAccessory?> GetByIdAsync(long id)
        {
            return await _context.Set<EquipmentAccessory>().Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<ReturnBase<IEnumerable<EquipmentAccessoryDtoByInclude>>> GetListAsync(SqlQueryOptions sqlQueryOptions)
        {
            var EquipmentAccessoryQueryRepository = new EquipmentAccessoriesQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);
            return await EquipmentAccessoryQueryRepository.Query(sqlQueryOptions);//Query(EquipmentAccessoryDto, sqlQueryOptions);
        }

        public async Task<ReturnBase<IEnumerable<EquipmentAccessoryDtoByInclude>>> GetListIncludeNameAsync(SqlQueryOptions sqlQueryOptions)
        {

            var EquipmentAccessoriesQuery = new EquipmentAccessoriesQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);
            return await Query(EquipmentAccessoriesQuery, sqlQueryOptions);

        }

        public async Task<ReturnBase<IEnumerable<EquipmentAccessoryDtoByInclude>>> GetLookUpEquipmentAccessoryForNamesAsync(SqlQueryOptions queryOptions)
        {
            var EquipmentAccessoriesQuery = new EquipmentAccessoriesQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);

            return await EquipmentAccessoriesQuery.Query(queryOptions);


        }

        //public async Task<ReturnBase<IEnumerable<EquipmentAccessoryDto>>> GetListAsync(SqlQueryOptions sqlQueryOptions)
        //{
        //    //var EquipmentAccessoryQueryRepository = new EquipmentAccessoryQueryRepository(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);
        //    //return await Query(EquipmentAccessoryQueryRepository, sqlQueryOptions);
        //}
    }

}
