using Inspection.Domain.Models.MenuManagement;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Query.MenuManagement.SeriesF
{
    public interface IScreenCodeQueryRepository
    {
        Task<ReturnBase<IEnumerable<Screen_Code>>> GetAllAsync();
        Task<Screen_Code?> GetByMenu_IDAsync(string menuid);

        Task<string> GetMaxCodeAsync(
           string tableName,
           string fieldName,
           string groupFieldName = null,
           string groupFieldValue = null,
            int paddingLength = 5
       );
    }

}
