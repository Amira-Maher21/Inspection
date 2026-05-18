using Inspection.Domain.Models.SystemConfigurations.CurrencyExchangRates;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Command.SystemConfigurations.CurrencyExchangeRates
{
    public interface ICurrencyExchangeRateCommandRepository : ICommandRepository<CurrencyExchangRate>
    {
        // ===================== HARD DELETE =====================
        Task<ReturnBase> HardDeleteCurrencyExchangeRate(long id);

        // ===================== RELATIONS DELETE =====================
        Task<ReturnBase> DeleteCurrencyExchangeRateByItemId(long itemId);
        Task<ReturnBase> DeleteCurrencyExchangeRateByIds(List<long> ids);
    }
}
