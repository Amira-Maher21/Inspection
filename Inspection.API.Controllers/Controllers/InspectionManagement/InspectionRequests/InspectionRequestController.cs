using Inspection.Application.Contracts.Dto.InspectionManagement.InspectionRequests;
using Inspection.Application.Contracts.Managers;
using Inspection.Domain.Enums;
using Microsoft.AspNetCore.Mvc;
using NDS.Shared.API.ControllersBase;
using NDS.Shared.Application.DataQuery;

namespace Inspection.API.Controllers.Controllers.InspectionManagement.InspectionRequests
{
    [Route("api/inspection-request/[action]")]
    [ApiController]
    public class InspectionRequestController : InspectionControllerBase
    {
        private readonly IAccountsServicesManger _servicesManger;

        public InspectionRequestController(IAccountsServicesManger servicesManger)
        {
            _servicesManger = servicesManger;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateInspectionRequestDto insertDto)
        {
            var insertResult = await _servicesManger.InspectionRequestService.InsertInspectionRequestAsync(insertDto);
            if (insertResult.Succeeded)
            {
                return Ok(insertResult.Result);
            }
            return StatusCode(500, insertResult.Errors);
        }
        [HttpPost("{id}")]
        public async Task<IActionResult> Update(UpdateInspectionRequestDto updateDto, long id)
        {
            var updateResult = await _servicesManger.InspectionRequestService.UpdateInspectionRequestAsync(updateDto, id);
            if (updateResult.Succeeded)
            {
                return Ok(updateResult.Result);
            }
            return StatusCode(500, updateResult.Errors);
        }
        [HttpPost("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var deleteResult = await _servicesManger.InspectionRequestService.DeleteInspectionRequestAsync(id);
            if (deleteResult.Succeeded)
            {
                return Ok(deleteResult.Result);
            }
            return StatusCode(500, deleteResult.Errors);
        }

        //[HttpGet]
        //public async Task<IActionResult> GetList()
        //{
        //    var list = await _servicesManger.InspectionRequestService.GetListAsync();
        //    return Ok(list);
        //}


       
        [HttpPost]
        public async Task<IActionResult> Index(SqlQueryOptions sqlQueryOptions)
        {
            var getResult = await _servicesManger.InspectionRequestService.GetInspectionRequestListByIncludeAsync(sqlQueryOptions);
            if (getResult.Succeeded)
            {
                return Ok(getResult.Result);
            }
            return StatusCode(500, getResult.Errors);
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById( long id)
        {
            var getResult = await _servicesManger.InspectionRequestService.GetInspectionRequestByIdAsync(id);
            if (getResult.Succeeded)
            {
                return Ok(getResult.Result);
            }
            return StatusCode(500, getResult.Errors);
        }
        [HttpPost("{id}")]
        public async Task<IActionResult> ChangeStatus( long id, [FromBody] ChangeInspectionApprovalStatus input)
        {
            var result = await _servicesManger.InspectionRequestService.ChangeStatus(id, input);
            if (result.Succeeded)
                return Ok(result.Result);
            return StatusCode(500, result.Errors);
        }

        [HttpGet]
        public async Task<IActionResult> GetRequestNumbersForDropdown()
        {
            var result = await _servicesManger.InspectionRequestService.GetRequestNumbersForDropdownAsync();
            if (result.Succeeded)
                return Ok(result.Result);
            return StatusCode(500, result.Errors);
        }

    }
}
