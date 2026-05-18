using Inspection.Application.Contracts.Dto.AccountingDtos.AccountingSetupDtos.LedgerDTOs;
using Inspection.Application.Contracts.Dto.AccountingDtos.AccountingSetupDtos.LedgerDTOs.LedgerLineDTOs;
using Inspection.Domain.Models.Inventory.Ledger;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.RepositoryBase;

namespace Inspection.Application.Contracts.Repositories.Query.Accounting.AccountSetup.LedgerQueryRepository
{
    public interface ILedgerQueryRepository : IQueryRepository<Ledger>
    {
        Task<Ledger?> GetByIdAsync(long id);
        Task<IEnumerable<LedgerDto?>> GetListByIncludeAsync(SqlQueryOptions sqlQueryOptions);

        //Task<IEnumerable<ViewEntryLedgerDto?>> GetLedgerLinesByDocumentAsync(string documentCode, long referenceDocumentId);    
        Task<IEnumerable<ViewEntryLedgerDto?>> GetLedgerLinesByDocumentAsync(SqlQueryOptions sqlQueryOptions);
    }
}
