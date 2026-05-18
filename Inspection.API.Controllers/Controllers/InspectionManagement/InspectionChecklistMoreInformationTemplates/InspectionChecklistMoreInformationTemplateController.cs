using Inspection.Application.Contracts.Dto.InspectionManagement.InspectionChecklistMoreInformationTemplates;
using Inspection.Application.Contracts.Managers;
using Microsoft.AspNetCore.Mvc;
using NDS.Shared.Application.DataQuery;

namespace Inspection.API.Controllers.Controllers.InspectionManagement.EquipmentMoreInformationTemplates
{


    [Route("api/InspectionChecklistMoreInformationTemplates/[action]")]
    [ApiController]
    public class InspectionChecklistMoreInformationTemplateController : ControllerBase
    {
        private readonly IAccountsServicesManger _servicesManger;
        public InspectionChecklistMoreInformationTemplateController(IAccountsServicesManger servicesManger)
        {
            _servicesManger = servicesManger;
        }
        [HttpPost]
        public async Task<IActionResult> Index(SqlQueryOptions sqlQueryOptions)
        {
            var getResult = await _servicesManger.InspectionChecklistMoreInformationTemplateService.GetListByIncludeAsync(sqlQueryOptions);
            if (getResult.Succeeded)
            {
                return Ok(getResult.Result);
            }
            return StatusCode(500, getResult.Errors);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateInspectionChecklistMoreInformationTemplateDto input)
        {
            var result = await _servicesManger.InspectionChecklistMoreInformationTemplateService.CreateAsync(input);
            if (result.Succeeded)
                return Ok(result.Result);
            return StatusCode(500, result.Errors);
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> Update(long id, [FromBody] UpdateInspectionChecklistMoreInformationTemplateDto input)
        {
            if (id != input.Id)
                return BadRequest("ID mismatch");

            var result = await _servicesManger.InspectionChecklistMoreInformationTemplateService.UpdateAsync(id, input);
            if (result.Succeeded)
                return Ok(result.Result);
            return StatusCode(500, result.Errors);
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var result = await _servicesManger.InspectionChecklistMoreInformationTemplateService.DeleteAsync(id);
            if (result.Succeeded)
                return Ok();
            return StatusCode(500, result.Errors);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<InspectionChecklistMoreInformationTemplateDto>> GetById(long id)
        {
            var result = await _servicesManger.InspectionChecklistMoreInformationTemplateService.GetAsync(id);
            if (result.Succeeded)
                return Ok(result.Result);
            return StatusCode(500, result.Errors);
        }


        [HttpGet]
        public async Task<ActionResult<List<InspectionChecklistMoreInformationTemplateDto>>> GetList()
        {
            var result = await _servicesManger.InspectionChecklistMoreInformationTemplateService.GetListAsync();
            if (result.Succeeded)
                return Ok(result.Result);
            return StatusCode(500, result.Errors);
        }
    }
}
