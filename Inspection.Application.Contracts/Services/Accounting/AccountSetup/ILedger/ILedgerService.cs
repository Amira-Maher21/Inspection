using Inspection.Application.Contracts.Dto.AccountingDtos.AccountingSetupDtos.LedgerDTOs;
using Inspection.Application.Contracts.Dto.AccountingDtos.AccountingSetupDtos.LedgerDTOs.LedgerLineDTOs;
using Inspection.Application.Contracts.Dto.SalesManagment.sales.SalesOrder;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Kernel.BaseReturnTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Contracts.Services.Accounting.AccountSetup.ILedger
{
    public interface ILedgerService : IAccountServiceBase
    {
        Task<ReturnBase<List<LedgerDto>>> Index(SqlQueryOptions sqlQueryOptions);

        Task<ReturnBase<UpdateLedgerDto>> CreateAsync(CreateLedgerDto input);

        Task<ReturnBase<UpdateLedgerDto>> UpdateAsync(UpdateLedgerDto input);

        Task<ReturnBase<LedgerDto>> GetAsync(long id);

        Task<ReturnBase<bool>> DeleteAsync(long id);

        Task<ReturnBase<IEnumerable<ViewEntryLedgerDto>>> ViewEntry(SqlQueryOptions sqlQueryOptions);
    }
}
