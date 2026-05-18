using Inspection.Application.Contracts.Dto.ContractingDTOs.Setup.SubcontractBOQDTOs;
using Inspection.Application.Contracts.Repositories.Query.Contracting.Setup.ISubcontractBOQs;
using Inspection.Domain.Models.Contracting.Setup.SubcontractBOQs;
using Inspection.Infrastructure.QueryObjects.Contracting.Setup.SubcontractBOQs;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.Repositories.Query.Contracting.Setup.SubcontractBOQs
{
    public class SubcontractBOQQueryRepository : QueryRepositoryBase<SubcontractBOQ>, ISubcontractBOQQueryRepository
    {
        public SubcontractBOQQueryRepository(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(queryBuilder, dapper, context, tenantResolver, exceptionManager)
        {
        }

        public async Task<ReturnBase<List<SubcontractBOQ>>> GetAll()
        {
            var result = await _context.Set<SubcontractBOQ>()
                .Include(x => x.SubcontractBOQLines)
                .AsNoTracking().ToListAsync();
            return ReturnBase<List<SubcontractBOQ>>.Success(result);
        }

        public async Task<SubcontractBOQ?> GetById(long id)
        {
            return await _context.Set<SubcontractBOQ>()
                .Include(x => x.SubcontractBOQLines)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ReturnBase<IEnumerable<SubcontractBOQReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions)
        {
            var subcontractBOQRepository = new SubcontractBOQQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);
            return await subcontractBOQRepository.Query(sqlQueryOptions);
        }
    }
}