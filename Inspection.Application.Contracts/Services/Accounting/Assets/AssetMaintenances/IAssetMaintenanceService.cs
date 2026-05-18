using Inspection.Application.Contracts.Dto.AccountingDtos.Assets.AssetMaintenanceDTOs;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Services.Accounting.Assets.AssetMaintenances
{
    public interface IAssetMaintenanceService
    {
        Task<ReturnBase<AssetMaintenanceDto>> Create(AssetMaintenanceCreateDto createDto);
        Task<ReturnBase<AssetMaintenanceDto>> Update(AssetMaintenanceUpdateDto updateDto);
        Task<ReturnBase<AssetMaintenanceDto>> Delete(long id);
        Task<ReturnBase<AssetMaintenanceDto>> GetById(long id);
        //Task<ReturnBase<List<AssetMaintenanceDto>>> GetAll();
        Task<ReturnBase<IEnumerable<AssetMaintenanceReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions);
    }
}