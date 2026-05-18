using Inspection.Application.Contracts.Repositories.Command.Inventory.Transaction.GoodsIssues;
using Inspection.Domain.Models.Inventory.Transaction.GoodsIssues;
using Inspection.Domain.Models.Inventory.Transaction.GoodsIssues.GoodsIssueLines;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Application.RepositoryBase.RepositoryHelpers;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.Repositories.Command.Inventory.Transaction.GoodsIssues
{
    public class GoodsIssueCommandRepository : CommandRepositoryBase<GoodsIssue>, IGoodsIssueCommandRepository
    {
        public GoodsIssueCommandRepository(DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager)
            : base(context, tenantResolver, exceptionManager)
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
                    ErrorMessage = "GoodsIssue Not Found"
                };
                return ReturnBase.Fail(new List<ReturnBaseError> { error });
            }

            _dbSet.Remove(entity);
            return ReturnBase.Success();
        }

        public async Task<ReturnBase> DeleteGoodsIssueLineByGoodsIssueId(long goodsIssueId)
        {
            var lines = await _context.Set<GoodsIssueLine>()
                .Where(x => x.GoodsIssueId == goodsIssueId)
                .ToListAsync();

            if (!lines.Any())
                return ReturnBase.Success();

            _context.Set<GoodsIssueLine>().RemoveRange(lines);

            return ReturnBase.Success();
        }

        public async Task<ReturnBase> DeleteGoodsIssueLineByIds(List<long> ids)
        {
            var lines = await _context.Set<GoodsIssueLine>()
                .Where(x => ids.Contains(x.Id))
                .ToListAsync();

            _context.Set<GoodsIssueLine>().RemoveRange(lines);

            return ReturnBase.Success();
        }
    }
}