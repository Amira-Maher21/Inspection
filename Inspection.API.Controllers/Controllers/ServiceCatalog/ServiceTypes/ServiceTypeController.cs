using Inspection.Application.Contracts.Dto.ServiceCatalog.ServiceTypes;
using Inspection.Application.Contracts.Managers;
using Microsoft.AspNetCore.Mvc;
using NDS.Shared.API.ControllersBase;
using NDS.Shared.Application.DataQuery;

namespace Inspection.API.Controllers.Controllers.ServiceCatalog.ServiceTypes
{
    [Route("api/service-types/[action]")]
    [ApiController]
    public class ServiceTypeController : InspectionControllerBase
    {
        private readonly IAccountsServicesManger _servicesManger;

        public ServiceTypeController(IAccountsServicesManger servicesManger)
        {
            _servicesManger = servicesManger;
        }


        [HttpPost]

        public async Task<IActionResult> Create(CreateServiceTypeDto insertDto)
        {
            var insertResult = await _servicesManger.ServiceTypeService.InsertServiceTypeAsync(insertDto);
            if (insertResult.Succeeded)
            {
                return Ok(insertResult.Result);
            }
            return StatusCode(500, insertResult.Errors);
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> Update(UpdateServiceTypeDto UpdateServiceTypeDto, long id)
        {
            var updateResult = await _servicesManger.ServiceTypeService.UpdateServiceTypeAsync(UpdateServiceTypeDto, id);
            if (updateResult.Succeeded)
            {
                return Ok(updateResult.Result);
            }
            return StatusCode(500, updateResult.Errors);
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var deleteResult = await _servicesManger.ServiceTypeService.DeleteServiceTypeAsync(id);
            if (deleteResult.Succeeded)
            {
                return Ok(deleteResult.Result);
            }
            return StatusCode(500, deleteResult.Errors);
        }




        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var getResult = await _servicesManger.ServiceTypeService.GetServiceTypeByIdAsync(id);
            if (getResult.Succeeded)
            {
                return Ok(getResult.Result);
            }
            return StatusCode(500, getResult.Errors);
        }

        [HttpPost]
        public async Task<IActionResult> Index(SqlQueryOptions sqlQueryOptions)
        {
            var getResult = await _servicesManger.ServiceTypeService.GetServiceTypeListByIncludeAsync(sqlQueryOptions);
            if (getResult.Succeeded)
            {
                return Ok(getResult.Result);
            }
            return StatusCode(500, getResult.Errors);
        }

        [HttpGet]
        public async Task<IActionResult> LookUpServiceTypeForNames([FromQuery] SqlQueryOptions sqlQueryOptions)
        {
            var getResult = await _servicesManger.ServiceTypeService.GetLookUpServiceTypeForNamesAsync(sqlQueryOptions);
            if (getResult.Succeeded)
            {
                return Ok(getResult.Result);
            }
            return StatusCode(500, getResult.Errors);
        }
    }

}
