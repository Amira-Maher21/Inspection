using Inspection.Application.Contracts.Repositories.Command.Accounting.ChartOfAccounts;
using Inspection.Domain.Models.Accounting.ChartOfAccounts;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Application.RepositoryBase.RepositoryHelpers;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.Repositories.Command.Accounting.ChartOfAccounts
{
    public class ChartOfAccountCommandRepository : CommandRepositoryBase<ChartOfAccount>, IChartOfAccountCommandRepository
    {
        public ChartOfAccountCommandRepository(DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(context, tenantResolver, exceptionManager)
        {
            _entityStructure = new EntityStructure
            {
                Key = ["Id"]
            };
        }
        public async Task<ReturnBase> DeleteById(long id)
        {
            var entity = await _dbSet.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (entity is null)
            {
                var error = new ReturnBaseError
                {
                    ErrorCode = "404",
                    ErrorMessage = "Chart Of Account Not Found"
                };
                var listOfErrors = new List<ReturnBaseError>() { error };
                return ReturnBase.Fail(listOfErrors);
            }
            _dbSet.Remove(entity);
            return ReturnBase.Success();
        }
        public async Task<bool> HasChildren(long parentId)
        {
            return await _context.Set<ChartOfAccount>()
                .AnyAsync(x => x.ParentAccountId == parentId);
        }

        public async Task<ChartOfAccount?> GetFirstChild(long parentId)
        {
            return await _context.Set<ChartOfAccount>()
                .Where(x => x.ParentAccountId == parentId)
                .Select(x => new ChartOfAccount
                {
                    Id = x.Id,
                    AccountCode = x.AccountCode,
                    AccountName = x.AccountName
                })
                .FirstOrDefaultAsync();
        }
        public async Task<List<long>> GetChildAccountIds(long parentId)
        {
            return await _context.Set<ChartOfAccount>()
                .Where(x => x.ParentAccountId == parentId)
                .Select(x => x.Id)
                .ToListAsync();
        }
    }
}