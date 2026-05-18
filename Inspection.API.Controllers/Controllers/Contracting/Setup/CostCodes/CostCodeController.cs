using Inspection.Application.Contracts.Dto.ContractingDTOs.Setup.CostCodes;
using Inspection.Application.Contracts.Managers;
using Microsoft.AspNetCore.Mvc;
using NDS.Shared.API.ControllersBase;
using NDS.Shared.Application.DataQuery;

namespace Inspection.API.Controllers.Controllers.Contracting.Setup.CostCodes
{
    [Route("api/CostCode/[action]")]
    [ApiController]
    public class CostCodeController : InspectionControllerBase
    {
        private readonly IAccountsServicesManger _servicesManger;

        public CostCodeController(IAccountsServicesManger servicesManger)
        {
            _servicesManger = servicesManger;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CostCodeCreateDto input)
        {
            var result = await _servicesManger.CostCodeService.Create(input);
            if (result.Succeeded)
                return Ok(result.Result);

            return StatusCode(500, result.Errors);
        }

        [HttpPut]
        public async Task<IActionResult> Update(CostCodeUpdateDto input)
        {
            var result = await _servicesManger.CostCodeService.Update(input);
            if (result.Succeeded)
                return Ok(result.Result);

            return StatusCode(500, result.Errors);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var result = await _servicesManger.CostCodeService.Delete(id);
            if (result.Succeeded)
                return Ok(result.Result);

            return StatusCode(500, result.Errors);
        }

        [HttpPost]
        public async Task<IActionResult> Search(SqlQueryOptions options)
        {
            var result = await _servicesManger.CostCodeService.Search(options);
            if (result.Succeeded)
                return Ok(result.Result);

            return StatusCode(500, result.Errors);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var result = await _servicesManger.CostCodeService.GetById(id);
            if (result.Succeeded)
                return Ok(result.Result);

            return StatusCode(500, result.Errors);
        }
    }
}