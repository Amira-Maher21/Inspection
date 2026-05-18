using Inspection.Application.Contracts.Dto.Inventory.Transaction.GoodsTransferInDTOs;
using Inspection.Application.Contracts.Dto.SharedDtos;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Services.Inventory.Transaction.GoodsTransferIns
{
    public interface IGoodsTransferInService
    {
        Task<ReturnBase<GoodsTransferInDto>> Create(GoodsTransferInCreateDto createDto);
        Task<ReturnBase<GoodsTransferInDto>> Update(GoodsTransferInUpdateDto updateDto);
        Task<ReturnBase<GoodsTransferInDto>> Delete(long id);
        Task<ReturnBase<GoodsTransferInDto>> GetById(long id);
        //Task<ReturnBase<GoodsTransferInDto>> GetByGoodsTransferInNumber(string goodsTransferInNumber);
        //Task<ReturnBase<List<GoodsTransferInDto>>> GetAll();
        Task<ReturnBase<IEnumerable<GoodsTransferInReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions);
        Task<ReturnBase<ImportResultDto>> ImportGoodsTransferIns(ExcelImportRequestDto dto);
        Task<ReturnBase<FileResultDto>> DownloadTemplate();
    }
}
