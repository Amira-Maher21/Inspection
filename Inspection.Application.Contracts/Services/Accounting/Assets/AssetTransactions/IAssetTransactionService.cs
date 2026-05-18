using Inspection.Application.Contracts.Dto.AccountingDtos.Assets.AssetTransactions;
using Inspection.Application.Contracts.Dto.SharedDtos;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Services.Accounting.Assets.AssetTransactions
{
    public interface IAssetTransactionService
    {

        Task<ReturnBase<AssetTransactionDto>> Create(AssetTransactionCreateDto createDto);
        Task<ReturnBase<AssetTransactionDto>> Update(AssetTransactionUpdateDto updateDto);
        Task<ReturnBase<AssetTransactionDto>> Delete(long id);
        Task<ReturnBase<AssetTransactionDto>> GetById(long id);

        Task<ReturnBase<IEnumerable<AssetTransactionReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions);


        Task<ReturnBase<ImportResultDto>> ImportAssetTransaction(ExcelImportRequestDto dto);
        Task<ReturnBase<FileResultDto>> DownloadTemplate();
    }
}
