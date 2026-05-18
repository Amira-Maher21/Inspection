using Inspection.Application.Contracts.Dto.SystemDto.Taxs;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Services.System
{
    public interface ITaxTypeServise
    {

        Task<ReturnBase<TaxDto>> Create(TaxCreateDto dto);
        Task<ReturnBase<TaxDto>> Update(TaxUpdateDto dto);
        Task<ReturnBase<TaxDto>> Delete(long id);

        Task<ReturnBase<TaxDto>> GetById(long id);
        Task<ReturnBase<IEnumerable<TaxDto>>> GetList(SqlQueryOptions? sqlQueryOptions = null);

        Task<ReturnBase<IEnumerable<TaxReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions);



    }
}
