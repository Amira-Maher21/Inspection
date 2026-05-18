using Inspection.Application.Contracts.Dto.EquipmentManagement.EquipmentInspections;
using Inspection.Application.Contracts.Managers;
using Microsoft.AspNetCore.Mvc;
using NDS.Shared.API.ControllersBase;

namespace Inspection.API.Controllers.Controllers.EquipmentManagement.EquipmentInspections
{
    [ApiController]
    [Route("api/inspection-equipment-inspections/[action]")]
    public class EquipmentInspectionController : InspectionControllerBase
    {
        private readonly IAccountsServicesManger _servicesManger;

        public EquipmentInspectionController(IAccountsServicesManger servicesManger)
        {
            _servicesManger = servicesManger;
        }

        //[HttpGet("{equipmentId}")]
        //public async Task<IActionResult> GetByEquipmentId(long equipmentId)
        //{
        //    var result = await _servicesManger.EquipmentInspectionService.GetListByEquipmentIdAsync(equipmentId);
        //    return Ok(result);
        //}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var result = await _servicesManger.EquipmentInspectionService.GetById(id);

            if (!result.Succeeded)
                return StatusCode(500, result.Errors);

            return Ok(result.Result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateEquipmentInspectionDto input)
        {
            var result = await _servicesManger.EquipmentInspectionService.CreateAsync(input);
            return Ok(result);
        }
    }

}
