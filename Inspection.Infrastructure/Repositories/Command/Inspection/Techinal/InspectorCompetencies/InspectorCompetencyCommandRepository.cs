using Inspection.Application.Contracts.Repositories.Command.Inspection.Techinal.InspectorCompetencies;
using Inspection.Domain.Models.Inspection.Techinal.InspectorCompetencies;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Application.RepositoryBase.RepositoryHelpers;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.Repositories.Command.Inspection.Techinal.InspectorCompetencies
{
    public class InspectorCompetencyCommandRepository : CommandRepositoryBase<InspectorCompetency>, IInspectorCompetencyCommandRepository
    {
        public InspectorCompetencyCommandRepository(DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(context, tenantResolver, exceptionManager)
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
                    ErrorMessage = "Inspector Competency Not Found"
                };
                var listOfErrors = new List<ReturnBaseError>() { error };
                return ReturnBase.Fail(listOfErrors);
            }
            _dbSet.Remove(entity);
            return ReturnBase.Success();
        }
        public async Task<ReturnBase> DeleteLinesByInspectorCompetencyId(long id)
        {
            var lines = await _context.Set<InspectorCompetencyLine>()
                .Where(v => v.InspectorCompetencyId == id)
                .ToListAsync();

            if (!lines.Any())
                return ReturnBase.Success();

            _context.Set<InspectorCompetencyLine>().RemoveRange(lines);

            return ReturnBase.Success();
        }

        public async Task<ReturnBase> DeleteAccreditationsByInspectorCompetencyId(long id)
        {
            var lines = await _context.Set<InspectorAccreditation>()
                .Where(v => v.InspectorCompetencyId == id)
                .ToListAsync();

            if (!lines.Any())
                return ReturnBase.Success();

            _context.Set<InspectorAccreditation>().RemoveRange(lines);

            return ReturnBase.Success();
        }

        public async Task<ReturnBase> DeleteLinesByIds(List<long> ids)
        {
            var lines = await _context.Set<InspectorCompetencyLine>()
                .Where(x => ids.Contains(x.Id))
                .ToListAsync();

            _context.Set<InspectorCompetencyLine>().RemoveRange(lines);

            return ReturnBase.Success();
        }
        public async Task<ReturnBase> DeleteAccreditationsByIds(List<long> ids)
        {
            var lines = await _context.Set<InspectorAccreditation>()
                .Where(x => ids.Contains(x.Id))
                .ToListAsync();

            _context.Set<InspectorAccreditation>().RemoveRange(lines);

            return ReturnBase.Success();
        }

    }
}