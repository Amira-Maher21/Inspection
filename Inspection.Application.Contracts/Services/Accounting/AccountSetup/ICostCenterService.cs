using Inspection.Application.Contracts.Dto.AccountingDtos.AccountingSetupDtos.CostCenterDTOs;
using Inspection.Application.Contracts.Dto.SharedDtos;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Services.Accounting.AccountSetup
{
    public interface ICostCenterService //: IAccountServiceBase
    {
        Task<ReturnBase<CostCenterDto>> Create(CostCenterCreateDto createDto);
        Task<ReturnBase<CostCenterDto>> Update(CostCenterUpdateDto updateDto);
        Task<ReturnBase<CostCenterDto>> Delete(long id);
        Task<ReturnBase<CostCenterDto>> GetById(long id);
        Task<ReturnBase<CostCenterDto>> GetByCode(String code);
        Task<ReturnBase<IEnumerable<CostCenterReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions);
        Task<List<CostCenterDto>> GetAll();


        Task<ReturnBase<ImportResultDto>> ImportCostCenter(ExcelImportRequestDto dto);
        Task<ReturnBase<FileResultDto>> DownloadTemplate();


    }
}