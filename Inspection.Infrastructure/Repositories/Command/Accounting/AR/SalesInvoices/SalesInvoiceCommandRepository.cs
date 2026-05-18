using Inspection.Application.Contracts.Repositories.Command.Accounting.AR.SalesInvoices;
using Inspection.Domain.Models.Accounting.AR.SalesInvoices;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Application.RepositoryBase.RepositoryHelpers;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.Repositories.Command.Accounting.AR.SalesInvoices
{

    public class SalesInvoiceCommandRepository : CommandRepositoryBase<SalesInvoice>, ISalesInvoiceCommandRepository
    {
        public SalesInvoiceCommandRepository(DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(context, tenantResolver, exceptionManager)
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
                    ErrorMessage = "Country Not Found"
                };
                var listOfErrors = new List<ReturnBaseError>() { error };
                return ReturnBase.Fail(listOfErrors);
            }
            _dbSet.Remove(entity);
            return ReturnBase.Success();
        }


        public async Task<ReturnBase> DeleteSalesInvoiceLinesBySalesInvoiceId(long SalesInvoiceId)

        {
            var items = await _context.Set<SalesInvoiceLine>()
                .Where(x => x.Id == SalesInvoiceId)
                .ToListAsync();

            if (items.Any())
                _context.Set<SalesInvoiceLine>().RemoveRange(items);

            return ReturnBase.Success();
        }

        public async Task<ReturnBase> DeleteSalesInvoiceLinesByIds(List<long> ids)
        {
            var items = await _context.Set<SalesInvoiceLine>()
                .Where(x => ids.Contains(x.Id))
                .ToListAsync();

            if (items.Any())
                _context.Set<SalesInvoiceLine>().RemoveRange(items);

            return ReturnBase.Success();
        }


        public async Task<ReturnBase> DeleteSalesInvoiceSalesAdjustmentsByAdjustmentId(long SalesInvoiceId)

        {
            var items = await _context.Set<SalesInvoiceSalesAdjustment>()
                .Where(x => x.Id == SalesInvoiceId)
                .ToListAsync();

            if (items.Any())
                _context.Set<SalesInvoiceSalesAdjustment>().RemoveRange(items);

            return ReturnBase.Success();
        }

        public async Task<ReturnBase> DeleteSalesInvoiceSalesAdjustmentsByIds(List<long> ids)
        {
            var items = await _context.Set<SalesInvoiceSalesAdjustment>()
                .Where(x => ids.Contains(x.Id))
                .ToListAsync();

            if (items.Any())
                _context.Set<SalesInvoiceSalesAdjustment>().RemoveRange(items);

            return ReturnBase.Success();
        }



        public async Task<ReturnBase> DeleteSalesInvoiceSalesPersonsBySalesPersonId(long SalesInvoiceId)

        {
            var items = await _context.Set<SalesInvoiceSalesPerson>()
                .Where(x => x.Id == SalesInvoiceId)
                .ToListAsync();

            if (items.Any())
                _context.Set<SalesInvoiceSalesPerson>().RemoveRange(items);

            return ReturnBase.Success();
        }

        public async Task<ReturnBase> DeleteSalesInvoiceSalesPersonsByIds(List<long> ids)
        {
            var items = await _context.Set<SalesInvoiceSalesPerson>()
                .Where(x => ids.Contains(x.Id))
                .ToListAsync();

            if (items.Any())
                _context.Set<SalesInvoiceSalesPerson>().RemoveRange(items);

            return ReturnBase.Success();
        }



    }
}
