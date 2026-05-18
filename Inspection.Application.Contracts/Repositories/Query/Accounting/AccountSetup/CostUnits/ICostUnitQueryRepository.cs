using Inspection.Application.Contracts.Dto.AccountingDtos.AccountingSetupDtos.CostUnitDTOs;
using Inspection.Domain.Models.Accounting.AccountingSetup.CostUnits;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Query.Accounting.AccountSetup.CostUnits
{
    public interface ICostUnitQueryRepository : IQueryRepository<CostUnit>
    {
        Task<CostUnit?> GetById(long id);
        Task<CostUnit?> GetByCode(string code);
        //Task<List<CostUnitDto>> GetAll(string tenantId);
        Task<ReturnBase<IEnumerable<CostUnitDto>>> Search(SqlQueryOptions sqlQueryOptions);
    }
}
