using Inspection.Application.Contracts.Repositories.Command.Contracting.Setup.IBOQs;
using Inspection.Domain.Models.Contracting.Setup.BOQs;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Application.RepositoryBase.RepositoryHelpers;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.Repositories.Command.Contracting.Setup.BOQs
{
    public class BOQCommandRepository : CommandRepositoryBase<BOQ>, IBOQCommandRepository
    {
        public BOQCommandRepository(DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(context, tenantResolver, exceptionManager)
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
                    ErrorMessage = $"BOQ with Id '{id}' was not found."
                };
                var listOfErrors = new List<ReturnBaseError>() { error };
                return ReturnBase.Fail(listOfErrors);
            }
            _dbSet.Remove(entity);
            return ReturnBase.Success();
        }

        public async Task<ReturnBase> DeleteBOQLinesByBOQIds(List<long> ids)
        {
            var bOQLines = await _context.Set<BOQLine>()
                .Where(x => ids.Contains(x.Id))
                .ToListAsync();

            _context.Set<BOQLine>().RemoveRange(bOQLines);

            return ReturnBase.Success();
        }
    }
}