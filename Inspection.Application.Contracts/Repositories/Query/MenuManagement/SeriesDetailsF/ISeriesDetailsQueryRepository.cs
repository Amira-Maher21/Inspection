using Inspection.Domain.Models.MenuManagement;
using NDS.Shared.Application.RepositoryBase;

namespace Inspection.Application.Contracts.Repositories.Query.MenuManagement.SeriesDetailsF
{
    public interface ISeriesDetailsQueryRepository : IQueryRepository<SeriesDetails>
    {
        Task<SeriesDetails?> GetBySeriesIdAndPeriodAsync(long seriesId, int year, int month);
    }
}