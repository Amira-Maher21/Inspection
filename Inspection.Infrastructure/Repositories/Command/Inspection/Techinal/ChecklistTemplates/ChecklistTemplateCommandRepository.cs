using Inspection.Application.Contracts.Repositories.Command.Inspection.Techinal.ChecklistTemplates;
using Inspection.Domain.Models.Inspection.Techinal.ChecklistTemplates;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Application.RepositoryBase.RepositoryHelpers;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.Repositories.Command.Inspection.Techinal.ChecklistTemplates
{
    public class ChecklistTemplateCommandRepository : CommandRepositoryBase<ChecklistTemplate>, IChecklistTemplateCommandRepository
    {
        public ChecklistTemplateCommandRepository(DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(context, tenantResolver, exceptionManager)
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
                    ErrorMessage = "ChecklistTemplate Not Found"
                };
                var listOfErrors = new List<ReturnBaseError>() { error };
                return ReturnBase.Fail(listOfErrors);
            }
            _dbSet.Remove(entity);
            return ReturnBase.Success();
        }



        public async Task<ReturnBase> DeleteDetailsByChecklistTemplateId(long ChecklistTemplateId)
        {
            var variants = await _context.Set<ChecklistTemplateLine>()
                .Where(v => v.ChecklistTemplateId == ChecklistTemplateId)
                .ToListAsync();

            if (!variants.Any())
                return ReturnBase.Success();

            _context.Set<ChecklistTemplateLine>().RemoveRange(variants);

            return ReturnBase.Success();
        }
        public async Task<ReturnBase> DeleteDetailsByIds(List<long> ids)
        {
            var variants = await _context.Set<ChecklistTemplateLine>()
                .Where(x => ids.Contains(x.Id))
                .ToListAsync();

            _context.Set<ChecklistTemplateLine>().RemoveRange(variants);
            return ReturnBase.Success();
        }


    }

}
