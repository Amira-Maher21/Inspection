using Inspection.Application.Contracts.Dto.EquipmentManagement.EquipmentAccessories;
using Inspection.Domain.Models.EquipmentManagement.EquipmentAccessories;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Contracts.Repositories.Query.EquipmentManagement.EquipmentAccessories
{ 
    public interface IEquipmentAccessoryQueryRepository : IQueryRepository<EquipmentAccessory>
    {
        Task<EquipmentAccessory?> GetByIdAsync(long id);
        Task<ReturnBase<IEnumerable<EquipmentAccessoryDtoByInclude>>> GetListAsync(SqlQueryOptions sqlQueryOptions);
        Task<ReturnBase<IEnumerable<EquipmentAccessoryDtoByInclude>>> GetListIncludeNameAsync(SqlQueryOptions sqlQueryOptions);
        //Task<ReturnBase<IEnumerable<EquipmentAccessoryDtoByInclude>>> GetLookUpEquipmentAccessoryForNamesAsync(SqlQueryOptions queryOptions);

    }
}

