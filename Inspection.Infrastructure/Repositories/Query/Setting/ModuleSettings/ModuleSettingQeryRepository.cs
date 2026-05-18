using Inspection.Application.Contracts.Dto.Setting.ModuleSettings;
using Inspection.Application.Contracts.Repositories.Query.Setting.ModuleSettings;
using Inspection.Domain.Models.Seeting.ModuleSettings;
using Inspection.Infrastructure.QueryObjects.Setting.ModuleSetting;
using Microsoft.EntityFrameworkCore;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.Repositories.Query.Setting.ModuleSettings
{
    public class ModuleSettingQeryRepository : QueryRepositoryBase<ModuleSetting>, IModuleSettingQueryRepository
    {
        public ModuleSettingQeryRepository(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, DbContext context, ITenantResolver tenantResolver, IExceptionManager exceptionManager) : base(queryBuilder, dapper, context, tenantResolver, exceptionManager)
        {

        }

        public async Task<ModuleSetting?> GetById(long id)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.Id == id);
        }







        public async Task<ReturnBase<IEnumerable<ModuleSettingReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions)
        {
            var TaxQueryRepository = new ModuleSettingQuery(_queryBuilder, _dapper, _tenantResolver, _exceptionManager);
            return await TaxQueryRepository.Query(sqlQueryOptions);
        }
    }
}
