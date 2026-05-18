using Inspection.Application.Contracts.Dto.AccountingDtos.AccountingSetupDtos.AccountingPeriodDTOs;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Services.Accounting.AccountSetup.AccountingPeriods
{
    public interface IAccountingPeriodService
    {
        Task<ReturnBase<AccountingPeriodDto>> Create(AccountingPeriodCreateDto createDto);
        Task<ReturnBase<AccountingPeriodDto>> Update(AccountingPeriodUpdateDto updateDto);
        Task<ReturnBase<AccountingPeriodDto>> Delete(long id);
        Task<ReturnBase<AccountingPeriodDto>> GetById(long id);
        Task<ReturnBase<IEnumerable<AccountingPeriodReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions);
        //Task<ReturnBase<ImportResultDto>> ImportAccountingPeriods(ExcelImportRequestDto dto);
        //Task<ReturnBase<FileResultDto>> DownloadTemplate();
    }
}
