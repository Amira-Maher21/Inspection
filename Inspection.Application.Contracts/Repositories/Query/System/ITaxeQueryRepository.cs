using Inspection.Application.Contracts.Dto.SystemDto.Taxs;
using Inspection.Domain.Models.System.Taxes;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Query.System
{
    public interface ITaxTypeQueryRepository
    {
        Task<TaxType?> GetById(long id);
        Task<IEnumerable<TaxType>> GetList(SqlQueryOptions sqlQueryOptions = null);
        Task<ReturnBase<IEnumerable<TaxReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions);

    }
}
