using Inspection.Application.Contracts.Dto.AccountingDtos.Assets.Setup.AssetCategories;
using Inspection.Application.Contracts.Dto.AccountingDtos.Assets.Setup.AssetComponents;
using Inspection.Application.Contracts.Dto.SharedDtos;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Kernel.BaseReturnTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Contracts.Services.Accounting.Assets.Setup.AssetComponents
{
    public interface IAssetComponentService
    {
        Task<ReturnBase<AssetComponentDto>> Create(AssetComponentCreateDto createDto);
        Task<ReturnBase<AssetComponentDto>> Update(AssetComponentUpdateDto updateDto);
        Task<ReturnBase<AssetComponentDto>> Delete(long id);
        Task<ReturnBase<AssetComponentDto>> GetById(long id);
        Task<ReturnBase<IEnumerable<AssetComponentReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions);

    }
}
