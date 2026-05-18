using Inspection.Application.Contracts.Dto.AccountingDtos.Payments.CashReceiptDTOs;
using Inspection.Domain.Models.Accounting.Payment.CashReceipts;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Query.Accounting.Payments.CashReceipts
{
    public interface ICashReceiptQueryRepository : IQueryRepository<CashReceipt>
    {
        Task<ReturnBase<List<CashReceipt>>> GetAll();
        Task<CashReceipt?> GetById(long id);
        Task<ReturnBase<IEnumerable<CashReceiptReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions);
    }
}