using Inspection.Application.Contracts.Repositories.Command.MenuManagement.SeriesF;
using Inspection.Domain.Models.MenuManagement;
using Inspection.Infrastructure.DataContext;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Application.RepositoryBase.RepositoryHelpers;
using NDS.Shared.Infrastructure.RepositoryBase;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.Repositories.Command.MenuManagement.SeriesF
{
    internal class SeriesCommandRepository : CommandRepositoryBase<Series>, ISeriesCommandRepository
    {
        public SeriesCommandRepository(DbInspectionContext context,
                                        ITenantResolver tenantResolver,
                                        IExceptionManager exceptionManager) : base(context, tenantResolver, exceptionManager)
        {
            this._entityStructure = new EntityStructure
            {
                Key = ["Id"],
            };
        }
    }
}
