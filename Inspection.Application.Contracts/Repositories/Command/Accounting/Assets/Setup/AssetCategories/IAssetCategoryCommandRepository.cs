using Inspection.Domain.Models.Accounting.Assets.Setup.AssetCategories;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Command.Accounting.Assets.Setup.AssetCategories
{

    public interface IAssetCategoryCommandRepository : ICommandRepository<AssetCategory>
    {
        Task<ReturnBase> DeleteById(long id);

    }
}
