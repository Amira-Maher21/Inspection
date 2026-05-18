using Inspection.Domain.Enums;
using Inspection.Domain.Models.MenuManagement;
using NDS.Shared.Application.RepositoryBase;

namespace Inspection.Application.Contracts.Repositories.Command.MenuManagement.SeriesDetailsF
{
    public interface ISeriesDetailsCommandRepository : ICommandRepository<SeriesDetails>
    {
        Task<SeriesDetails?> GetOrCreateSeriesDetailsAsync(long seriesId, int year, int month, string tenantId, ResetPolicyEnum resetPolicy);
    }
}