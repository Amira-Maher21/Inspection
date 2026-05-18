using Inspection.Application.Contracts.Repositories.Command.Contracting.WBSs;
using Inspection.Domain.Models.Contracting.Setup.WBSs;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Application.RepositoryBase.RepositoryHelpers;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.Repositories.Command.Contracting.WBSs
{
    public class WBSCommandRepository : CommandRepositoryBase<WBS>, IWBSCommandRepository
    {
        public WBSCommandRepository(
            DbContext context,
            ITenantResolver tenantResolver,
            IExceptionManager exceptionManager)
            : base(context, tenantResolver, exceptionManager)
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
                    ErrorMessage = $"WBS with Id {id} was not found"
                };

                var listOfErrors = new List<ReturnBaseError>() { error };

                return ReturnBase.Fail(listOfErrors);
            }

            _dbSet.Remove(entity);

            return ReturnBase.Success();
        }

        public async Task<bool> HasChildren(long parentId)
        {
            return await _context.Set<WBS>()
                .AnyAsync(x => x.ParentWBSId == parentId);
        }
    }
}