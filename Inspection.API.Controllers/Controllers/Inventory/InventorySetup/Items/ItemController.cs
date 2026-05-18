using Inspection.Application.Contracts.Dto.Inventory.InventorySetup.ItemDTOs;
using Inspection.Application.Contracts.Managers;
using Inspection.Domain.Enums.InventoryEnums.Items;
using Microsoft.AspNetCore.Mvc;
using NDS.Shared.API.ControllersBase;
using NDS.Shared.Application.DataQuery;

namespace Inspection.API.Controllers.Controllers.Inventory.InventorySetup.Items
{
    [Route("api/Item/[action]")]
    [ApiController]
    public class ItemController : InspectionControllerBase
    {
        private readonly IAccountsServicesManger _servicesManger;

        public ItemController(IAccountsServicesManger servicesManger)
        {
            _servicesManger = servicesManger;
        }

        [HttpPost]
        public async Task<IActionResult> Create(ItemCreateDto input)
        {
            var insertResult = await _servicesManger.ItemService.Create(input);
            if (insertResult.Succeeded)
            {
                return Ok(insertResult.Result);
            }
            return StatusCode(500, insertResult.Errors);
        }

        [HttpPut]
        public async Task<IActionResult> Update(ItemUpdateDto input)
        {
            var updateResult = await _servicesManger.ItemService.Update(input);
            if (updateResult.Succeeded)
            {
                return Ok(updateResult.Result);
            }
            return StatusCode(500, updateResult.Errors);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var deleteResult = await _servicesManger.ItemService.Delete(id);
            if (deleteResult.Succeeded)
            {
                return Ok(deleteResult.Result);
            }
            return StatusCode(500, deleteResult.Errors);
        }

        [HttpPost]
        public async Task<IActionResult> Search(SqlQueryOptions sqlQueryOptions)
        {
            var getResult = await _servicesManger.ItemService.Search(sqlQueryOptions);
            if (getResult.Succeeded)
            {
                return Ok(getResult.Result);
            }
            return StatusCode(500, getResult.Errors);
        }
        [HttpPost]
        public async Task<IActionResult> FilteredItems(SqlQueryOptions sqlQueryOptions)
        {
            var getResult = await _servicesManger.ItemService.FilteredSearch(sqlQueryOptions);
            if (getResult.Succeeded)
            {
                return Ok(getResult.Result);
            }
            return StatusCode(500, getResult.Errors);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var getResult = await _servicesManger.ItemService.GetById(id);
            if (getResult.Succeeded)
            {
                return Ok(getResult.Result);
            }
            return StatusCode(500, getResult.Errors);
        }

        [HttpGet("{itemId}")]
        [ProducesResponseType(typeof(ItemForecastResultDto), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetItemForecastReorderQuantity(long itemId, [FromQuery] ItemForecastPeriod period)
        {
            var result = await _servicesManger.ItemService.GetItemForecastReorderQuantity(itemId, period);

            if (result.Succeeded)
                return Ok(result.Result);

            if (result.Errors.Any(e => e.ErrorCode == "404"))
                return NotFound(result.Errors);

            return StatusCode(500, result.Errors);
        }
    }
}