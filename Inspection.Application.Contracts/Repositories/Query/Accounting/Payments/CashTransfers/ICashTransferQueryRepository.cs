using Inspection.Application.Contracts.Dto.AccountingDtos.Payments.CashTransferDTOs;
using Inspection.Domain.Models.Accounting.Payment.CashTransfers;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Query.Accounting.Payments.CashTransfers
{
    public interface ICashTransferQueryRepository : IQueryRepository<CashTransfer>
    {
        Task<ReturnBase<List<CashTransfer>>> GetAll();
        Task<CashTransfer?> GetById(long id);
        Task<ReturnBase<IEnumerable<CashTransferReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions);
    }
}