using Inspection.Application.Contracts.Repositories.Command.Accounting.Payments.CashTransfers;
using Inspection.Domain.Models.Accounting.Payment.CashTransfers;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Application.RepositoryBase.RepositoryHelpers;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.Repositories.Command.Accounting.Payments.CashTransfers
{
    public class CashTransferCommandRepository : CommandRepositoryBase<CashTransfer>, ICashTransferCommandRepository
    {
        public CashTransferCommandRepository(DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(context, tenantResolver, exceptionManager)
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
                    ErrorMessage = $"Cash Transfer with Id '{id}' was not found."
                };
                var listOfErrors = new List<ReturnBaseError>() { error };
                return ReturnBase.Fail(listOfErrors);
            }
            _dbSet.Remove(entity);
            return ReturnBase.Success();
        }

        public async Task<ReturnBase> DeleteCashTransferLinesByCashTransferIds(List<long> ids)
        {
            var cashTransferLines = await _context.Set<CashTransferLine>()
                .Where(x => ids.Contains(x.Id))
                .ToListAsync();

            _context.Set<CashTransferLine>().RemoveRange(cashTransferLines);

            return ReturnBase.Success();
        }
    }
}