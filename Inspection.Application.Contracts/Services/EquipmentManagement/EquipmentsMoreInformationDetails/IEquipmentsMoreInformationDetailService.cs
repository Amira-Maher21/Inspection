using Inspection.Application.Contracts.Dto.EquipmentManagement.EquipmentsMoreInformationDetails;
 using NDS.Shared.Application.DataQuery;
using NDS.Shared.Kernel.BaseReturnTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Contracts.Services.EquipmentManagement.EquipmentsMoreInformationDetails
{
   
 
    public interface IEquipmentsMoreInformationDetailService : IAccountServiceBase
    {

        Task<ReturnBase<UpdateEquipmentsMoreInformationDetailDto>> InsertEquipmentsMoreInformationDetailAsync(CreateEquipmentsMoreInformationDetailDto insertDto);
        Task<ReturnBase<UpdateEquipmentsMoreInformationDetailDto>> UpdateEquipmentsMoreInformationDetailAsync(UpdateEquipmentsMoreInformationDetailDto updateDto, long id);
        Task<ReturnBase<UpdateEquipmentsMoreInformationDetailDto>> DeleteEquipmentsMoreInformationDetailAsync(long id);
        Task<ReturnBase<EquipmentsMoreInformationDetailDto>> GetEquipmentsMoreInformationDetailByIdAsync(long id);
        Task<ReturnBase<List<EquipmentMoreInformationDetailsKeyValueDto>>> GetByEquipmentTypeIdAsync(long EquipmentTypeId);
        Task<ReturnBase<IEnumerable<EquipmentsMoreInformationDetailDtoByInclude>>> GetEquipmentsMoreInformationDetailListAsync(SqlQueryOptions sqlQueryOptions);
        Task<List<EquipmentsMoreInformationDetailDtoByInclude>> GetListAsync();
        Task<ReturnBase<IEnumerable<EquipmentsMoreInformationDetailDtoByInclude>>> GetEquipmentsMoreInformationDetailListByIncludeAsync(SqlQueryOptions sqlQueryOptions);

        //Task<ReturnBase<IEnumerable<EquipmentsMoreInformationDetailDtoLookUpForNames>>> GetLookUpEquipmentsMoreInformationDetailForNamesAsync(SqlQueryOptions queryOptions);

    }
}
