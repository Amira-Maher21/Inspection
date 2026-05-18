using Inspection.Application.Contracts.Dto.AccountingDtos.AR.PurchaseReturns;
using Inspection.Application.Contracts.Managers;
using Microsoft.AspNetCore.Mvc;
using NDS.Shared.API.ControllersBase;
using NDS.Shared.Application.DataQuery;

namespace Inspection.API.Controllers.Controllers.Accounting.AR.PurchaseReturns
{
    [Route("api/PurchaseReturn/[action]")]
    [ApiController]
    public class PurchaseReturnController : InspectionControllerBase
    {
        private readonly IAccountsServicesManger _servicesManger;

        public PurchaseReturnController(IAccountsServicesManger servicesManger)
        {
            _servicesManger = servicesManger;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PurchaseReturnCreateDto dto)
        {
            var result = await _servicesManger.PurchaseReturn.Create(dto);

            if (!result.Succeeded)
                return BadRequest(result);

            return Ok(result);
        }


        [HttpPut]
        public async Task<IActionResult> Update([FromBody] PurchaseReturnUpdateDto dto)
        {
            var result = await _servicesManger.PurchaseReturn.Update(dto);

            if (!result.Succeeded)
                return BadRequest(result);

            return Ok(result);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var result = await _servicesManger.PurchaseReturn.Delete(id);

            if (!result.Succeeded)
                return NotFound(result);

            return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var result = await _servicesManger.PurchaseReturn.GetById(id);

            if (!result.Succeeded)
                return NotFound(result);

            return Ok(result);
        }


        [HttpPost]
        public async Task<IActionResult> Search([FromBody] SqlQueryOptions options)
        {
            var result = await _servicesManger.PurchaseReturn.Search(options);

            if (!result.Succeeded)
                return BadRequest(result);

            return Ok(result);
        }
    }
}