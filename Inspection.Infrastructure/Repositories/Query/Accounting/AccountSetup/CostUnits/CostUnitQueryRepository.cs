using Inspection.Application.Contracts.Dto.AccountingDtos.AccountingSetupDtos.CostUnitDTOs;
using Inspection.Application.Contracts.Repositories.Query.Accounting.AccountSetup.CostUnits;
using Inspection.Domain.Models.Accounting.AccountingSetup.CostUnits;
using Inspection.Infrastructure.QueryObjects.Accounting.AccountSetup.CostUnits;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.Repositories.Query.Accounting.AccountSetup.CostUnits
{
    public class CostUnitQueryRepository : QueryRepositoryBase<CostUnit>, ICostUnitQueryRepository
    {
        public CostUnitQueryRepository(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(queryBuilder, dapper, context, tenantResolver, exceptionManager)
        {
        }

        public async Task<CostUnit?> GetById(long id)
        {
            return await _context.Set<CostUnit>().Where(x => x.Id == id).FirstOrDefaultAsync();
        }
        public async Task<CostUnit?> GetByCode(string code)
        {
            return await _context.Set<CostUnit>().Where(x => x.Code == code).FirstOrDefaultAsync();
        }

        //public async Task<List<CostUnit>> GetAll(string tenantId)
        //{
        //    return await _context.Set<CostUnit>()
        //                         .AsNoTracking()
        //                         .Where(x => x.Tenant_ID == tenantId)
        //                         .ToListAsync();
        //}
        public async Task<ReturnBase<IEnumerable<CostUnitDto>>> Search(SqlQueryOptions sqlQueryOptions)
        {
            var CostUnitQueryRepository = new CostUnitQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);
            return await CostUnitQueryRepository.Query(sqlQueryOptions);
        }
    }
}