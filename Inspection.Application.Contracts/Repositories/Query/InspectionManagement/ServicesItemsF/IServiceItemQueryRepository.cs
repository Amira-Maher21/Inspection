using Inspection.Application.Contracts.Dto.InspectionManagement.InspectorCategory;
using Inspection.Application.Contracts.Dto.InspectionManagement.ServicesItemsF;
using Inspection.Domain.Models.InspectionManagement.ServicesItems;
using Inspection.Domain.Models.MenuManagement;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Contracts.Repositories.Query.InspectionManagement.ServicesItemsF
{
    public interface IServiceItemQueryRepository : IQueryRepository<ServiceItem>
    {

        Task<ServiceItem?> GetByIdAsync(long id);
        Task<IEnumerable<ServiceItemIncludeDto?>> GetListByIncludeAsync(SqlQueryOptions sqlQueryOptions);
        


    }
}
