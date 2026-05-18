using Inspection.Domain.Models.Accounting.Payment.CashTransfers;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Command.Accounting.Payments.CashTransfers
{
    public interface ICashTransferCommandRepository : ICommandRepository<CashTransfer>
    {
        Task<ReturnBase> DeleteById(long id);

        Task<ReturnBase> DeleteCashTransferLinesByCashTransferIds(List<long> ids);
    }
}