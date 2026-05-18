using Inspection.Application.Contracts.Repositories.Command.Accounting.AR.PurchaseReturns;
using Inspection.Domain.Models.Accounting.AR.PurchaseReturns;
using Inspection.Domain.Models.Accounting.AR.PurchaseReturns.PurchaseReturnAdjustments;
using Inspection.Domain.Models.Accounting.AR.PurchaseReturns.PurchaseReturnLines;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Application.RepositoryBase.RepositoryHelpers;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.Repositories.Command.Accounting.AR.PurchaseReturns
{

    public class PurchaseReturnCommandRepository : CommandRepositoryBase<PurchaseReturn>, IPurchaseReturnCommandRepository
    {
        public PurchaseReturnCommandRepository(DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(context, tenantResolver, exceptionManager)
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
                    ErrorMessage = $"Purchase Return with Id '{id}' was not found."
                };
                var listOfErrors = new List<ReturnBaseError>() { error };
                return ReturnBase.Fail(listOfErrors);
            }
            _dbSet.Remove(entity);
            return ReturnBase.Success();
        }


        public async Task<ReturnBase> DeletePurchaseReturnLinesByPurchaseReturnIds(List<long> PurchaseReturnIds)
        {
            var purchaseReturnLines = await _context.Set<PurchaseReturnLine>()
                .Where(x => PurchaseReturnIds.Contains(x.Id))
                .ToListAsync();

            _context.Set<PurchaseReturnLine>().RemoveRange(purchaseReturnLines);

            return ReturnBase.Success();
        }

        public async Task<ReturnBase> DeletePurchaseReturnAdjustmentsByPurchaseReturnIds(List<long> PurchaseReturnIds)
        {
            var purchaseReturnAdjustment = await _context.Set<PurchaseReturnAdjustment>()
                .Where(x => PurchaseReturnIds.Contains(x.Id))
                .ToListAsync();

            _context.Set<PurchaseReturnAdjustment>().RemoveRange(purchaseReturnAdjustment);

            return ReturnBase.Success();
        }
    }

}
