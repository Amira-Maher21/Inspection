using Inspection.Application.Contracts.Dto.InspectionManagement.InspectionChecklistMoreInformationDetails;
using Inspection.Application.Contracts.Managers;
using Microsoft.AspNetCore.Mvc;
using NDS.Shared.API.ControllersBase;

namespace Inspection.API.Controllers.Controllers.InspectionManagement.EquipmentMoreInformationDetails
{


    [Route("api/InspectionChecklistMoreInformationDetail/[action]")]
    [ApiController]
    public class InspectionChecklistMoreInformationDetailController : InspectionControllerBase
    {
        private readonly IAccountsServicesManger _servicesManger;

        public InspectionChecklistMoreInformationDetailController(IAccountsServicesManger servicesManger)
        {
            _servicesManger = servicesManger;
        }



        [HttpGet("{EquipmentTypeId}")]
        public async Task<ActionResult<List<InspectionChecklistMoreInformationDetailsKeyValueDto>>> GetByEquipmentTypeId(long EquipmentTypeId)
        {
            var result = await _servicesManger.InspectionChecklistMoreInformationDetailService.GetByEquipmentTypeIdAsync(EquipmentTypeId);
            if (result.Succeeded)
                return Ok(result.Result);
            return StatusCode(500, result.Errors);
        }



    }
}

