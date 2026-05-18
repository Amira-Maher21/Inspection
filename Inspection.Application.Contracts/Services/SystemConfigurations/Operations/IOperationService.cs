using Inspection.Application.Contracts.Dto.SystemConfigurationDTOs.OperationDTOs;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.Application.Contracts.Services.SystemConfigurations.Operations
{
    public interface IOperationService
    {
        Task<ReturnBase<OperationDto>> Create(OperationCreateDto dto);
        Task<ReturnBase<OperationDto>> Update(OperationUpdateDto dto);
        Task<ReturnBase<OperationDto>> Delete(long id);

        Task<ReturnBase<OperationDto>> GetById(long id);
        Task<ReturnBase<IEnumerable<OperationDto>>> GetList(SqlQueryOptions? sqlQueryOptions = null);
    }
}
