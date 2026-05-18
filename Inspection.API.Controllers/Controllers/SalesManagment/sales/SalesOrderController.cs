using Inspection.Application.Contracts.Dto.SalesManagment.sales.SalesOrder;
using Inspection.Application.Contracts.Managers;
using Inspection.Domain.Enums;
using Microsoft.AspNetCore.Mvc;
using NDS.Shared.Application.DataQuery;

namespace Inspection.API.Controllers.Controllers.SalesManagment.sales
{
    [Route("api/sales-SalesOrder/[action]")]
    [ApiController]
    public class SalesOrderController : ControllerBase
    {
        private readonly IAccountsServicesManger _servicesManger;
        public SalesOrderController(IAccountsServicesManger servicesManger)
        {
            _servicesManger = servicesManger;
        }
        [HttpPost]
        public async Task<IActionResult> Index(SqlQueryOptions sqlQueryOptions)
        {
            var getResult = await _servicesManger.SalesOrderService.GetListByIncludeAsync(sqlQueryOptions);
            if (getResult.Succeeded)
            {
                return Ok(getResult.Result);
            }
            return StatusCode(500, getResult.Errors);
        }
        [HttpGet]
        public async Task<ActionResult<List<SalesOrderLookupDefualtDto>>> SalesOrderLookupDefualt([FromQuery] SqlQueryOptions sqlQueryOptions)
        {
            var result = await _servicesManger.SalesOrderService.SalesOrderLookupDefualt(sqlQueryOptions);
            if (result.Succeeded)
                return Ok(result.Result);
            return StatusCode(500, result.Errors);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var result = await _servicesManger.SalesOrderService.GetAsync(id);
            if (result.Succeeded)
                return Ok(result.Result);
            return StatusCode(500, result.Errors);
        }

        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var result = await _servicesManger.SalesOrderService.GetListAsync();
            if (result.Succeeded)
                return Ok(result.Result);
            return StatusCode(500, result.Errors);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateSalesOrderDto input)
        {
            var result = await _servicesManger.SalesOrderService.CreateAsync(input);
            if (result.Succeeded)
                return Ok(result.Result);
            return StatusCode(500, result.Errors);
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> Update(long id, [FromBody] UpdateSalesOrderDto input)
        {
            var result = await _servicesManger.SalesOrderService.UpdateAsync(id, input);
            if (result.Succeeded)
                return Ok(result.Result);
            return StatusCode(500, result.Errors);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var result = await _servicesManger.SalesOrderService.DeleteAsync(id);
            if (result.Succeeded)
                return Ok();
            return StatusCode(500, result.Errors);
        }

        [HttpPatch()]
        public async Task<IActionResult> ChangeDocumentStatus(ChangeSalesOrderDocumentStatusDto dto)
        {
            var result = await _servicesManger.SalesOrderService.ChangeDocumentStatusAsync(dto);

            if (!result.Succeeded)
                return BadRequest(result);

            return Ok(result);
        }
    }
}
