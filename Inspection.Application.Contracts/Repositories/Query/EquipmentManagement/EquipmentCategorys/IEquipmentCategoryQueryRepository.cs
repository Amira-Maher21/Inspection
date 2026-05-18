using Inspection.Application.Contracts.Dto.EquipmentManagement.EquipmentCategorys;
using Inspection.Domain.Models.EquipmentManagement.EquipmentCategorys;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Contracts.Repositories.Query.EquipmentManagement.EquipmentCategorys
{
 
    public interface IEquipmentCategoryQueryRepository : IQueryRepository<EquipmentCategory>
    {
        Task<EquipmentCategory?> GetByIdAsync(long id);
        Task<ReturnBase<IEnumerable<EquipmentCategoryDtoByInclude>>> GetListAsync(SqlQueryOptions sqlQueryOptions);
        Task<ReturnBase<IEnumerable<EquipmentCategoryDtoByInclude>>> GetListIncludeNameAsync(SqlQueryOptions sqlQueryOptions);
        Task<ReturnBase<IEnumerable<EquipmentCategoryDtoByInclude>>> GetLookUpEquipmentCategoryForNamesAsync(SqlQueryOptions queryOptions);

    }
}
