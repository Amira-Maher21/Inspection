using Inspection.Application.Contracts.Dto.ContractingDTOs.Setup.CommitmentDTOs;
using Inspection.Application.Contracts.Repositories.Query.Constracting.Setup.Commitments;
using Inspection.Domain.Models.Contracting.Setup.Commitment;
using Inspection.Infrastructure.QueryObjects.Constracting.Setup.Commitments;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.Repositories.Query.Accounting.Payments.CashTransfers
{
    public class CommitmentQueryRepository : QueryRepositoryBase<Commitment>, ICommitmentQueryRepository
    {
        public CommitmentQueryRepository(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(queryBuilder, dapper, context, tenantResolver, exceptionManager)
        {
        }

        public async Task<ReturnBase<List<Commitment>>> GetAll()
        {
            var result = await _context.Set<Commitment>()
                .Include(x => x.CommitmentLines)
                .AsNoTracking().ToListAsync();
            return ReturnBase<List<Commitment>>.Success(result);
        }

        public async Task<Commitment?> GetById(long id)
        {
            return await _context.Set<Commitment>()
                .Include(x => x.CommitmentLines)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ReturnBase<IEnumerable<CommitmentReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions)
        {
            var cashTransferRepository = new CommitmentQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);
            return await cashTransferRepository.Query(sqlQueryOptions);
        }
    }
}