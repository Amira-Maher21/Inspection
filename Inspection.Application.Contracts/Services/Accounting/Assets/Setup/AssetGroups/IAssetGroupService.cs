using Inspection.Application.Contracts.Dto.AccountingDtos.Assets.Setup.AssetCategories;
using Inspection.Application.Contracts.Dto.AccountingDtos.Assets.Setup.AssetGroupDTOs;
using Inspection.Application.Contracts.Dto.AccountingDtos.Payments.CashTransferDTOs;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Kernel.BaseReturnTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Contracts.Services.Accounting.Assets.Setup.AssetGroups
{
    public interface IAssetGroupService
    {
        Task<ReturnBase<AssetGroupDto>> Create(AssetGroupCreateDto createDto);
        Task<ReturnBase<AssetGroupDto>> Update(AssetGroupUpdateDto updateDto);
        Task<ReturnBase<AssetGroupDto>> Delete(long id);
        Task<ReturnBase<AssetGroupDto>> GetById(long id);
        
        Task<ReturnBase<IEnumerable<AssetGroupReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions);
    }
}
