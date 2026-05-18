using Inspection.Application.Contracts.Dto.EquipmentManagement.Series;
using Inspection.Application.Contracts.Dto.InspectionManagement.InspectorCategory;
using Inspection.Application.Contracts.Dto.InspectionManagement.ServicesItemsF;
using Inspection.Application.Contracts.Managers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NDS.Shared.Application.DataQuery;

namespace Inspection.API.Controllers.Controllers.InspectionManagement.ServiceItemF
{
    [Route("api/inspection-serviceitem/[action]")]
    [ApiController]


    public class ServiceItemController : ControllerBase
    {
        private readonly IAccountsServicesManger _servicesManger;
        public ServiceItemController(IAccountsServicesManger servicesManger)
        {
            _servicesManger = servicesManger;
        }
        [HttpPost]
        public async Task<IActionResult> Index(SqlQueryOptions sqlQueryOptions)
        {
            var getResult = await _servicesManger.ServicesItemsService.GetListByIncludeAsync(sqlQueryOptions);
            if (getResult.Succeeded)
            {
                return Ok(getResult.Result);
            }
            return StatusCode(500, getResult.Errors);
        }
        [HttpGet]
        public async Task<ActionResult<List<ServiceItemLookupDefualtDto>>> ServiceItemLookupDefualt([FromQuery] SqlQueryOptions sqlQueryOptions)
        {
            var result = await _servicesManger.ServicesItemsService.ServiceItemLookupDefualt(sqlQueryOptions);
            if (result.Succeeded)
                return Ok(result.Result);
            return StatusCode(500, result.Errors);
        }
     
        [HttpGet]
        public async Task<ActionResult<List<ServiceItemLookUpByIdForInspectionRequestDto>>> ServiceItemLookUpForInspectionServiceOrder ([FromQuery] SqlQueryOptions sqlQueryOptions)
        {
            var result = await _servicesManger.ServicesItemsService.ServiceItemLookUpByIdData(sqlQueryOptions);
            if (result.Succeeded)
                return Ok(result.Result);
            return StatusCode(500, result.Errors);
        }

        

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var result = await _servicesManger.ServicesItemsService.GetAsync(id);
            if (result.Succeeded)
                return Ok(result.Result);
            return StatusCode(500, result.Errors);
        }

        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var result = await _servicesManger.ServicesItemsService.GetListAsync();
            if (result.Succeeded)
                return Ok(result.Result);
            return StatusCode(500, result.Errors);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateServiceItemDto input)
        {
            var result = await _servicesManger.ServicesItemsService.CreateAsync(input);
            if (result.Succeeded)
                return Ok(result.Result);
            return StatusCode(500, result.Errors);
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateServiceItemDto input)
        {
            var result = await _servicesManger.ServicesItemsService.UpdateAsync(id, input);
            if (result.Succeeded)
                return Ok(result.Result);
            return StatusCode(500, result.Errors);
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var result = await _servicesManger.ServicesItemsService.DeleteAsync(id);
            if (result.Succeeded)
                return Ok();
            return StatusCode(500, result.Errors);
        }

    }
}
