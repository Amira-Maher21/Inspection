using Inspection.Application.Contracts.Repositories.Command.SalesManagment.Transactions.SalesReturns;
using Inspection.Domain.Models.SalesManagment.Transaction.SalesReturns;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Application.RepositoryBase.RepositoryHelpers;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.Repositories.Command.SalesManagment.Transactions.SalesReturns
{
    internal class SalesReturnCommandRepository
        : CommandRepositoryBase<SalesReturn>, ISalesReturnCommandRepository
    {
        public SalesReturnCommandRepository(
            DbContext context,
            ITenantResolver tenantResolver,
            IExceptionManager exceptionManager)
            : base(context, tenantResolver, exceptionManager)
        {
            _entityStructure = new EntityStructure
            {
                Key = ["Id"]
            };
        }

        // ================== DELETE MASTER ==================
        public async Task<ReturnBase> DeleteById(long id)
        {
            var entity = await _dbSet
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();

            if (entity is null)
            {
                return ReturnBase.Fail(new List<ReturnBaseError>
                {
                    new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = $"Sales Return with Id '{id}' was not found."
                    }
                });
            }

            _dbSet.Remove(entity);
            return ReturnBase.Success();
        }

        // ================== DELETE LINES ==================
        public async Task<ReturnBase> DeleteSalesReturnLinesBySalesReturnIds(List<long> salesReturnIds)
        {
            var lines = await _context.Set<SalesReturnLine>()
                .Where(x => salesReturnIds.Contains(x.SalesReturnId))
                .ToListAsync();

            if (!lines.Any())
                return ReturnBase.Success();

            _context.Set<SalesReturnLine>().RemoveRange(lines);

            return ReturnBase.Success();
        }

        // ================== DELETE ADJUSTMENTS ==================
        public async Task<ReturnBase> DeleteSalesReturnAdjustmentsBySalesReturnIds(List<long> salesReturnIds)
        {
            var adjustments = await _context.Set<SalesReturnAdjustment>()
                .Where(x => salesReturnIds.Contains(x.SalesReturnId))
                .ToListAsync();

            if (!adjustments.Any())
                return ReturnBase.Success();

            _context.Set<SalesReturnAdjustment>().RemoveRange(adjustments);

            return ReturnBase.Success();
        }
    }
}