using Inspection.Application.Contracts.Repositories.Command.Accounting.Payments.DebitNotes;
using Inspection.Domain.Models.Accounting.Payment.DebitNotes;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Application.RepositoryBase.RepositoryHelpers;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.Repositories.Command.Accounting.Payments.DebitNotes
{
    public class DebitNoteCommandRepository : CommandRepositoryBase<DebitNote>, IDebitNoteCommandRepository
    {
        public DebitNoteCommandRepository(DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(context, tenantResolver, exceptionManager)
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
                    ErrorMessage = $"Debit Note with Id '{id}' was not found."
                };
                var listOfErrors = new List<ReturnBaseError>() { error };
                return ReturnBase.Fail(listOfErrors);
            }
            _dbSet.Remove(entity);
            return ReturnBase.Success();
        }

        public async Task<ReturnBase> DeleteDebitNoteLinesByDebitNoteIds(List<long> ids)
        {
            var debitNoteLines = await _context.Set<DebitNoteLine>()
                .Where(x => ids.Contains(x.Id))
                .ToListAsync();

            _context.Set<DebitNoteLine>().RemoveRange(debitNoteLines);

            return ReturnBase.Success();
        }

        public async Task<ReturnBase> DeleteDebitNoteAdjustmentsByDebitNoteIds(List<long> ids)
        {
            var debitNoteAdjustments = await _context.Set<DebitNoteAdjustment>()
                .Where(x => ids.Contains(x.Id))
                .ToListAsync();

            _context.Set<DebitNoteAdjustment>().RemoveRange(debitNoteAdjustments);
            return ReturnBase.Success();
        }
    }
}