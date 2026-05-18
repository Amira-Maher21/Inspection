using Inspection.Application.Contracts.Repositories.Command.Accounting.Payments;
using Inspection.Domain.Models.Accounting.Payment.JournalEntryTemplates;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Application.RepositoryBase.RepositoryHelpers;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.Repositories.Command.Accounting.Payments.JournalEntryTemplates
{
    public class JournalEntryTemplateCommandRepository : CommandRepositoryBase<JournalEntryTemplate>, IJournalEntryTemplateCommandRepository
    {
        public JournalEntryTemplateCommandRepository(DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(context, tenantResolver, exceptionManager)
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
                    ErrorMessage = "JournalEntryTemplate Not Found"
                };
                var listOfErrors = new List<ReturnBaseError>() { error };
                return ReturnBase.Fail(listOfErrors);
            }
            _dbSet.Remove(entity);
            return ReturnBase.Success();
        }



        public async Task<ReturnBase> DeleteDetailsByJournalEntryTemplateId(long JournalEntryTemplateId)
        {
            var variants = await _context.Set<JournalEntryTemplateLine>()
                .Where(v => v.JournalEntryTemplateId == JournalEntryTemplateId)
                .ToListAsync();

            if (!variants.Any())
                return ReturnBase.Success();

            _context.Set<JournalEntryTemplateLine>().RemoveRange(variants);

            return ReturnBase.Success();
        }
        public async Task<ReturnBase> DeleteDetailsByIds(List<long> ids)
        {
            var variants = await _context.Set<JournalEntryTemplateLine>()
                .Where(x => ids.Contains(x.Id))
                .ToListAsync();

            _context.Set<JournalEntryTemplateLine>().RemoveRange(variants);
            return ReturnBase.Success();
        }


    }

}