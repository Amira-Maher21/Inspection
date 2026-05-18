using Inspection.Application.Contracts.Dto.EquipmentManagement.Series;
using Inspection.Application.Contracts.Dto.MenuManagement.Series;
using Inspection.Domain.Models.MenuManagement;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Services.MenuManagement.SeriesF
{
    public interface ISeriesService : IAccountServiceBase
    {
        Task<ReturnBase<SeriesDto>> GetAsync(long id);

        Task<ReturnBase<Dictionary<string, string>>> GetSeriesAndNumber(string TableName, string SeriesTableColumn, string Screen_ID);

        Task<ReturnBase<Dictionary<string, string>>> GetSeriesCodeWithCustomDate(string screenId, DateTime customDate, string tableName, string seriesTableColumn);

        Task<ReturnBase<Dictionary<string, string>>> GetSeriesCodeWithCustomDateUsingSeriesDetails(long seriesId, DateTime? requestDate);

        Task<ReturnBase<List<SeriesDto>>> GetListAsync();
        Task<ReturnBase<SeriesDto>> CreateAsync(CreateSeriesDto input);

        Task<ReturnBase<SeriesDto>> UpdateAsync(long id, UpdateSeriesDto input);
        Task<ReturnBase<bool>> DeleteAsync(long id);
        Task<ReturnBase<List<ScreenCodeDto>>> GetScreenListListAsync();
        Task<ReturnBase<Dictionary<string, string>>> GetSerialNumberAsync(string menuid);
        Task<Series?> GetSeriesByScreenCodeAsync(string screenCode);
        Task<ReturnBase<SeriesPatternDto>> GetSeriesPatternByScreenCodeAsync(string screenCode);



        Task<string> GetMaxCodeAsync(
            string tableName,
            string fieldName,
            string groupFieldName = null,
            string groupFieldValue = null,
            int paddingLength = 5
        );
    }
}
