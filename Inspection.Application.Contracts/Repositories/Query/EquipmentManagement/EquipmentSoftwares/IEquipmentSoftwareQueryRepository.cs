using Inspection.Application.Contracts.Dto.EquipmentManagement.EquipmentSoftwares;
using Inspection.Domain.Models.EquipmentManagement.EquipmentSoftwares;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Contracts.Repositories.Query.EquipmentManagement.EquipmentSoftwares
{
 
 

    public interface IEquipmentSoftwareQueryRepository : IQueryRepository<EquipmentSoftware>
    {
        Task<EquipmentSoftware?> GetByIdAsync(long id);
        Task<ReturnBase<IEnumerable<EquipmentSoftwareDtoByInclude>>> GetListAsync(SqlQueryOptions sqlQueryOptions);
        Task<ReturnBase<IEnumerable<EquipmentSoftwareDtoByInclude>>> GetListIncludeNameAsync(SqlQueryOptions sqlQueryOptions);
        //Task<ReturnBase<IEnumerable<EquipmentSoftwareDtoByInclude>>> GetLookUpEquipmentSoftwareForNamesAsync(SqlQueryOptions queryOptions);

    }
}
