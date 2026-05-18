using Inspection.Application.Contracts.Dto.EquipmentManagement.EquipmentCategorys;
using Inspection.Application.Contracts.Repositories.Query.EquipmentManagement.EquipmentCategorys;
using Inspection.Domain.Models.EquipmentManagement.EquipmentCategorys;
using Inspection.Infrastructure.QueryObjects.EquipmentManagment.EquipmentCategorys;
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

namespace Inspection.Infrastructure.Repositories.Query.EquipmentManagement.EquipmentCategorys
{
   

 

    public class EquipmentCategoryQueryRepository : QueryRepositoryBase<EquipmentCategory>, IEquipmentCategoryQueryRepository
    {
        public EquipmentCategoryQueryRepository(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(queryBuilder, dapper, context, tenantResolver, exceptionManager)
        {
        }



        public async Task<EquipmentCategory?> GetByIdAsync(long id)
        {
            return await _context.Set<EquipmentCategory>().Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<ReturnBase<IEnumerable<EquipmentCategoryDtoByInclude>>> GetListAsync(SqlQueryOptions sqlQueryOptions)
        {
            var EquipmentCategoryQueryRepository = new EquipmentCategoryQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);
            return await EquipmentCategoryQueryRepository.Query(sqlQueryOptions);
        }

        public async Task<ReturnBase<IEnumerable<EquipmentCategoryDtoByInclude>>> GetListIncludeNameAsync(SqlQueryOptions sqlQueryOptions)
        {

            var EquipmentCategoryQuery = new EquipmentCategoryQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);
            return await Query(EquipmentCategoryQuery, sqlQueryOptions);

        }

        public async Task<ReturnBase<IEnumerable<EquipmentCategoryDtoByInclude>>> GetLookUpEquipmentCategoryForNamesAsync(SqlQueryOptions queryOptions)
        {
            var EquipmentCategoryQueryRepository = new EquipmentCategoryQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);

            return await EquipmentCategoryQueryRepository.Query(queryOptions);


        }

        //public async Task<ReturnBase<IEnumerable<EquipmentCategoryDto>>> GetListAsync(SqlQueryOptions sqlQueryOptions)
        //{
        //    //var EquipmentCategoryQueryRepository = new EquipmentCategoryQueryRepository(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);
        //    //return await Query(EquipmentCategoryQueryRepository, sqlQueryOptions);
        //}
    }

}
