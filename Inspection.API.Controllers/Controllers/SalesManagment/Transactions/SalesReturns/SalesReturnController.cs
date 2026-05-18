using Inspection.Application.Contracts.Dto.SalesManagment.sales.Transactions.SalesReturns;
using Inspection.Application.Contracts.Managers;
using Microsoft.AspNetCore.Mvc;
using NDS.Shared.API.ControllersBase;
using NDS.Shared.Application.DataQuery;

namespace Inspection.API.Controllers.Controllers.SalesManagment.Transactions.SalesReturns
{
    [Route("api/SalesReturn/[action]")]
    [ApiController]
    public class SalesReturnController : InspectionControllerBase
    {
        private readonly IAccountsServicesManger _servicesManger;

        public SalesReturnController(IAccountsServicesManger servicesManger)
        {
            _servicesManger = servicesManger;
        }

        // ================= CREATE =================
        [HttpPost]
        public async Task<IActionResult> Create(SalesReturnCreateDto input)
        {
            var result = await _servicesManger.SalesReturn.Create(input);

            if (result.Succeeded)
                return Ok(result.Result);

            return StatusCode(500, result.Errors);
        }

        // ================= UPDATE =================
        [HttpPut]
        public async Task<IActionResult> Update(SalesReturnUpdateDto input)
        {
            var result = await _servicesManger.SalesReturn.Update(input);

            if (result.Succeeded)
                return Ok(result.Result);

            return StatusCode(500, result.Errors);
        }

        // ================= DELETE =================
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var result = await _servicesManger.SalesReturn.Delete(id);

            if (result.Succeeded)
                return Ok(result.Result);

            return StatusCode(500, result.Errors);
        }

        // ================= SEARCH =================
        [HttpPost]
        public async Task<IActionResult> Search(SqlQueryOptions sqlQueryOptions)
        {
            var result = await _servicesManger.SalesReturn.Search(sqlQueryOptions);

            if (result.Succeeded)
                return Ok(result.Result);

            return StatusCode(500, result.Errors);
        }

        // ================= GET BY ID =================
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var result = await _servicesManger.SalesReturn.GetById(id);

            if (result.Succeeded)
                return Ok(result.Result);

            return StatusCode(500, result.Errors);
        }
    }
}