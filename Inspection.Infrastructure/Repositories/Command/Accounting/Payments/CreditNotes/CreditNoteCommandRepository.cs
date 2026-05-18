using Inspection.Application.Contracts.Repositories.Command.Accounting.Payments.CreditNotes;
using Inspection.Domain.Models.Accounting.Payment.CreditNotes;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Application.RepositoryBase.RepositoryHelpers;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.Repositories.Command.Accounting.Payments.CreditNotes
{
    public class CreditNoteCommandRepository : CommandRepositoryBase<CreditNote>, ICreditNoteCommandRepository
    {
        public CreditNoteCommandRepository(DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(context, tenantResolver, exceptionManager)
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
                    ErrorMessage = $"Credit Note with Id '{id}' was not found."
                };
                var listOfErrors = new List<ReturnBaseError>() { error };
                return ReturnBase.Fail(listOfErrors);
            }
            _dbSet.Remove(entity);
            return ReturnBase.Success();
        }

        public async Task<ReturnBase> DeleteCreditNoteLinesByCreditNoteIds(List<long> ids)
        {
            var creditNoteLines = await _context.Set<CreditNoteLine>()
                .Where(x => ids.Contains(x.Id))
                .ToListAsync();

            _context.Set<CreditNoteLine>().RemoveRange(creditNoteLines);

            return ReturnBase.Success();
        }

        public async Task<ReturnBase> DeleteCreditNoteAdjustmentsByCreditNoteIds(List<long> ids)
        {
            var creditNoteAdjustments = await _context.Set<CreditNoteAdjustment>()
                .Where(x => ids.Contains(x.Id))
                .ToListAsync();

            _context.Set<CreditNoteAdjustment>().RemoveRange(creditNoteAdjustments);

            return ReturnBase.Success();
        }
    }
}