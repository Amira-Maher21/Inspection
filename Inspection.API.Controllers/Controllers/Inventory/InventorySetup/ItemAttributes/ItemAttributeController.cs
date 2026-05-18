using Inspection.Application.Contracts.Dto.Inventory.InventorySetup.ItemAttributeDTOs;
using Inspection.Application.Contracts.Managers;
using Microsoft.AspNetCore.Mvc;
using NDS.Shared.API.ControllersBase;
using NDS.Shared.Application.DataQuery;

namespace Inspection.API.Controllers.Controllers.Inventory.InventorySetup.ItemAttributes
{
    [Route("api/ItemAttribute/[action]")]
    [ApiController]
    public class ItemAttributeController : InspectionControllerBase
    {
        private readonly IAccountsServicesManger _servicesManger;

        public ItemAttributeController(IAccountsServicesManger servicesManger)
        {
            _servicesManger = servicesManger;
        }

        [HttpPost]
        public async Task<IActionResult> Create(ItemAttributeCreateDto input)
        {
            var insertResult = await _servicesManger.ItemAttributeService.Create(input);
            if (insertResult.Succeeded)
            {
                return Ok(insertResult.Result);
            }
            return StatusCode(500, insertResult.Errors);
        }

        [HttpPut]
        public async Task<IActionResult> Update(ItemAttributeUpdateDto input)
        {
            var updateResult = await _servicesManger.ItemAttributeService.Update(input);
            if (updateResult.Succeeded)
            {
                return Ok(updateResult.Result);
            }
            return StatusCode(500, updateResult.Errors);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var deleteResult = await _servicesManger.ItemAttributeService.Delete(id);
            if (deleteResult.Succeeded)
            {
                return Ok(deleteResult.Result);
            }
            return StatusCode(500, deleteResult.Errors);
        }

        [HttpPost]
        public async Task<IActionResult> Search(SqlQueryOptions sqlQueryOptions)
        {
            var getResult = await _servicesManger.ItemAttributeService.Search(sqlQueryOptions);
            if (getResult.Succeeded)
            {
                return Ok(getResult.Result);
            }
            return StatusCode(500, getResult.Errors);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var getResult = await _servicesManger.ItemAttributeService.GetById(id);
            if (getResult.Succeeded)
            {
                return Ok(getResult.Result);
            }
            return StatusCode(500, getResult.Errors);
        }
    }
}