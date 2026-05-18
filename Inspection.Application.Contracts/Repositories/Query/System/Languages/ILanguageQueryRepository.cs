using Inspection.Application.Contracts.Dto.SystemDto.Languages;
using Inspection.Domain.Models.System.Languages;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Repositories.Query.System.Languages
{

    public interface ILanguageQueryRepository
    {
        Task<Language?> GetById(string LocaleCode);
        Task<ReturnBase<IEnumerable<LanguageReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions);

        Task<IEnumerable<Language>> GetList(SqlQueryOptions sqlQueryOptions = null);

    }
}
