using Inspection.Application.Contracts.Dto.EquipmentManagement.EquipmentsMoreInformationDetails;
using Inspection.Application.Contracts.Managers;
using Microsoft.AspNetCore.Mvc;
using NDS.Shared.API.ControllersBase;

namespace Inspection.API.Controllers.Controllers.EquipmentManagement.EquipmentsMoreInformationDetails
{

    [Route("api/EquipmentsMoreInformationDetail/[action]")]
    [ApiController]
    public class EquipmentsMoreInformationDetailController : InspectionControllerBase
    {
        private readonly IAccountsServicesManger _servicesManger;

        public EquipmentsMoreInformationDetailController(IAccountsServicesManger servicesManger)
        {
            _servicesManger = servicesManger;
        }



        [HttpGet("{EquipmentTypeId}")]
        public async Task<ActionResult<List<EquipmentMoreInformationDetailsKeyValueDto>>> GetByEquipmentTypeId(long EquipmentTypeId)
        {
            var result = await _servicesManger.EquipmentsMoreInformationDetailService.GetByEquipmentTypeIdAsync(EquipmentTypeId);
            if (result.Succeeded)
                return Ok(result.Result);
            return StatusCode(500, result.Errors);
        }



    }
}

