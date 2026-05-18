using Inspection.Application.Contracts.Dto.EquipmentManagement.EquipmentCalibrationHistorys;
using Inspection.Domain.Models.EquipmentManagement.EquipmentCalibrationHistorys;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.RepositoryBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Contracts.Repositories.Query.EquipmentManagement.EquipmentCalibrationHistorys
{
 
    public interface IEquipmentCalibrationHistoryQueryRepository : IQueryRepository<EquipmentCalibrationHistory>
    {
        Task<EquipmentCalibrationHistory?> GetByIdAsync(long id);
        Task<ReturnBase<IEnumerable<EquipmentCalibrationHistoryDtoByInclude>>> GetListAsync(SqlQueryOptions sqlQueryOptions);
        Task<ReturnBase<IEnumerable<EquipmentCalibrationHistoryDtoByInclude>>> GetListIncludeNameAsync(SqlQueryOptions sqlQueryOptions);
        //Task<ReturnBase<IEnumerable<EquipmentCalibrationHistoryDtoByInclude>>> GetLookUpEquipmentCalibrationHistoryForNamesAsync(SqlQueryOptions queryOptions);

    }
}

