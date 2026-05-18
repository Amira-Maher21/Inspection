using Inspection.Application.Contracts.Dto.EquipmentManagement.CompanyEquipments;
 using Inspection.Application.Contracts.Managers;
using Microsoft.AspNetCore.Mvc;
using NDS.Shared.API.ControllersBase;
using NDS.Shared.Application.DataQuery;

namespace Inspection.API.Controllers.Controllers.EquipmentManagement.CompanyEquipments
{
 
    [Route("api/CompanyEquipment/[action]")]
    [ApiController]
    public class CompanyEquipmentController : InspectionControllerBase
    {
        private readonly IAccountsServicesManger _servicesManger;

        public CompanyEquipmentController(IAccountsServicesManger servicesManger)
        {
            _servicesManger = servicesManger;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCompanyEquipmentDto insertDto)
        {
            var insertResult = await _servicesManger.CompanyEquipmentService.InsertCompanyEquipmentAsync(insertDto);
            if (insertResult.Succeeded)
            {
                return Ok(insertResult.Result);
            }
            return StatusCode(500, insertResult.Errors);
        }
        [HttpPost("{id}")]
        public async Task<IActionResult> Update(UpdateCompanyEquipmentDto updateDto, long id)
        {
            var updateResult = await _servicesManger.CompanyEquipmentService.UpdateCompanyEquipmentAsync(updateDto, id);
            if (updateResult.Succeeded)
            {
                return Ok(updateResult.Result);
            }
            return StatusCode(500, updateResult.Errors);
        }
        [HttpPost("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var deleteResult = await _servicesManger.CompanyEquipmentService.DeleteCompanyEquipmentAsync(id);
            if (deleteResult.Succeeded)
            {
                return Ok(deleteResult.Result);
            }
            return StatusCode(500, deleteResult.Errors);
        }

        //[HttpGet]
        //public async Task<IActionResult> GetList()
        //{
        //   var list = await _servicesManger.CompanyEquipmentService.GetListAsync();
        //    return Ok(list);
        //}


        [HttpPost]
        public async Task<IActionResult> Index(SqlQueryOptions sqlQueryOptions)
        {
            var getResult = await _servicesManger.CompanyEquipmentService.GetCompanyEquipmentListAsync(sqlQueryOptions);
            if (getResult.Succeeded)
            {
                return Ok(getResult.Result);
            }
            return StatusCode(500, getResult.Errors);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var getResult = await _servicesManger.CompanyEquipmentService.GetCompanyEquipmentByIdAsync(id);
            if (getResult.Succeeded)
            {
                return Ok(getResult.Result);
            }
            return StatusCode(500, getResult.Errors);
        }

        //[HttpGet]
        //public async Task<IActionResult> LookUpCompanyEquipmentForNames([FromQuery] SqlQueryOptions sqlQueryOptions)
        //{
        //    var getResult = await _servicesManger.CompanyEquipmentService.GetLookUpCompanyEquipmentForNamesAsync(sqlQueryOptions);
        //    if (getResult.Succeeded)
        //    {
        //        return Ok(getResult.Result);
        //    }
        //    return StatusCode(500, getResult.Errors);
        //}

    }
}
