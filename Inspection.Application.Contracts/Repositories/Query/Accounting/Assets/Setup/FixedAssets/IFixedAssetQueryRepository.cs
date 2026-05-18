using Inspection.Application.Contracts.Dto.AccountingDtos.Assets.Setup.FixedAssetDTOs;
using Inspection.Domain.Models.Accounting.Assets.Setup.FixedAssets;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Query.Accounting.Assets.Setup.FixedAssets
{
    public interface IFixedAssetQueryRepository : IQueryRepository<FixedAsset>
    {
        Task<ReturnBase<List<FixedAsset>>> GetAll();
        Task<FixedAsset?> GetById(long id);
        Task<FixedAsset?> GetByCode(string code);
        Task<ReturnBase<IEnumerable<FixedAssetReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions);
    }
}