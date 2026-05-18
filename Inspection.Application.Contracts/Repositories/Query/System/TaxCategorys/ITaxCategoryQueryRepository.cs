using Inspection.Application.Contracts.Dto.SystemDto.TaxCategorys;
using Inspection.Domain.Models.System.Taxestegories;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Query.System.TaxCategorys
{
    public interface ITaxCategoryQueryRepository
    {
        Task<TaxCategory?> GetById(long id);
        Task<ReturnBase<IEnumerable<TaxCategoryDto>>> Search(SqlQueryOptions sqlQueryOptions);
    }
}
