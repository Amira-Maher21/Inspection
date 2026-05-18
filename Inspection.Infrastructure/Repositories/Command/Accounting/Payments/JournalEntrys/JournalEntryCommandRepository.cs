using Inspection.Application.Contracts.Repositories.Command.Accounting.Payments.JournalEntrys;
using Inspection.Domain.Models.Accounting.Payment.JonrnalEntrys;
using Inspection.Domain.Models.Accounting.Payment.JournalEntryLines;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Application.RepositoryBase.RepositoryHelpers;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.Repositories.Command.Accounting.Payments.JournalEntrys
{

    public class JournalEntryCommandRepository : CommandRepositoryBase<JournalEntry>, IJournalEntryCommandRepository
    {
        public JournalEntryCommandRepository(DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(context, tenantResolver, exceptionManager)
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
                    ErrorMessage = "Journal Entry Not Found"
                };
                var listOfErrors = new List<ReturnBaseError>() { error };
                return ReturnBase.Fail(listOfErrors);
            }
            _dbSet.Remove(entity);
            return ReturnBase.Success();
        }


        //Get By Id
        public async Task<ReturnBase<JournalEntry>> GetById(long id)
        {
            var entity = await _dbSet.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (entity is null)
            {
                var error = new ReturnBaseError
                {
                    ErrorCode = "404",
                    ErrorMessage = "Journal Entry Not Found"
                };
                var listOfErrors = new List<ReturnBaseError>() { error };
                return ReturnBase<JournalEntry>.Fail(listOfErrors);
            }
            return ReturnBase<JournalEntry>.Success(entity);
        }


        // ===================== Lines =====================
        public async Task<ReturnBase> DeleteJournalEntryLineByJournalEntryId(long journalEntryId)
        {
            var items = await _context.Set<JournalEntryLine>()
                .Where(x => x.JournalEntryId == journalEntryId)
                .ToListAsync();

            if (items.Any())
                _context.Set<JournalEntryLine>().RemoveRange(items);

            return ReturnBase.Success();
        }

        public async Task<ReturnBase> DeleteJournalEntryLineByIds(List<long> ids)
        {
            var items = await _context.Set<JournalEntryLine>()
                .Where(x => ids.Contains(x.Id))
                .ToListAsync();

            if (items.Any())
                _context.Set<JournalEntryLine>().RemoveRange(items);

            return ReturnBase.Success();
        }

    }
}
