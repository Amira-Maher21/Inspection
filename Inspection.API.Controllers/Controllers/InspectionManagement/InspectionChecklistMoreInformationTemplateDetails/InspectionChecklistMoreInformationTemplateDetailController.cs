using Inspection.Application.Contracts.Dto.InspectionManagement.InspectionChecklistMoreInformationTemplateDetails;
using Inspection.Application.Contracts.Managers;
using Microsoft.AspNetCore.Mvc;
using NDS.Shared.API.ControllersBase;

namespace Inspection.API.Controllers.Controllers.InspectionManagement.EquipmentMoreInformationTemplateDetails
{


    [Route("api/InspectionChecklistMoreInformationTemplateDetail/[action]")]
    [ApiController]
    public class InspectionChecklistMoreInformationTemplateDetailController : InspectionControllerBase
    {
        private readonly IAccountsServicesManger _servicesManger;

        public InspectionChecklistMoreInformationTemplateDetailController(IAccountsServicesManger servicesManger)
        {
            _servicesManger = servicesManger;
        }



        [HttpGet("{EquipmentTypeId}")]
        public async Task<ActionResult<List<InspectionChecklistMoreInformationTemplateDetailKeyValueDto>>> GetByEquipmentTypeId(long EquipmentTypeId)
        {
            var result = await _servicesManger.InspectionChecklistMoreInformationTemplateDetailService.GetByEquipmentTypeIdAsync(EquipmentTypeId);
            if (result.Succeeded)
                return Ok(result.Result);
            return StatusCode(500, result.Errors);
        }



    }
}

