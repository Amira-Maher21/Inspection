using Inspection.Application.Contracts.Dto.Inventory.InventorySetup.WarehouseLocations;
using Inspection.Application.Contracts.Managers;
using Microsoft.AspNetCore.Mvc;
using NDS.Shared.Application.DataQuery;

namespace Inspection.API.Controllers.Controllers.Inventory.InventorySetup.WarehouseLocations
{
    [Route("api/[controller]")]
    [ApiController]
    public class WarehouseLocationController : ControllerBase
    {
        private readonly IAccountsServicesManger _servicesManger;

        public WarehouseLocationController(IAccountsServicesManger servicesManger)
        {
            _servicesManger = servicesManger;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] WarehouseLocationCreateDto input)
        {
            var result = await _servicesManger.WarehouseLocationService.Create(input);

            if (result.Succeeded)
                return Ok(result.Result);

            return StatusCode(500, result.Errors);
        }

        [HttpPut]
        public async Task<IActionResult> Update(long id, [FromBody] WarehouseLocationUpdateDto input)
        {
            var result = await _servicesManger.WarehouseLocationService.Update(input, id);

            if (result.Succeeded)
                return Ok(result.Result);

            return StatusCode(500, result.Errors);
        }

        [HttpDelete("{id:long}")]
        public async Task<IActionResult> Delete(long id)
        {
            var result = await _servicesManger.WarehouseLocationService.Delete(id);

            if (result.Succeeded)
                return Ok(result.Result);

            return StatusCode(500, result.Errors);
        }

        [HttpPost("search")]
        public async Task<IActionResult> Search([FromBody] SqlQueryOptions sqlQueryOptions)
        {
            var result = await _servicesManger.WarehouseLocationService.Search(sqlQueryOptions);

            if (result.Succeeded)
                return Ok(result.Result);

            return StatusCode(500, result.Errors);
        }

        [HttpGet("{id:long}")]
        public async Task<IActionResult> GetById(long id)
        {
            var result = await _servicesManger.WarehouseLocationService.GetById(id);

            if (result.Succeeded)
                return Ok(result.Result);

            return StatusCode(500, result.Errors);
        }

        [HttpGet("code/{code}")]
        public async Task<IActionResult> GetByCode(string code)
        {
            var result = await _servicesManger.WarehouseLocationService.GetByCode(code);

            if (result.Succeeded)
                return Ok(result.Result);

            return StatusCode(500, result.Errors);
        }


        [HttpPost("Queries")]
        public async Task<IActionResult> Select(SqlQueryOptions sqlQueryOptions)
        {
            var getResult = await _servicesManger.WarehouseLocationService.Select(sqlQueryOptions);
            if (getResult.Succeeded)
            {
                return Ok(getResult.Result);
            }
            return StatusCode(500, getResult.Errors);
        }
    }
}
