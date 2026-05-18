using Inspection.Domain.Models.Sample.CurrencyExchangeRate;
using NDS.Shared.Application.RepositoryBase;

namespace Inspection.Application.Contracts.Repositories.Command.Sample.CurrencyExchangeRate
{
    public interface ISCurrencyExchangeRateCommandRepository
        : ICommandRepository<SCurrencyExchangeRateHeader>
    {
        Task Deactivate(long id);
        Task UpdateLine(SCurrencyExchangeRateLine line);
    }
}