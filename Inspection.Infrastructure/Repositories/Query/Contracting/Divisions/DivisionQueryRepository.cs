using Inspection.Application.Contracts.Dto.ContractingDTOs.Setup.Divisions;
using Inspection.Application.Contracts.Repositories.Query.Contracting.Setup.Divisions;
using Inspection.Domain.Models.Contracting.Setup.Divisions;
using Inspection.Infrastructure.QueryObjects.Contracting.Setup.Divisions;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.Repositories.Query.Contracting.Divisions
{
    public class DivisionQueryRepository : QueryRepositoryBase<Division>, IDivisionQueryRepository
    {
        public DivisionQueryRepository(
            ISqlQueryBuilder queryBuilder,
            DapperDbContext dapper,
            DbContext context,
            ITenantResolver tenantResolver,
            IExceptionManager exceptionManager)
            : base(queryBuilder, dapper, context, tenantResolver, exceptionManager)
        {
        }

        public async Task<Division?> GetById(long id)
        {
            return await _context.Set<Division>()
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
        }



        public async Task<ReturnBase<IEnumerable<DivisionReturnSearchDto>>> Search(SqlQueryOptions options)
        {
            var query = new DivisionQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);
            return await query.Query(options);
        }
    }
}