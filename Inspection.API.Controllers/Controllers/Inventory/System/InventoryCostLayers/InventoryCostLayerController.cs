using Inspection.Application.Contracts.Dto.Inventory.System.InventoryCostLayers;
using Inspection.Application.Contracts.Managers;
using Microsoft.AspNetCore.Mvc;
using NDS.Shared.Application.DataQuery;

namespace Inspection.API.Controllers.Controllers.Inventory.System.InventoryCostLayers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryCostLayerController : ControllerBase
    {
        private readonly IAccountsServicesManger _servicesManger;

        public InventoryCostLayerController(IAccountsServicesManger servicesManger)
        {
            _servicesManger = servicesManger;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] InventoryCostLayerCreateDto input)
        {
            var result = await _servicesManger.InventoryCostLayersService.Create(input);

            if (result.Succeeded)
                return Ok(result.Result);

            return StatusCode(500, result.Errors);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] InventoryCostLayerUpdateDto input)
        {
            var result = await _servicesManger.InventoryCostLayersService.Update(input);

            if (result.Succeeded)
                return Ok(result.Result);

            if (result.Errors.Any(e => e.ErrorCode == "404"))
                return NotFound(result.Errors);

            return BadRequest(result.Errors);
        }

        [HttpDelete("{id:long}")]
        public async Task<IActionResult> Delete(long id)
        {
            var result = await _servicesManger.InventoryCostLayersService.Delete(id);

            if (result.Succeeded)
                return Ok(result.Result);

            if (result.Errors.Any(e => e.ErrorCode == "404"))
                return NotFound(result.Errors);

            return StatusCode(500, result.Errors);
        }

        [HttpPost("search")]
        public async Task<IActionResult> Search([FromBody] SqlQueryOptions sqlQueryOptions)
        {
            var result = await _servicesManger.InventoryCostLayersService.Search(sqlQueryOptions);

            if (result.Succeeded)
                return Ok(result.Result);

            return StatusCode(500, result.Errors);
        }

        [HttpGet("{id:long}")]
        public async Task<IActionResult> GetById(long id)
        {
            var result = await _servicesManger.InventoryCostLayersService.GetById(id);

            if (result.Succeeded)
                return Ok(result.Result);

            if (result.Errors.Any(e => e.ErrorCode == "404"))
                return NotFound(result.Errors);

            return StatusCode(500, result.Errors);
        }


    }
}
