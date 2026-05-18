using Inspection.Application.Contracts.Dto.ContractingDTOs.Setup.BOQDTOs;
using Inspection.Application.Contracts.Dto.ContractingDTOs.Setup.BOQDTOs.BOQLineDTOs;
using Inspection.Application.Contracts.Repositories.Query.Contracting.Setup.IBOQs;
using Inspection.Domain.Models.Contracting.Setup.BOQs;
using Inspection.Infrastructure.QueryObjects.Contracting.Setup.BOQs;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.Repositories.Query.Contracting.Setup.BOQs
{
    public class BOQQueryRepository : QueryRepositoryBase<BOQ>, IBOQQueryRepository
    {
        public BOQQueryRepository(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(queryBuilder, dapper, context, tenantResolver, exceptionManager)
        {
        }

        public async Task<ReturnBase<List<BOQ>>> GetAll()
        {
            var result = await _context.Set<BOQ>()
                .Include(x => x.BOQLines)
                .AsNoTracking().ToListAsync();
            return ReturnBase<List<BOQ>>.Success(result);
        }

        public async Task<BOQ?> GetById(long id)
        {
            return await _context.Set<BOQ>()
                .Include(x => x.BOQLines)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ReturnBase<IEnumerable<BOQReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions)
        {
            var bOQRepository = new BOQQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);
            return await bOQRepository.Query(sqlQueryOptions);
        }

        public async Task<ReturnBase<IEnumerable<BOQLineDto>>> SearchBOQLines(SqlQueryOptions sqlQueryOptions)
        {
            var bOQLineRepository = new BOQLineQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);
            return await bOQLineRepository.Query(sqlQueryOptions);
        }
    }
}