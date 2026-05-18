using Inspection.Application.Contracts.Dto.InspectionManagement.InspectionMethodDTOs;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Services.InspectionManagement.InspectionMethods
{

    public interface IInspectionMethodService : IAccountServiceBase
    {
        Task<ReturnBase<InspectionMethodDto>> Create(InspectionMethodCreateDto createDto);
        Task<ReturnBase<InspectionMethodDto>> Update(InspectionMethodUpdateDto updateDto);
        Task<ReturnBase<InspectionMethodDto>> Delete(long id);
        Task<ReturnBase<InspectionMethodDto>> GetById(long id);
        //Task<ReturnBase<List<InspectionMethodDto>>> GetAll();
        Task<ReturnBase<IEnumerable<InspectionMethodReturnSearchDto>>> Search(SqlQueryOptions sqlQueryOptions);
    }
}