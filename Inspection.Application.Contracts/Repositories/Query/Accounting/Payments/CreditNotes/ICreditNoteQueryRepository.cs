using Inspection.Application.Contracts.Dto.AccountingDtos.Payments.CreditNoteDTOs;
using Inspection.Domain.Models.Accounting.Payment.CreditNotes;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Query.Accounting.Payments.CreditNotes
{
    public interface ICreditNoteQueryRepository : IQueryRepository<CreditNote>
    {
        Task<ReturnBase<List<CreditNote>>> GetAll();
        Task<CreditNote?> GetById(long id);
        Task<ReturnBase<IEnumerable<CreditNoteReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions);
    }
}