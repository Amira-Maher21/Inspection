using Inspection.Application.Contracts.Dto.EquipmentManagement.EquipmentTypes;
using Inspection.Application.Contracts.Repositories.Query.InspectionManagement.EquipmentTypes;
using Inspection.Domain.Models.EquipmentManagement.EquipmentTypes;
using Inspection.Infrastructure.QueryObjects.EquipmentManagment.EquipmentTypes;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.Repositories.Query.EquipmentManagement.EquipmentTypes
{

    public class EquipmentTypeQueryRepository : QueryRepositoryBase<EquipmentType>, IEquipmentTypeQueryRepository
    {
        public EquipmentTypeQueryRepository(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(queryBuilder, dapper, context, tenantResolver, exceptionManager)
        {
        }



        public async Task<EquipmentType?> GetByIdAsync(long id)
        {
            return await _context.Set<EquipmentType>().Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<ReturnBase<IEnumerable<EquipmentTypeDtoByInclude>>> GetListAsync(SqlQueryOptions sqlQueryOptions)
        {
            var EquipmentTypeQueryRepository = new EquipmentTypeQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);
            return await EquipmentTypeQueryRepository.Query(sqlQueryOptions);
        }

        public async Task<ReturnBase<IEnumerable<EquipmentTypeDtoByInclude>>> GetListIncludeNameAsync(SqlQueryOptions sqlQueryOptions)
        {

            var EquipmentTypeQuery = new EquipmentTypeQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);
            return await Query(EquipmentTypeQuery, sqlQueryOptions);

        }

        public async Task<ReturnBase<IEnumerable<EquipmentTypeDtoByInclude>>> GetLookUpEquipmentTypeForNamesAsync(SqlQueryOptions queryOptions)
        {
            var EquipmentTypeQueryRepository = new EquipmentTypeQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);

            return await EquipmentTypeQueryRepository.Query(queryOptions);


        }
        public async Task<EquipmentType> GetByCode(string code)
        {
            return await _context.Set<EquipmentType>().Where(x => x.Code == code).FirstOrDefaultAsync();
        }

        //public async Task<ReturnBase<IEnumerable<EquipmentTypeDto>>> GetListAsync(SqlQueryOptions sqlQueryOptions)
        //{
        //    //var EquipmentTypeQueryRepository = new EquipmentTypeQueryRepository(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);
        //    //return await Query(EquipmentTypeQueryRepository, sqlQueryOptions);
        //}
    }

}
