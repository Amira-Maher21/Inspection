using Inspection.Application.Contracts.Repositories.Command.Inventory.Transaction.ScrapReasons;
using Inspection.Domain.Models.Inventory.Transaction.ScrapReasons;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Application.RepositoryBase.RepositoryHelpers;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.Repositories.Command.Inventory.Transaction.ScrapReasons
{
    public class ScrapReasonCommandRepository
        : CommandRepositoryBase<ScrapReason>, IScrapReasonCommandRepository
    {
        public ScrapReasonCommandRepository(
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
            var entity = await _dbSet
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();

            if (entity is null)
            {
                return ReturnBase.Fail(new List<ReturnBaseError>
                {
                    new ReturnBaseError
                    {
                        ErrorCode = "404",
                        ErrorMessage = "ScrapReason Not Found"
                    }
                });
            }

            _dbSet.Remove(entity);

            return ReturnBase.Success();
        }
    }
}