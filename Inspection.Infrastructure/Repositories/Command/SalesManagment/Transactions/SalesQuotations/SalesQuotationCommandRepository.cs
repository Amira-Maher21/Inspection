using Inspection.Application.Contracts.Repositories.Command.SalesManagment.Transactions.SalesQuotations;
using Inspection.Domain.Models.SalesManagment.Transaction.SalesQuotations;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Application.RepositoryBase.RepositoryHelpers;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.Repositories.Command.SalesManagment.Transactions.SalesQuotations
{
    public class SalesQuotationCommandRepository : CommandRepositoryBase<SalesQuotation>, ISalesQuotationCommandRepository
    {
        public SalesQuotationCommandRepository(DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(context, tenantResolver, exceptionManager)
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
                    ErrorMessage = $"Sales Quotation with Id '{id}' was not found."
                };
                var listOfErrors = new List<ReturnBaseError>() { error };
                return ReturnBase.Fail(listOfErrors);
            }
            _dbSet.Remove(entity);
            return ReturnBase.Success();
        }

        public async Task<ReturnBase> DeleteSalesQuotationLinesByIds(List<long> ids)
        {
            var salesQuotationLines = await _context.Set<SalesQuotationLine>()
                .Where(x => ids.Contains(x.Id))
                .ToListAsync();

            _context.Set<SalesQuotationLine>().RemoveRange(salesQuotationLines);

            return ReturnBase.Success();
        }

    }
}