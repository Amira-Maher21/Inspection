using Inspection.Application.Contracts.Dto.LocalizationDto;
using Inspection.Domain.Models.Localizations;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.SharedModels;
using NDS.Shared.Kernel.BaseReturnTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Contracts.Services.LocalizationManagement
{
    public interface ILocalizationService: IAccountServiceBase
    {
        Task<ReturnBase<CreateLocalizationDto>> InsertLocalizationAsync(CreateLocalizationDto insertDto);
        Task<ReturnBase<UpdateLocalizationDto>> UpdateLocalizationAsync(UpdateLocalizationDto updateDto);
        Task<ReturnBase<UpdateLocalizationDto>> DeleteLocalizationAsync(EntityKeyValueDictionary keyValuePairs);
        Task<ReturnBase<IEnumerable<GetLocalizationDto>>> GetLocalizationListAsync(SqlQueryOptions sqlQueryOptions);

        Task<ReturnBase<IEnumerable<GetLocalizationDto>>> GetList();

        Task<ReturnBase<Localization>> DeleteLocalization(UpdateLocalizationDto model);
    }
}
