using Inspection.Application.Contracts.Repositories.Command.SystemConfigurations.CurrencyExchangeRates;
using Inspection.Domain.Models.SystemConfigurations.CurrencyExchangRates;
using Inspection.Domain.Models.SystemConfigurations.DetailTables;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Application.RepositoryBase.RepositoryHelpers;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.Repositories.Command.SystemConfigurations.CurrencyExchangeRates
{
    public class CurrencyExchangeRateCommandRepository : CommandRepositoryBase<CurrencyExchangRate>, ICurrencyExchangeRateCommandRepository
    {
        public CurrencyExchangeRateCommandRepository(DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager)
            : base(context, tenantResolver, exceptionManager)
        {
            _entityStructure = new EntityStructure
            {
                Key = ["Id"]
            };
        }

        // ===================== HARD DELETE =====================
        public async Task<ReturnBase> HardDeleteCurrencyExchangeRate(long id)
        {
            var entity = await _dbSet.FirstOrDefaultAsync(x => x.Id == id);

            if (entity is null)
            {
                return ReturnBase.Fail(new List<ReturnBaseError>
                {
                    new() { ErrorCode = "404", ErrorMessage = "Currency Exchange Rate Not Found" }
                });
            }

            // 1️⃣ Delete Relations
            await DeleteCurrencyExchangeRateByItemId(entity.Id);

            // 2️⃣ Delete Main Entity
            _dbSet.Remove(entity);

            return ReturnBase.Success();
        }

        // ===================== RELATIONS =====================
        public async Task<ReturnBase> DeleteCurrencyExchangeRateByItemId(long itemId)
        {
            var relatedItems = await _context.Set<DetailTable>()
                .Where(x => x.CurrencyExchangRateId == itemId)
                .ToListAsync();

            if (relatedItems.Any())
                _context.Set<DetailTable>().RemoveRange(relatedItems);

            return ReturnBase.Success();
        }

        public async Task<ReturnBase> DeleteCurrencyExchangeRateByIds(List<long> ids)
        {
            var relatedItems = await _context.Set<DetailTable>()
                .Where(x => ids.Contains(x.Id))
                .ToListAsync();

            if (relatedItems.Any())
                _context.Set<DetailTable>().RemoveRange(relatedItems);

            return ReturnBase.Success();
        }
    }
}
