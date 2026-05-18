using Inspection.Application.Contracts.Dto.SalesManagment.sales.JobOrderF;
using Inspection.Application.Contracts.Managers;
using Inspection.Domain.Enums;
using Inspection.Domain.Models.SalesManagment.Transaction.DTOs;
using Microsoft.AspNetCore.Mvc;
using NDS.Shared.Application.DataQuery;

namespace Inspection.API.Controllers.Controllers.SalesManagment.sales
{

    [Route("api/sales-JobOrder/[action]")]
    [ApiController]
    public class JobOrderController : ControllerBase
    {
        private readonly IAccountsServicesManger _servicesManger;
        public JobOrderController(IAccountsServicesManger servicesManger)
        {
            _servicesManger = servicesManger;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var result = await _servicesManger.JobOrderService.GetAsync(id);
            if (result.Succeeded)
                return Ok(result.Result);
            return StatusCode(500, result.Errors);
        }
        [HttpPost]
        public async Task<IActionResult> Index(SqlQueryOptions sqlQueryOptions)
        {
            var getResult = await _servicesManger.JobOrderService.GetListByIncludeAsync(sqlQueryOptions);
            if (getResult.Succeeded)
            {
                return Ok(getResult.Result);
            }
            return StatusCode(500, getResult.Errors);
        }

        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var result = await _servicesManger.JobOrderService.GetListAsync();
            if (result.Succeeded)
                return Ok(result.Result);
            return StatusCode(500, result.Errors);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateJobOrderDto input)
        {
            var result = await _servicesManger.JobOrderService.CreateAsync(input);
            if (result.Succeeded)
                return Ok(result.Result);
            return StatusCode(500, result.Errors);
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> Update(UpdateJobOrderDto input)
        {
            var result = await _servicesManger.JobOrderService.UpdateAsync(input);
            if (result.Succeeded)
                return Ok(result.Result);
            return StatusCode(500, result.Errors);
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var result = await _servicesManger.JobOrderService.DeleteAsync(id);
            if (result.Succeeded)
                return Ok();
            return StatusCode(500, result.Errors);
        }
        [HttpGet]
        public async Task<IActionResult> LookUpJobOrderForNames([FromQuery] SqlQueryOptions sqlQueryOptions)
        {
            var getResult = await _servicesManger.JobOrderService.GetLookUpJobOrderForNamesAsync(sqlQueryOptions);
            if (getResult.Succeeded)
            {
                return Ok(getResult.Result);
            }
            return StatusCode(500, getResult.Errors);
        }

        [HttpPatch()]
        public async Task<IActionResult> ChangeDocumentStatus(ChangeJobOrderDocumentStatusDto dto)
        {
            var result = await _servicesManger.JobOrderService.ChangeDocumentStatusAsync(dto);

            if (!result.Succeeded)
                return BadRequest(result);

            return Ok(result);
        }

    }
}
