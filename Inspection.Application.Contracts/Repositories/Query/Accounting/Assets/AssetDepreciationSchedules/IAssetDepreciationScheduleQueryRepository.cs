using Inspection.Application.Contracts.Dto.AccountingDtos.Assets.AssetDepreciationSchedules;
using Inspection.Domain.Models.Accounting.Assets;
using Inspection.Domain.Models.Accounting.Assets.FixedAssets;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Query.Accounting.Assets.AssetDepreciationSchedules
{
    public interface IAssetDepreciationScheduleQueryRepository : IQueryRepository<AssetDepreciationSchedule>
    {
        Task<ReturnBase<List<AssetDepreciationSchedule>>> GetAll();
        Task<AssetDepreciationSchedule?> GetById(long id);

        Task<ReturnBase<IEnumerable<AssetDepreciationScheduleReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions);

    }
}
