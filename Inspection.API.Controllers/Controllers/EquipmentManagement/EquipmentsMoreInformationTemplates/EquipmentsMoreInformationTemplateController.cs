using Inspection.Application.Contracts.Dto.EquipmentManagement.EquipmentsMoreInformationTemplates;
using Inspection.Application.Contracts.Managers;
using Microsoft.AspNetCore.Mvc;
using NDS.Shared.Application.DataQuery;

namespace Inspection.API.Controllers.Controllers.EquipmentManagement.EquipmentsMoreInformationTemplateTemplates
{


    [Route("api/Equipments-EquipmentsMoreInformationTemplates/[action]")]
    [ApiController]
    public class EquipmentsMoreInformationTemplateController : ControllerBase
    {
        private readonly IAccountsServicesManger _servicesManger;
        public EquipmentsMoreInformationTemplateController(IAccountsServicesManger servicesManger)
        {
            _servicesManger = servicesManger;
        }
        //[HttpPost]
        //public async Task<IActionResult> Index(SqlQueryOptions sqlQueryOptions)
        //{
        //    var getResult = await _servicesManger.EquipmentsMoreInformationTemplateService.GetListByIncludeAsync(sqlQueryOptions);
        //    if (getResult.Succeeded)
        //    {
        //        return Ok(getResult.Result);
        //    }
        //    return StatusCode(500, getResult.Errors);
        //}
        //[HttpGet]
        //public async Task<ActionResult<List<InspectorCategoryLookupDefualtDto>>> InspectorCategoryLookupDefualt([FromQuery] SqlQueryOptions sqlQueryOptions)
        //{
        //    var result = await _servicesManger.EquipmentsMoreInformationTemplateService.EquipmentsMoreInformationTemplateLookupDefualt(sqlQueryOptions);
        //    if (result.Succeeded)
        //        return Ok(result.Result);
        //    return StatusCode(500, result.Errors);
        //}


        [HttpPost("Search")]
        public async Task<IActionResult> Search(SqlQueryOptions sqlQueryOptions)
        {
            var result = await _servicesManger.EquipmentsMoreInformationTemplateService.Search(sqlQueryOptions);

            if (!result.Succeeded)
                return StatusCode(500, result.Errors);

            return Ok(result.Result);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateEquipmentsMoreInformationTemplateDto input)
        {
            var result = await _servicesManger.EquipmentsMoreInformationTemplateService.CreateAsync(input);
            if (result.Succeeded)
                return Ok(result.Result);
            return StatusCode(500, result.Errors);
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> Update(long id, [FromBody] UpdateEquipmentsMoreInformationTemplateDto input)
        {
            if (id != input.Id)
                return BadRequest("ID mismatch");

            var result = await _servicesManger.EquipmentsMoreInformationTemplateService.UpdateAsync(id, input);
            if (result.Succeeded)
                return Ok(result.Result);
            return StatusCode(500, result.Errors);
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var result = await _servicesManger.EquipmentsMoreInformationTemplateService.DeleteAsync(id);
            if (result.Succeeded)
                return Ok();
            return StatusCode(500, result.Errors);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EquipmentsMoreInformationTemplateDto>> GetById(long id)
        {
            var result = await _servicesManger.EquipmentsMoreInformationTemplateService.GetAsync(id);
            if (result.Succeeded)
                return Ok(result.Result);
            return StatusCode(500, result.Errors);
        }


        [HttpGet]
        public async Task<ActionResult<List<EquipmentsMoreInformationTemplateDto>>> GetList()
        {
            var result = await _servicesManger.EquipmentsMoreInformationTemplateService.GetListAsync();
            if (result.Succeeded)
                return Ok(result.Result);
            return StatusCode(500, result.Errors);
        }
    }
}
