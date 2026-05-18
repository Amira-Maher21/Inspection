using Inspection.Application.Contracts.Repositories.Command.Accounting.Payments.CashReceipts;
using Inspection.Domain.Models.Accounting.Payment.CashReceipts;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Application.RepositoryBase.RepositoryHelpers;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.Repositories.Command.Accounting.Payments.CashReceipts
{
    public class CashReceiptCommandRepository : CommandRepositoryBase<CashReceipt>, ICashReceiptCommandRepository
    {
        public CashReceiptCommandRepository(DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(context, tenantResolver, exceptionManager)
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
                    ErrorMessage = $"Cash Receipt with Id '{id}' was not found."
                };
                var listOfErrors = new List<ReturnBaseError>() { error };
                return ReturnBase.Fail(listOfErrors);
            }
            _dbSet.Remove(entity);
            return ReturnBase.Success();
        }

        //public async Task<ReturnBase> DeleteCashReceiptLinesByCashReceiptId(long cashReceiptId)
        //{
        //    var cashReceiptLines = await _context.Set<CashReceiptLine>()
        //        .Where(v => v.CashReceiptId == cashReceiptId)
        //        .ToListAsync();

        //    if (!cashReceiptLines.Any())
        //        return ReturnBase.Success();

        //    _context.Set<CashReceiptLine>().RemoveRange(cashReceiptLines);

        //    return ReturnBase.Success();
        //}
        public async Task<ReturnBase> DeleteCashReceiptLineByCashReceiptIds(List<long> cashReceiptIds)
        {
            var cashReceiptLines = await _context.Set<CashReceiptLine>()
                .Where(x => cashReceiptIds.Contains(x.Id))
                .ToListAsync();

            _context.Set<CashReceiptLine>().RemoveRange(cashReceiptLines);

            return ReturnBase.Success();
        }

        //public async Task<ReturnBase> DeleteSalesInvoiceAllocationsByCashReceiptId(long cashReceiptId)
        //{
        //    var invoiceAllocations = await _context.Set<SalesInvoiceAllocation>()
        //        .Where(v => v.CashReceiptId == cashReceiptId)
        //        .ToListAsync();

        //    if (!invoiceAllocations.Any())
        //        return ReturnBase.Success();

        //    _context.Set<SalesInvoiceAllocation>().RemoveRange(invoiceAllocations);

        //    return ReturnBase.Success();
        //}
        public async Task<ReturnBase> DeleteSalesInvoiceAllocationsByCashReceiptIds(List<long> cashReceiptIds)
        {
            var invoiceAllocations = await _context.Set<SalesInvoiceAllocation>()
                .Where(x => cashReceiptIds.Contains(x.Id))
                .ToListAsync();

            _context.Set<SalesInvoiceAllocation>().RemoveRange(invoiceAllocations);

            return ReturnBase.Success();
        }

        //public async Task<ReturnBase> DeleteCashReceiptAdjustmentsByCashReceiptId(long cashReceiptId)
        //{
        //    var cashReceiptAdjustments = await _context.Set<CashReceiptAdjustment>()
        //        .Where(v => v.CashReceiptId == cashReceiptId)
        //        .ToListAsync();

        //    if (!cashReceiptAdjustments.Any())
        //        return ReturnBase.Success();

        //    _context.Set<CashReceiptAdjustment>().RemoveRange(cashReceiptAdjustments);

        //    return ReturnBase.Success();
        //}
        public async Task<ReturnBase> DeleteCashReceiptAdjustmentsCashReceiptIds(List<long> cashReceiptIds)
        {
            var cashReceiptAdjustments = await _context.Set<CashReceiptAdjustment>()
                .Where(x => cashReceiptIds.Contains(x.Id))
                .ToListAsync();

            _context.Set<CashReceiptAdjustment>().RemoveRange(cashReceiptAdjustments);

            return ReturnBase.Success();
        }
    }
}