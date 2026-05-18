using Inspection.Application.Contracts.Dto.LocalizationDto;
using Inspection.Domain.Models.Localizations;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Contracts.Repositories.Query.LocalizationManagement
{
    public interface ILocalizationQueryRepository: IQueryRepository<Localization>
    {
        Task<ReturnBase<IEnumerable<GetLocalizationDto>>> GetLocalizationListAsync(SqlQueryOptions sqlQueryOptions);
    }
}
