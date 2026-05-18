using Inspection.Application.Contracts.Dto.AccountingDtos.ChartOfAccounts.ChartOfAccountDTOs;
using Inspection.Application.Contracts.Dto.SharedDtos;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Services.Accounting.ChartOfAccounts
{
    public interface IChartOfAccountService
    {
        Task<ReturnBase<ChartOfAccountDto>> Create(ChartOfAccountCreateDto createDto);
        Task<ReturnBase<ChartOfAccountDto>> Update(ChartOfAccountUpdateDto updateDto);
        Task<ReturnBase<ChartOfAccountDto>> Delete(long id);
        Task<ReturnBase<ChartOfAccountDto>> GetById(long id);
        Task<ReturnBase<ChartOfAccountDto>> GetByCode(String code);
        Task<ReturnBase<List<ChartOfAccountDto>>> GetAll();
        Task<ReturnBase<IEnumerable<ChartOfAccountReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions);
        Task<ReturnBase<ImportResultDto>> ImportChartOfAccounts(ExcelImportRequestDto dto);
        Task<ReturnBase<FileResultDto>> DownloadTemplate();



        Task<ReturnBase<IEnumerable<ChartOfAccountSelectQueryDto>>> Select(SqlQueryOptions sqlQueryOptions);
    }
}