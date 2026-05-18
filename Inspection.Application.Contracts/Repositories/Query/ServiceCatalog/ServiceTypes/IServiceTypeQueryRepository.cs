
using Inspection.Application.Contracts.Dto.ServiceCatalog.ServiceTypes;
using Inspection.Domain.Models.ServiceCatalog.ServiceTypes;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Contracts.Repositories.Query.ServiceCatalog.ServiceTypes
{
    public interface IServiceTypeQueryRepository : IQueryRepository<ServiceType>
    {
        //Task<ServiceType?> GetByIdAsync(Guid id);
        //Task<List<ServiceType>> GetListAsync();
        Task<ReturnBase<IEnumerable<ServiceTypeDtoByInclude>>> GetLookUpServiceTypeForNamesAsync(SqlQueryOptions queryOptions);
        Task<ReturnBase<IEnumerable<ServiceTypeDtoByInclude>>> GetListIncludeNameAsync(SqlQueryOptions sqlQueryOptions);

        Task<ServiceType?> GetByIdAsync(long id);
        Task<ReturnBase<IEnumerable<ServiceTypeDtoByInclude>>> GetListAsync(SqlQueryOptions sqlQueryOptions);
 
    }

}
