using Inspection.Domain.Models.Accounting.Assets.Setup.AssetCategories;
using Inspection.Domain.Models.Accounting.Assets.Setup.AssetGroups;
using Inspection.Domain.Models.Accounting.Payment.CashPayments;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Contracts.Repositories.Command.Accounting.Assets.Setup.FixedAssets
{
    public interface IAssetGroupCommandRepository : ICommandRepository<AssetGroup>
    {
        Task<ReturnBase> DeleteById(long id);
    }
}
