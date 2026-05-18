using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Command.Accounting.AccountSystem.PaymentTerm
{
    public interface IPaymentTermCommandRepository : ICommandRepository<Domain.Models.Accounting.AccountingSystem.PaymentTerms.PaymentTerm>
    {
        Task<ReturnBase> DeleteById(long id);
    }
}
