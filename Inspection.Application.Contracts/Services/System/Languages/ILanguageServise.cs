using Inspection.Application.Contracts.Dto.SystemDto.Languages;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Services.System.Languages
{
    public interface ILanguageServise
    {


        Task<ReturnBase<LanguageDto>> Create(LanguageCreateDto dto);
        Task<ReturnBase<LanguageDto>> Update(LanguageUpdateDto dto);
        Task<ReturnBase<LanguageDto>> Delete(string LocaleCode);

        Task<ReturnBase<LanguageDto>> GetById(string LocaleCode);
        Task<ReturnBase<IEnumerable<LanguageDto>>> GetList(SqlQueryOptions? sqlQueryOptions = null);

        Task<ReturnBase<IEnumerable<LanguageReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions);
    }
}
