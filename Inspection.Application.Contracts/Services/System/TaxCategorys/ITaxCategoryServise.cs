using Inspection.Application.Contracts.Dto.SystemDto.TaxCategorys;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Services.System.TaxCategorys
{
    public interface ITaxCategoryServise
    {
        Task<ReturnBase<TaxCategoryDto>> Create(TaxCategoryCreateDto dto);
        Task<ReturnBase<TaxCategoryDto>> Update(TaxCategoryUpdateDto dto);
        Task<ReturnBase<TaxCategoryDto>> Delete(long id);

        Task<ReturnBase<TaxCategoryDto>> GetById(long id);

        Task<ReturnBase<IEnumerable<TaxCategoryDto>>> Search(SqlQueryOptions sqlQueryOptions);

    }
}
