using Inspection.Application.Contracts.Dto.Inventory.InventorySetup.ItemDTOs.ItemVariantAttributeDTOs;
using Inspection.Application.Contracts.Managers;
using Microsoft.AspNetCore.Mvc;
using NDS.Shared.API.ControllersBase;

namespace Inspection.API.Controllers.Controllers.Inventory.InventorySetup.Items
{
    [Route("api/ItemVariantAttribute/[action]")]
    [ApiController]
    public class ItemVariantAttributeController : InspectionControllerBase
    {
        private readonly IAccountsServicesManger _servicesManger;

        public ItemVariantAttributeController(IAccountsServicesManger servicesManger)
        {
            _servicesManger = servicesManger;
        }
        [HttpPost]
        public async Task<IActionResult> Create(ItemVariantAttributeCreateDto input)
        {
            var insertResult = await _servicesManger.ItemService.CreateVariants(input);
            if (insertResult.Succeeded)
            {
                return Ok(insertResult.Result);
            }
            return StatusCode(500, insertResult.Errors);
        }

        [HttpGet("{itemId}")]
        public async Task<IActionResult> GetVariants(long itemId)
        {
            var getResult = await _servicesManger.ItemService.GetVariants(itemId);
            if (getResult.Succeeded)
            {
                return Ok(getResult.Result);
            }
            return StatusCode(500, getResult.Errors);
        }
    }
}