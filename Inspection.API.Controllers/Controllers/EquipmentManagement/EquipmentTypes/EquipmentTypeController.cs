using Inspection.Application.Contracts.Dto.EquipmentManagement.EquipmentTypes;
 using Inspection.Application.Contracts.Managers;
using Microsoft.AspNetCore.Mvc;
using NDS.Shared.API.ControllersBase;
using NDS.Shared.Application.DataQuery;


namespace Inspection.API.Controllers.Controllers.EquipmentManagement.EquipmentTypes
{
    [Route("api/EquipmentType/[action]")]
    [ApiController]
    public class EquipmentTypeController : InspectionControllerBase
    {
        private readonly IAccountsServicesManger _servicesManger;

        public EquipmentTypeController(IAccountsServicesManger servicesManger)
        {
            _servicesManger = servicesManger;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateEquipmentTypeDto insertDto)
        {
            var insertResult = await _servicesManger.EquipmentTypeService.InsertEquipmentTypeAsync(insertDto);
            if (insertResult.Succeeded)
            {
                return Ok(insertResult.Result);
            }
            return StatusCode(500, insertResult.Errors);
        }
        [HttpPost("{id}")]
        public async Task<IActionResult> Update(UpdateEquipmentTypeDto updateDto, long id)
        {
            var updateResult = await _servicesManger.EquipmentTypeService.UpdateEquipmentTypeAsync(updateDto, id);
            if (updateResult.Succeeded)
            {
                return Ok(updateResult.Result);
            }
            return StatusCode(500, updateResult.Errors);
        }
        [HttpPost("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var deleteResult = await _servicesManger.EquipmentTypeService.DeleteEquipmentTypeAsync(id);
            if (deleteResult.Succeeded)
            {
                return Ok(deleteResult.Result);
            }
            return StatusCode(500, deleteResult.Errors);
        }

        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var list = await _servicesManger.EquipmentTypeService.GetListAsync();
            return Ok(list);
        }


        [HttpPost]
        public async Task<IActionResult> Index(SqlQueryOptions sqlQueryOptions)
        {
            var getResult = await _servicesManger.EquipmentTypeService.GetEquipmentTypeListAsync(sqlQueryOptions);
            if (getResult.Succeeded)
            {
                return Ok(getResult.Result);
            }
            return StatusCode(500, getResult.Errors);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var getResult = await _servicesManger.EquipmentTypeService.GetEquipmentTypeByIdAsync(id);
            if (getResult.Succeeded)
            {
                return Ok(getResult.Result);
            }
            return StatusCode(500, getResult.Errors);
        }

        [HttpGet]
        public async Task<IActionResult> LookUpEquipmentTypeForNames([FromQuery] SqlQueryOptions sqlQueryOptions)
        {
            var getResult = await _servicesManger.EquipmentTypeService.GetLookUpEquipmentTypeForNamesAsync(sqlQueryOptions);
            if (getResult.Succeeded)
            {
                return Ok(getResult.Result);
            }
            return StatusCode(500, getResult.Errors);
        }

    }
}





