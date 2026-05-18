using Inspection.Application.Contracts.Repositories.Command.Contracting.Setup.ISubcontractBOQs;
using Inspection.Domain.Models.Contracting.Setup.SubcontractBOQs;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Application.RepositoryBase.RepositoryHelpers;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.Repositories.Command.Contracting.Setup.SubcontractBOQs
{
    public class SubcontractBOQCommandRepository : CommandRepositoryBase<SubcontractBOQ>, ISubcontractBOQCommandRepository
    {
        public SubcontractBOQCommandRepository(DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(context, tenantResolver, exceptionManager)
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
                    ErrorMessage = $"Subcontract BOQ with Id '{id}' was not found."
                };
                var listOfErrors = new List<ReturnBaseError>() { error };
                return ReturnBase.Fail(listOfErrors);
            }
            _dbSet.Remove(entity);
            return ReturnBase.Success();
        }

        public async Task<ReturnBase> DeleteSubcontractBOQLinesBySubcontractBOQIds(List<long> ids)
        {
            var subcontractBOQLines = await _context.Set<SubcontractBOQLine>()
                .Where(x => ids.Contains(x.Id))
                .ToListAsync();

            _context.Set<SubcontractBOQLine>().RemoveRange(subcontractBOQLines);

            return ReturnBase.Success();
        }
    }
}