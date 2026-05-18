using Inspection.Application.Contracts.Dto.ContractingDTOs.Setup.CostCodes;
using Inspection.Application.Contracts.Repositories.Query.Contracting.Setup.CostCodes;
using Inspection.Domain.Models.Contracting.Setup.CostCodes;
using Inspection.Infrastructure.QueryObjects.Contracting.Setup.CostCodes;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.Repositories.Query.Contracting.CostCodes
{
    public class CostCodeQueryRepository : QueryRepositoryBase<CostCode>, ICostCodeQueryRepository
    {
        public CostCodeQueryRepository(
            ISqlQueryBuilder queryBuilder,
            DapperDbContext dapper,
            DbContext context,
            ITenantResolver tenantResolver,
            IExceptionManager exceptionManager)
            : base(queryBuilder, dapper, context, tenantResolver, exceptionManager)
        {
        }

        public async Task<CostCode?> GetById(long id)
        {
            return await _context.Set<CostCode>()
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
        }



        public async Task<ReturnBase<IEnumerable<CostCodeReturnSearchDto>>> Search(SqlQueryOptions options)
        {
            var query = new CostCodeQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);
            return await query.Query(options);
        }
    }
}