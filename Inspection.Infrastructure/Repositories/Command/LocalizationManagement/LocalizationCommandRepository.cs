using Inspection.Application.Contracts.Dto.LocalizationDto;
using Inspection.Application.Contracts.Repositories.Command.LocalizationManagement;
using Inspection.Domain.Models.Localizations;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Application.RepositoryBase.RepositoryHelpers;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace Inspection.Infrastructure.Repositories.Command.LocalizationManagement
{
    internal class LocalizationCommandRepository : CommandRepositoryBase<Localization>, ILocalizationCommandRepository
    {
      
        public LocalizationCommandRepository(DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(context, tenantResolver, exceptionManager)
        {
            

            this._entityStructure = new EntityStructure
            {
                Key = ["LocaleCode", "Caption"]
            };
        }

        public async Task<ReturnBase<Localization>> DeleteLocalizationAsync(UpdateLocalizationDto model)
        {
            try
            {
                if (_entityStructure == null || _entityStructure.Key == null || !_entityStructure.Key.Any())
                {
                    throw new Exception("Entity Structure must be defined!!.");
                }



                var getEntityResult = await _dbSet.FirstOrDefaultAsync(item => item.Caption == model.Caption && item.LocaleCode == model.LocaleCode);
                if (getEntityResult != null)
                {

                    return _entityDeleteHelper.DeleteEntity(getEntityResult, _entityStructure);
                }

                return ReturnBase<Localization>.Success(getEntityResult); 
            }
            catch(Exception ex)
            {
                return ReturnBase<Localization>.Fail(ex, _exceptionManager);
            }

        }
    }
}
