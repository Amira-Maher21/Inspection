using Inspection.Application.Contracts.Dto.AccountingDtos.ChartOfAccounts.AccountTypeDTOs;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Services.Accounting.ChartOfAccounts
{
    public interface IAccountTypeService
    {
        Task<ReturnBase<List<AcountTypeDto>>> GetAll();
        Task<ReturnBase<AcountTypeDto>> GetByCode(String code);
    }
}