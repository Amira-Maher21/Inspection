using Inspection.Application.Contracts.Dto.EquipmentManagement.EquipmentCalibrationHistorys;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Kernel.BaseReturnTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Contracts.Services.EquipmentManagement.EquipmentCalibrationHistorys
{
    

    public interface IEquipmentCalibrationHistoryService : IAccountServiceBase
    {

        Task<ReturnBase<UpdateEquipmentCalibrationHistoryDto>> InsertEquipmentCalibrationHistoryAsync(CreateEquipmentCalibrationHistoryDto insertDto);
        Task<ReturnBase<UpdateEquipmentCalibrationHistoryDto>> UpdateEquipmentCalibrationHistoryAsync(UpdateEquipmentCalibrationHistoryDto updateDto, long id);
        Task<ReturnBase<UpdateEquipmentCalibrationHistoryDto>> DeleteEquipmentCalibrationHistoryAsync(long id);
        Task<ReturnBase<EquipmentCalibrationHistoryDto>> GetEquipmentCalibrationHistoryByIdAsync(long id);
        Task<ReturnBase<IEnumerable<EquipmentCalibrationHistoryDtoByInclude>>> GetEquipmentCalibrationHistoryListAsync(SqlQueryOptions sqlQueryOptions);
        Task<List<EquipmentCalibrationHistoryDtoByInclude>> GetListAsync();
        Task<ReturnBase<IEnumerable<EquipmentCalibrationHistoryDtoByInclude>>> GetEquipmentCalibrationHistoryListByIncludeAsync(SqlQueryOptions sqlQueryOptions);

        //Task<ReturnBase<IEnumerable<EquipmentCalibrationHistoryDtoLookUpForNames>>> GetLookUpEquipmentCalibrationHistoryForNamesAsync(SqlQueryOptions queryOptions);

    }
}

