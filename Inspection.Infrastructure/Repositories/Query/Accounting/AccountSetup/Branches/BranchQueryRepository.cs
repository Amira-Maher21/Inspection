using Inspection.Application.Contracts.Dto.AccountingDtos.AccountingSetupDtos.Branches;
using Inspection.Application.Contracts.Repositories.Query.Accounting.AccountSetup.Branches;
using Inspection.Domain.Models.Accounting.AccountingSetup.Branches;
using Inspection.Infrastructure.QueryObjects.Accounting.AccountSetup.Branches;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.Repositories.Query.Accounting.AccountSetup.Branches
{
    public class BranchQueryRepository : QueryRepositoryBase<Branch>, IBranchQueryRepository
    {
        public BranchQueryRepository(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(queryBuilder, dapper, context, tenantResolver, exceptionManager)
        {
        }

        public async Task<ReturnBase<List<Branch>>> GetAll()
        {
            var result = await _context.Set<Branch>().AsNoTracking().ToListAsync();
            return ReturnBase<List<Branch>>.Success(result);
        }

        public async Task<Branch?> GetById(long id)
        {
            return await _context.Set<Branch>().Where(x => x.Id == id).FirstOrDefaultAsync();
        }



        public async Task<ReturnBase<IEnumerable<BranchReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions)
        {
            var BranchRepository = new BranchQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);
            return await BranchRepository.Query(sqlQueryOptions);
        }

        public async Task<Branch?> GetByCode(string code)
        {
            return await _context.Set<Branch>().Where(x => x.Code == code).FirstOrDefaultAsync();
        }

    }
}
