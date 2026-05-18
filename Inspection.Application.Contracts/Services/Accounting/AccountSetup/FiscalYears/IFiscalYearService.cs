using Inspection.Application.Contracts.Dto.AccountingDtos.AccountingSetupDtos.FiscalYearDTOs;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Services.Accounting.AccountSetup.FiscalYears
{
    public interface IFiscalYearService
    {
        Task<ReturnBase<FiscalYearDto>> Create(FiscalYearCreateDto createDto);
        Task<ReturnBase<FiscalYearDto>> Update(FiscalYearUpdateDto updateDto);
        Task<ReturnBase<FiscalYearDto>> Delete(long id);
        Task<ReturnBase<FiscalYearDto>> GetById(long id);
        Task<ReturnBase<IEnumerable<FiscalYearDto>>> Search(SqlQueryOptions sqlQueryOptions);
    }
}