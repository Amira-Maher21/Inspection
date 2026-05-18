using Inspection.Application.Contracts.Repositories.Command.Sample.CurrencyExchangeRate;
using Inspection.Domain.Models.Sample.CurrencyExchangeRate;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Application.RepositoryBase.RepositoryHelpers;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.Repositories.Command.Sample.CurrencyExchangeRate
{
    internal class SCurrencyExchangeRateCommandRepository
        : CommandRepositoryBase<SCurrencyExchangeRateHeader>,
        ISCurrencyExchangeRateCommandRepository
    {
        public SCurrencyExchangeRateCommandRepository(DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(context, tenantResolver, exceptionManager)
        {
            _entityStructure = new EntityStructure
            {
                Key = ["Id"],
                RelatedEntities = new List<RelatedEntity>
                {
                    new RelatedEntity
                    {
                        Keys=["Id"],
                        NavigationProperty="Lines",
                        EntityType=typeof(SCurrencyExchangeRateLine),
                        RelatedEntities=null

                    }
                }
            };
        }

        public async Task Deactivate(long id)
        {
            await _dbSet.Where(c => c.Id == id)
                   .ExecuteUpdateAsync(s => s.SetProperty(c => c.IsActive, c => false)
                                            .SetProperty(c => c.Mod_Date, c => DateTime.UtcNow)
                                            .SetProperty(c => c.Mod_User, c => _tenantResolver.GetCommonUserData().UserName));
        }

        public async Task UpdateLine(SCurrencyExchangeRateLine line)
        {
            await _context.Set<SCurrencyExchangeRateLine>()
                 .Where(l => l.Id == line.Id)
                 .ExecuteUpdateAsync(s => s.SetProperty(l => l.TargetCurrencyId, l => line.TargetCurrencyId)
                                         .SetProperty(l => l.Rate, l => line.Rate)
                                            .SetProperty(l => l.Mod_Date, l => DateTime.UtcNow)
                                            .SetProperty(l => l.Mod_User, l => _tenantResolver.GetCommonUserData().UserName));
        }
    }
}
