using Inspection.Domain.Models.Accounting.AccountingSetup.ModeOfPayments;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Command.Accounting.AccountSetup.ModeOfPayments
{
    public interface IModeOfPaymentCommandRepository : ICommandRepository<ModeOfPayment>
    {

        Task<ReturnBase> DeleteById(long id);

    }
}
