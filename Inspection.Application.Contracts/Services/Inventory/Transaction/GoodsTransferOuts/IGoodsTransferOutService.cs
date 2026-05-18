using Inspection.Application.Contracts.Dto.Inventory.Transaction.GoodsTransferOutDTOs;
using Inspection.Application.Contracts.Dto.SharedDtos;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Services.Inventory.Transaction.GoodsTransferOuts
{
    public interface IGoodsTransferOutService
    {
        Task<ReturnBase<GoodsTransferOutDto>> Create(GoodsTransferOutCreateDto createDto);
        Task<ReturnBase<GoodsTransferOutDto>> Update(GoodsTransferOutUpdateDto updateDto);
        Task<ReturnBase<GoodsTransferOutDto>> Delete(long id);
        Task<ReturnBase<GoodsTransferOutDto>> GetById(long id);
        //Task<ReturnBase<GoodsTransferOutDto>> GetByGoodsTransferOutNumber(string goodsTransferOutNumber);
        //Task<ReturnBase<List<GoodsTransferOutDto>>> GetAll();
        Task<ReturnBase<IEnumerable<GoodsTransferOutReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions);
        Task<ReturnBase<ImportResultDto>> ImportGoodsTransferOuts(ExcelImportRequestDto dto);
        Task<ReturnBase<FileResultDto>> DownloadTemplate();
    }
}