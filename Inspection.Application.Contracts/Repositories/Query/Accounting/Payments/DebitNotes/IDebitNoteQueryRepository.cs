using Inspection.Application.Contracts.Dto.AccountingDtos.Payments.DebitNoteDTOs;
using Inspection.Domain.Models.Accounting.Payment.DebitNotes;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Query.Accounting.Payments.DebitNotes
{
    public interface IDebitNoteQueryRepository : IQueryRepository<DebitNote>
    {
        Task<ReturnBase<List<DebitNote>>> GetAll();
        Task<DebitNote?> GetById(long id);
        Task<ReturnBase<IEnumerable<DebitNoteReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions);
    }
}