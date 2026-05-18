using Inspection.Application.Contracts.Dto.InspectionManagement.InspectionRequests;
using Inspection.Application.Contracts.Managers;
using Inspection.Domain.Models.InspectionManagement.InspectionRequests.Transaction.DTOs;
using Microsoft.AspNetCore.Mvc;
using NDS.Shared.API.ControllersBase;
using NDS.Shared.Application.DataQuery;

namespace Inspection.API.Controllers.Controllers.InspectionManagement.InspectionServiceOrders
{

    [Route("api/InspectionServiceOrder/[action]")]
    [ApiController]
    public class InspectionServiceOrderController : InspectionControllerBase
    {
        private readonly IAccountsServicesManger _servicesManger;

        public InspectionServiceOrderController(IAccountsServicesManger servicesManger)
        {
            _servicesManger = servicesManger;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateInspectionRequestDto insertDto)
        {
            var insertResult = await _servicesManger.InspectionServiceOrder.InsertInspectionRequestAsync(insertDto);
            if (insertResult.Succeeded)
            {
                return Ok(insertResult.Result);
            }
            return StatusCode(500, insertResult.Errors);
        }
        [HttpPost()]
        public async Task<IActionResult> Update(UpdateInspectionRequestDto updateDto)
        {
            var updateResult = await _servicesManger.InspectionServiceOrder.UpdateInspectionRequestAsync(updateDto);
            if (updateResult.Succeeded)
            {
                return Ok(updateResult.Result);
            }
            return StatusCode(500, updateResult.Errors);
        }
        [HttpPost("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var deleteResult = await _servicesManger.InspectionServiceOrder.DeleteInspectionRequestAsync(id);
            if (deleteResult.Succeeded)
            {
                return Ok(deleteResult.Result);
            }
            return StatusCode(500, deleteResult.Errors);
        }

        //[HttpGet]
        //public async Task<IActionResult> GetList()
        //{
        //    var list = await _servicesManger.InspectionServiceOrder.GetListAsync();
        //    return Ok(list);
        //}



        [HttpPost]
        public async Task<IActionResult> Index(SqlQueryOptions sqlQueryOptions)
        {
            var getResult = await _servicesManger.InspectionServiceOrder.GetInspectionRequestListByIncludeAsync(sqlQueryOptions);
            if (getResult.Succeeded)
            {
                return Ok(getResult.Result);
            }
            return StatusCode(500, getResult.Errors);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var getResult = await _servicesManger.InspectionServiceOrder.GetInspectionRequestByIdAsync(id);
            if (getResult.Succeeded)
            {
                return Ok(getResult.Result);
            }
            return StatusCode(500, getResult.Errors);
        }
        [HttpGet]
        public async Task<IActionResult> InpectionServiceOrderLookUpForNames([FromQuery] SqlQueryOptions sqlQueryOptions)
        {
            var getResult = await _servicesManger.InspectionServiceOrder.GetLookUpInspectionRequestForNamesAsync(sqlQueryOptions);
            if (getResult.Succeeded)
            {
                return Ok(getResult.Result);
            }
            return StatusCode(500, getResult.Errors);
        }
        [HttpGet]
        public async Task<IActionResult> InpectionServiceOrderDetailsOnly([FromQuery] long id)
        {
            var getResult = await _servicesManger.InspectionServiceOrder.GetRequestDetailsAsync(id);
            if (getResult.Succeeded)
            {
                return Ok(getResult.Result);
            }
            return StatusCode(500, getResult.Errors);
        }

        [HttpPatch()]
        public async Task<IActionResult> ChangeDocumentStatus(ChangeInspectionRequestDocumentStatusDto dto)
        {
            var result = await _servicesManger.InspectionServiceOrder.ChangeDocumentStatusAsync(dto);

            if (!result.Succeeded)
                return BadRequest(result);

            return Ok(result);
        }

    }
}

