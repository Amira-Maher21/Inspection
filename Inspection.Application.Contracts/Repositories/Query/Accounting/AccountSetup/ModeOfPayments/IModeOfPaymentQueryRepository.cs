using Inspection.Application.Contracts.Dto.AccountingDtos.AccountingSetupDtos.ModeOfPayments;
using Inspection.Domain.Models.Accounting.AccountingSetup.ModeOfPayments;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Query.Accounting.AccountSetup.ModeOfPayments
{
    public interface IModeOfPaymentQueryRepository
    {
        Task<ModeOfPayment?> GetById(long id);
        Task<ReturnBase<IEnumerable<ModeOfPaymentSearchReturnDto>>> Search(SqlQueryOptions sqlQueryOptions);


        //Task<ModeOfPayment?> GetByCode(string code);
    }
}
