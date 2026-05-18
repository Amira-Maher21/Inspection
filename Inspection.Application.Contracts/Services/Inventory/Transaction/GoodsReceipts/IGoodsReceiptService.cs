using Inspection.Application.Contracts.Dto.Inventory.Transaction.GoodsReceipts;
using Inspection.Application.Contracts.Dto.SharedDtos;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Services.Inventory.Transaction.GoodsReceipts
{
    public interface IGoodsReceiptService
    {
        Task<ReturnBase<GoodsReceiptDto>> Create(GoodsReceiptCreateDto createDto);
        Task<ReturnBase<GoodsReceiptDto>> Update(GoodsReceiptUpdateDto updateDto);
        Task<ReturnBase<GoodsReceiptDto>> Delete(long id);
        Task<ReturnBase<GoodsReceiptDto>> GetById(long id);
        //Task<ReturnBase<List<GoodsReceiptDto>>> GetAll();
        Task<ReturnBase<IEnumerable<GoodsReceiptReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions);
        Task<ReturnBase<ImportResultDto>> ImportGoodsReceipts(ExcelImportRequestDto dto);
        Task<ReturnBase<FileResultDto>> DownloadTemplate();
    }
}
