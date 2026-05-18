using Inspection.Application.Contracts.Dto.Inventory.Transaction.ScrapReasons;
using Inspection.Application.Contracts.Managers;
using Microsoft.AspNetCore.Mvc;
using NDS.Shared.API.ControllersBase;
using NDS.Shared.Application.DataQuery;

namespace Inspection.API.Controllers.Controllers.Inventory.Transaction.ScrapReasons
{
    [Route("api/ScrapReason/[action]")]
    [ApiController]
    public class ScrapReasonController : InspectionControllerBase
    {
        private readonly IAccountsServicesManger _servicesManger;

        public ScrapReasonController(IAccountsServicesManger servicesManger)
        {
            _servicesManger = servicesManger;
        }

        // ================= CREATE =================
        [HttpPost]
        public async Task<IActionResult> Create(ScrapReasonCreateDto input)
        {
            var result = await _servicesManger.ScrapReasonService.Create(input);

            if (result.Succeeded)
                return Ok(result.Result);

            return StatusCode(500, result.Errors);
        }

        // ================= UPDATE =================
        [HttpPut]
        public async Task<IActionResult> Update(ScrapReasonUpdateDto input)
        {
            var result = await _servicesManger.ScrapReasonService.Update(input);

            if (result.Succeeded)
                return Ok(result.Result);

            return StatusCode(500, result.Errors);
        }

        // ================= DELETE =================
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var result = await _servicesManger.ScrapReasonService.Delete(id);

            if (result.Succeeded)
                return Ok(result.Result);

            return StatusCode(500, result.Errors);
        }

        // ================= SEARCH =================
        [HttpPost]
        public async Task<IActionResult> Search(SqlQueryOptions sqlQueryOptions)
        {
            var result = await _servicesManger.ScrapReasonService.Search(sqlQueryOptions);

            if (result.Succeeded)
                return Ok(result.Result);

            return StatusCode(500, result.Errors);
        }

        // ================= GET BY ID =================
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var result = await _servicesManger.ScrapReasonService.GetById(id);

            if (result.Succeeded)
                return Ok(result.Result);

            return StatusCode(500, result.Errors);
        }
    }
}