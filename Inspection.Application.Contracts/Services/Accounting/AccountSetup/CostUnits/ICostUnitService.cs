using Inspection.Application.Contracts.Dto.AccountingDtos.AccountingSetupDtos.CostUnitDTOs;
using Inspection.Application.Contracts.Dto.SharedDtos;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Services.Accounting.AccountSetup.CostUnits
{
    public interface ICostUnitService
    {
        Task<ReturnBase<CostUnitDto>> Create(CostUnitCreateDto createDto);
        Task<ReturnBase<CostUnitDto>> Update(CostUnitUpdateDto updateDto);
        Task<ReturnBase<CostUnitDto>> Delete(long id);
        Task<ReturnBase<CostUnitDto>> GetById(long id);
        Task<ReturnBase<CostUnitDto>> GetByCode(String code);
        Task<ReturnBase<IEnumerable<CostUnitDto>>> Search(SqlQueryOptions sqlQueryOptions);
        //Task<List<CostUnitDto>> GetAll(string tenantId);
        Task<ReturnBase<ImportResultDto>> ImportCostUnits(ExcelImportRequestDto dto);
        Task<ReturnBase<FileResultDto>> DownloadTemplate();
    }
}