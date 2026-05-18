using Inspection.Application.Contracts.Dto.Inventory.Transaction.GoodsIssues;
using Inspection.Application.Contracts.Dto.SharedDtos;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Services.Inventory.Transaction.GoodsIssues
{
    public interface IGoodsIssueService
    {
        Task<ReturnBase<GoodsIssueDto>> Create(GoodsIssueCreateDto createDto);
        Task<ReturnBase<GoodsIssueDto>> Update(GoodsIssueUpdateDto updateDto);
        Task<ReturnBase<GoodsIssueDto>> Delete(long id);
        Task<ReturnBase<GoodsIssueDto>> GetById(long id);
        Task<ReturnBase<IEnumerable<GoodsIssueReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions);

        // Excel / Import related
        Task<ReturnBase<ImportResultDto>> ImportGoodsIssue(ExcelImportRequestDto dto);
        Task<ReturnBase<FileResultDto>> DownloadGoodsIssueTemplate();
    }
}

