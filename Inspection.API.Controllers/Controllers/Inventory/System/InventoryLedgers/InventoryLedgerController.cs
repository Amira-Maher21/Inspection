using Inspection.Application.Contracts.Dto.Inventory.System.InventoryLedgers;
using Inspection.Application.Contracts.Managers;
using Microsoft.AspNetCore.Mvc;
using NDS.Shared.Application.DataQuery;

namespace Inspection.API.Controllers.Controllers.Inventory.System.InventoryLedgers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class InventoryLedgerController : ControllerBase
    {
        private readonly IAccountsServicesManger _servicesManger;

        public InventoryLedgerController(IAccountsServicesManger servicesManger)
        {
            _servicesManger = servicesManger;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] InventoryLedgerCreateDto input)
        {
            var result = await _servicesManger.InventoryLedgerService.Create(input);

            if (result.Succeeded)
                return Ok(result.Result);

            return StatusCode(500, result.Errors);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] InventoryLedgerUpdateDto input)
        {
            var result = await _servicesManger.InventoryLedgerService.Update(input);

            if (result.Succeeded)
                return Ok(result.Result);

            if (result.Errors.Any(e => e.ErrorCode == "404"))
                return NotFound(result.Errors);

            return BadRequest(result.Errors);
        }

        [HttpDelete("{id:long}")]
        public async Task<IActionResult> Delete(long id)
        {
            var result = await _servicesManger.InventoryLedgerService.Delete(id);

            if (result.Succeeded)
                return Ok(result.Result);

            if (result.Errors.Any(e => e.ErrorCode == "404"))
                return NotFound(result.Errors);

            return StatusCode(500, result.Errors);
        }

        [HttpPost]
        public async Task<IActionResult> Search([FromBody] SqlQueryOptions sqlQueryOptions)
        {
            var result = await _servicesManger.InventoryLedgerService.Search(sqlQueryOptions);

            if (result.Succeeded)
                return Ok(result.Result);

            return StatusCode(500, result.Errors);
        }

        [HttpGet("{id:long}")]
        public async Task<IActionResult> GetById(long id)
        {
            var result = await _servicesManger.InventoryLedgerService.GetById(id);

            if (result.Succeeded)
                return Ok(result.Result);

            if (result.Errors.Any(e => e.ErrorCode == "404"))
                return NotFound(result.Errors);

            return StatusCode(500, result.Errors);
        }

        [HttpPost]
        public async Task<IActionResult> ViewEntry([FromBody] SqlQueryOptions sqlQueryOptions)
        {
            var result = await _servicesManger.LedgerService
                .ViewEntry(sqlQueryOptions);

            return Ok(result.Result);
        }
    }
}
