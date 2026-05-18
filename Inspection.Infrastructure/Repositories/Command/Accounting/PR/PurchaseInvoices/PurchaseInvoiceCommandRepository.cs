using Inspection.Application.Contracts.Repositories.Command.Accounting.PR.PurchaseInvoices;
using Inspection.Domain.Models.Accounting.PR.PurchaseInvoices;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Application.RepositoryBase.RepositoryHelpers;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.Repositories.Command.Accounting.PR.PurchaseInvoices
{
    public class PurchaseInvoiceCommandRepository : CommandRepositoryBase<PurchaseInvoice>, IPurchaseInvoiceCommandRepository
    {
        public PurchaseInvoiceCommandRepository(DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager)
            : base(context, tenantResolver, exceptionManager)
        {
            _entityStructure = new EntityStructure
            {
                Key = new[] { "Id" }
            };
        }

        public async Task<ReturnBase> DeleteById(long id)
        {
            var entity = await _dbSet.FirstOrDefaultAsync(x => x.Id == id);
            if (entity is null)
            {
                var error = new ReturnBaseError
                {
                    ErrorCode = "404",
                    ErrorMessage = "Purchase Invoice Not Found"
                };
                return ReturnBase.Fail(new List<ReturnBaseError> { error });
            }

            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
            return ReturnBase.Success();
        }

        public async Task<ReturnBase> DeleteInvoiceLinesByPurchaseInvoiceId(long purchaseInvoiceId)
        {
            var items = await _context.Set<PurchaseInvoiceLine>()
                .Where(x => x.PurchaseInvoiceId == purchaseInvoiceId)
                .ToListAsync();

            if (items.Any())
            {
                _context.Set<PurchaseInvoiceLine>().RemoveRange(items);
                await _context.SaveChangesAsync();
            }

            return ReturnBase.Success();
        }

        public async Task<ReturnBase> DeleteInvoiceLinesByIds(List<long> ids)
        {
            var items = await _context.Set<PurchaseInvoiceLine>()
                .Where(x => ids.Contains(x.Id))
                .ToListAsync();

            if (items.Any())
            {
                _context.Set<PurchaseInvoiceLine>().RemoveRange(items);
                await _context.SaveChangesAsync();
            }

            return ReturnBase.Success();
        }

        public async Task<ReturnBase> DeleteAdjustmentsByPurchaseInvoiceId(long purchaseInvoiceId)
        {
            var items = await _context.Set<PurchaseInvoiceAdjustment>()
                .Where(x => x.PurchaseInvoiceId == purchaseInvoiceId)
                .ToListAsync();

            if (items.Any())
            {
                _context.Set<PurchaseInvoiceAdjustment>().RemoveRange(items);
                await _context.SaveChangesAsync();
            }

            return ReturnBase.Success();
        }

        public async Task<ReturnBase> DeleteAdjustmentsByIds(List<long> ids)
        {
            var items = await _context.Set<PurchaseInvoiceAdjustment>()
                .Where(x => ids.Contains(x.Id))
                .ToListAsync();

            if (items.Any())
            {
                _context.Set<PurchaseInvoiceAdjustment>().RemoveRange(items);
                await _context.SaveChangesAsync();
            }

            return ReturnBase.Success();
        }
    }
}