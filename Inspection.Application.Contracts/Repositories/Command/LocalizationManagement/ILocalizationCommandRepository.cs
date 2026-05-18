using Inspection.Application.Contracts.Dto.LocalizationDto;
using Inspection.Domain.Models.Localizations;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Application.SharedModels;
using NDS.Shared.Kernel.BaseReturnTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace Inspection.Application.Contracts.Repositories.Command.LocalizationManagement
{
    public interface ILocalizationCommandRepository: ICommandRepository<Localization>
    {
        Task<ReturnBase<Localization>> DeleteLocalizationAsync(UpdateLocalizationDto model);
    }
}
