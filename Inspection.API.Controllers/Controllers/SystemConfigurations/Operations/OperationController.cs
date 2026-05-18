using Inspection.Application.Contracts.Dto.SystemConfigurationDTOs.OperationDTOs;
using Inspection.Application.Contracts.Managers;
using Microsoft.AspNetCore.Mvc;
using NDS.Shared.API.ControllersBase;
using NDS.Shared.Kernel.BaseReturnTypes;

namespace Inspection.API.Controllers.Controllers.SystemConfigurations.Operations
{
    [Route("api/Operation/[action]")]
    [ApiController]
    public class OperationController : InspectionControllerBase
    {
        private readonly IAccountsServicesManger _servicesManger;

        public OperationController(IAccountsServicesManger servicesManger)
        {
            _servicesManger = servicesManger;
        }

        [HttpPost]
        public async Task<ReturnBase<OperationDto>> Create([FromBody] OperationCreateDto dto)
        {
            return await _servicesManger.OperationService.Create(dto);
        }

        [HttpPut]
        public async Task<ReturnBase<OperationDto>> Update([FromBody] OperationUpdateDto dto)
        {
            return await _servicesManger.OperationService.Update(dto);
        }

        [HttpDelete("{id}")]
        public async Task<ReturnBase<OperationDto>> Delete(long id)
        {
            return await _servicesManger.OperationService.Delete(id);
        }

        [HttpGet("{id}")]
        public async Task<ReturnBase<OperationDto>> GetById(long id)
        {
            return await _servicesManger.OperationService.GetById(id);
        }

        [HttpGet]
        public async Task<ReturnBase<IEnumerable<OperationDto>>> GetList()
        {
            return await _servicesManger.OperationService.GetList();
        }
    }
}
