using Inspection.Application.Contracts.Dto.EquipmentManagement.Equipments;
using Inspection.Application.Contracts.Managers;
using Microsoft.AspNetCore.Mvc;
using NDS.Shared.API.ControllersBase;
using NDS.Shared.Application.DataQuery;

namespace Inspection.API.Controllers.Controllers.EquipmentManagement.Equipments
{
    [ApiController]
    [Route("api/Equipment/[action]")]
    public class EquipmentController : InspectionControllerBase
    {
        private readonly IAccountsServicesManger _servicesManger;
        public EquipmentController(IAccountsServicesManger servicesManger)
        {
            _servicesManger = servicesManger;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var result = await _servicesManger.EquipmentService.GetById(id);
            if (result.Succeeded)
                return Ok(result.Result);
            return StatusCode(500, result.Errors);
        }
        [HttpGet("Checklist/{id}")]
        public async Task<IActionResult> GetChecklistTamplete(long id)
        {
            var result = await _servicesManger.EquipmentService.GetChecklistTampleteAsync(id);
            if (result.Succeeded)
                return Ok(result.Result);
            return StatusCode(500, result.Errors);
        }

        [HttpPost]
        public async Task<IActionResult> Search(SqlQueryOptions sqlQueryOptions)
        {
            var getResult = await _servicesManger.EquipmentService.Search(sqlQueryOptions);
            if (getResult.Succeeded)
            {
                return Ok(getResult.Result);
            }
            return StatusCode(500, getResult.Errors);
        }



        [HttpGet("Full/{id}")]
        public async Task<IActionResult> GetFullById(long id)
        {
            var result = await _servicesManger.EquipmentService.GetEquipmentByIdAsync(id);

            if (!result.Succeeded)
            {
                if (result.Errors.Any(e => e.ErrorCode == "404"))
                    return NotFound(result.Errors);

                return StatusCode(StatusCodes.Status500InternalServerError, result.Errors);
            }

            return Ok(result.Result);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateEquipmentDto input)
        {
            var result = await _servicesManger.EquipmentService.Create(input);
            if (result.Succeeded)
                return Ok(result.Result);
            return StatusCode(500, result.Errors);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateEquipmentDto input)
        {
            var updateResult = await _servicesManger.EquipmentService.Update(input);
            if (updateResult.Succeeded)
            {
                return Ok(updateResult.Result);
            }
            return StatusCode(500, updateResult.Errors);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var result = await _servicesManger.EquipmentService.Delete(id);

            if (result.Succeeded)
                return Ok(result.Result);

            if (result.Errors.Any(e => e.ErrorCode == "404"))
                return NotFound(result.Errors);

            return StatusCode(500, result.Errors);
        }


    }
}

