using Inspection.Application.Contracts.Dto.EquipmentManagement.EquipmentsMoreInformationTemplateDetails;
using Inspection.Application.Contracts.Managers;
using Microsoft.AspNetCore.Mvc;
using NDS.Shared.API.ControllersBase;

namespace Inspection.API.Controllers.Controllers.EquipmentManagement.EquipmentsMoreInformationTemplateDetails
{

    /////////////////////////


    [Route("api/EquipmentsMoreInformationTemplateDetail/[action]")]
    [ApiController]
    public class EquipmentsMoreInformationTemplateDetailController : InspectionControllerBase
    {
        private readonly IAccountsServicesManger _servicesManger;

        public EquipmentsMoreInformationTemplateDetailController(IAccountsServicesManger servicesManger)
        {
            _servicesManger = servicesManger;
        }

        //[HttpPost]
        //public async Task<IActionResult> Create(CreateEquipmentsMoreInformationTemplateDetailDto insertDto)
        //{
        //    var insertResult = await _servicesManger.EquipmentsMoreInformationTemplateDetailService.InsertEquipmentsMoreInformationTemplateDetailAsync(insertDto);
        //    if (insertResult.Succeeded)
        //    {
        //        return Ok(insertResult.Result);
        //    }
        //    return StatusCode(500, insertResult.Errors);
        //}

        //[HttpPost("{id}")]
        //public async Task<IActionResult> Update(UpdateEquipmentsMoreInformationTemplateDetailDto updateDto, long id)
        //{
        //    var updateResult = await _servicesManger.EquipmentsMoreInformationTemplateDetailService.UpdateEquipmentsMoreInformationTemplateDetailAsync(updateDto, id);
        //    if (updateResult.Succeeded)
        //    {
        //        return Ok(updateResult.Result);
        //    }
        //    return StatusCode(500, updateResult.Errors);
        //}

        //[HttpPost("{id}")]
        //public async Task<IActionResult> Delete(long id)
        //{
        //    var deleteResult = await _servicesManger.EquipmentsMoreInformationTemplateDetailService.DeleteEquipmentsMoreInformationTemplateDetailAsync(id);
        //    if (deleteResult.Succeeded)
        //    {
        //        return Ok(deleteResult.Result);
        //    }
        //    return StatusCode(500, deleteResult.Errors);
        //}


        //[HttpGet]
        //public async Task<IActionResult> GetList()
        //{
        //    var list = await _servicesManger.EquipmentsMoreInformationTemplateDetailService.GetListAsync();
        //    return Ok(list);
        //}


        //[HttpPost]
        //public async Task<IActionResult> Index(SqlQueryOptions sqlQueryOptions)
        //{
        //    var getResult = await _servicesManger.EquipmentsMoreInformationTemplateDetailService.GetEquipmentsMoreInformationTemplateDetailListAsync(sqlQueryOptions);
        //    if (getResult.Succeeded)
        //    {
        //        return Ok(getResult.Result);
        //    }
        //    return StatusCode(500, getResult.Errors);
        //}

        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetById(long id)
        //{
        //    var getResult = await _servicesManger.EquipmentsMoreInformationTemplateDetailService.GetEquipmentsMoreInformationTemplateDetailByIdAsync(id);
        //    if (getResult.Succeeded)
        //    {
        //        return Ok(getResult.Result);
        //    }
        //    return StatusCode(500, getResult.Errors);
        //}

        [HttpGet("{EquipmentTypeId}")]
        public async Task<ActionResult<List<EquipmentMoreInformationTemplateDetailsKeyValueDto>>> GetByEquipmentTypeId(long EquipmentTypeId)
        {
            var result = await _servicesManger.EquipmentsMoreInformationTemplateDetailService.GetByEquipmentTypeIdAsync(EquipmentTypeId);
            if (result.Succeeded)
                return Ok(result.Result);
            return StatusCode(500, result.Errors);
        }



        //[HttpGet]
        //public async Task<IActionResult> LookUpEquipmentsMoreInformationTemplateDetailForNames([FromQuery] SqlQueryOptions sqlQueryOptions)
        //{
        //    var getResult = await _servicesManger.EquipmentsMoreInformationTemplateDetailService.GetLookUpEquipmentsMoreInformationTemplateDetailForNamesAsync(sqlQueryOptions);
        //    if (getResult.Succeeded)
        //    {
        //        return Ok(getResult.Result);
        //    }
        //    return StatusCode(500, getResult.Errors);
        //}

    }
}

