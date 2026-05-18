using Inspection.Application.Contracts.Repositories.Command.Accounting.AccountSetup.CostUnits;
using Inspection.Domain.Models.Accounting.AccountingSetup.CostUnits;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Application.RepositoryBase.RepositoryHelpers;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.Repositories.Command.Accounting.AccountSetup.CostUnits
{
    public class CostUnitCommandRepository : CommandRepositoryBase<CostUnit>, ICostUnitCommandRepository
    {
        public CostUnitCommandRepository(DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(context, tenantResolver, exceptionManager)
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
                    ErrorMessage = "Cost Unit Not Found"
                };
                var listOfErrors = new List<ReturnBaseError>() { error };
                return ReturnBase.Fail(listOfErrors);
            }
            _dbSet.Remove(entity);
            return ReturnBase.Success();
        }
        public async Task<bool> HasChildren(long parentCostUnitId)
        {
            return await _context.Set<CostUnit>()
                                 .AnyAsync(x => x.ParentCostUnitId == parentCostUnitId);
        }

        public async Task<CostUnit?> GetFirstChild(long parentCostUnitId)
        {
            return await _context.Set<CostUnit>()
                                 .Where(x => x.ParentCostUnitId == parentCostUnitId)
                                 .OrderBy(x => x.Id)
                                 .FirstOrDefaultAsync();
        }
        public async Task<List<long>> GetChildCostUnitIds(long parentCostUnitId)
        {
            return await _context.Set<CostUnit>()
                .Where(x => x.ParentCostUnitId == parentCostUnitId)
                .Select(x => x.Id)
                .ToListAsync();
        }
    }
}