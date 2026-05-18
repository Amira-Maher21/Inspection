using Inspection.Application.Contracts.Dto.AccountingDtos.Assets.Setup.AssetCategories;
using Inspection.Domain.Models.Accounting.Assets.Setup.AssetCategories;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Query.Accounting.Assets.Setup.AssetCategories
{
    public interface IAssetCategoryQueryRepository : IQueryRepository<AssetCategory>
    {
        Task<AssetCategory?> GetById(long id);
        Task<ReturnBase<List<AssetCategory>>> GetAll();
        Task<ReturnBase<IEnumerable<AssetCategoryReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions);
        Task<AssetCategory?> GetByCode(string code);
    }
}