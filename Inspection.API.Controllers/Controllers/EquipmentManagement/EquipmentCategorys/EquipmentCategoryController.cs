using Inspection.Application.Contracts.Dto.EquipmentManagement.EquipmentCategorys;
 using Inspection.Application.Contracts.Managers;
using Microsoft.AspNetCore.Mvc;
using NDS.Shared.API.ControllersBase;
using NDS.Shared.Application.DataQuery;


namespace Inspection.API.Controllers.Controllers.EquipmentManagement.EquipmentCategorys
{
    [Route("api/EquipmentCategory/[action]")]
    [ApiController]
    public class EquipmentCategoryController : InspectionControllerBase
    {
        private readonly IAccountsServicesManger _servicesManger;

        public EquipmentCategoryController(IAccountsServicesManger servicesManger)
        {
            _servicesManger = servicesManger;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateEquipmentCategoryDto insertDto)
        {
            var insertResult = await _servicesManger.EquipmentCategoryService.InsertEquipmentCategoryAsync(insertDto);
            if (insertResult.Succeeded)
            {
                return Ok(insertResult.Result);
            }
            return StatusCode(500, insertResult.Errors);
        }
        [HttpPost("{id}")]
        public async Task<IActionResult> Update(UpdateEquipmentCategoryDto updateDto, long id)
        {
            var updateResult = await _servicesManger.EquipmentCategoryService.UpdateEquipmentCategoryAsync(updateDto, id);
            if (updateResult.Succeeded)
            {
                return Ok(updateResult.Result);
            }
            return StatusCode(500, updateResult.Errors);
        }
        [HttpPost("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var deleteResult = await _servicesManger.EquipmentCategoryService.DeleteEquipmentCategoryAsync(id);
            if (deleteResult.Succeeded)
            {
                return Ok(deleteResult.Result);
            }
            return StatusCode(500, deleteResult.Errors);
        }

        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var list = await _servicesManger.EquipmentCategoryService.GetListAsync();
            return Ok(list);
        }


        [HttpPost]
        public async Task<IActionResult> Index(SqlQueryOptions sqlQueryOptions)
        {
            var getResult = await _servicesManger.EquipmentCategoryService.GetEquipmentCategoryListAsync(sqlQueryOptions);
            if (getResult.Succeeded)
            {
                return Ok(getResult.Result);
            }
            return StatusCode(500, getResult.Errors);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var getResult = await _servicesManger.EquipmentCategoryService.GetEquipmentCategoryByIdAsync(id);
            if (getResult.Succeeded)
            {
                return Ok(getResult.Result);
            }
            return StatusCode(500, getResult.Errors);
        }

        [HttpGet]
        public async Task<IActionResult> LookUpEquipmentCategoryForNames([FromQuery] SqlQueryOptions sqlQueryOptions)
        {
            var getResult = await _servicesManger.EquipmentCategoryService.GetLookUpEquipmentCategoryForNamesAsync(sqlQueryOptions);
            if (getResult.Succeeded)
            {
                return Ok(getResult.Result);
            }
            return StatusCode(500, getResult.Errors);
        }

    }
}





