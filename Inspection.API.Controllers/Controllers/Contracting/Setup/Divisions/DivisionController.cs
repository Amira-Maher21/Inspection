using Inspection.Application.Contracts.Dto.ContractingDTOs.Setup.Divisions;
using Inspection.Application.Contracts.Managers;
using Microsoft.AspNetCore.Mvc;
using NDS.Shared.API.ControllersBase;
using NDS.Shared.Application.DataQuery;

namespace Inspection.API.Controllers.Controllers.Contracting.Setup.Divisions
{
    [Route("api/Division/[action]")]
    [ApiController]
    public class DivisionController : InspectionControllerBase
    {
        private readonly IAccountsServicesManger _servicesManger;

        public DivisionController(IAccountsServicesManger servicesManger)
        {
            _servicesManger = servicesManger;
        }

        [HttpPost]
        public async Task<IActionResult> Create(DivisionCreateDto input)
        {
            var result = await _servicesManger.DivisionService.Create(input);
            if (result.Succeeded)
                return Ok(result.Result);

            return StatusCode(500, result.Errors);
        }

        [HttpPut]
        public async Task<IActionResult> Update(DivisionUpdateDto input)
        {
            var result = await _servicesManger.DivisionService.Update(input);
            if (result.Succeeded)
                return Ok(result.Result);

            return StatusCode(500, result.Errors);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var result = await _servicesManger.DivisionService.Delete(id);
            if (result.Succeeded)
                return Ok(result.Result);

            return StatusCode(500, result.Errors);
        }

        [HttpPost]
        public async Task<IActionResult> Search(SqlQueryOptions options)
        {
            var result = await _servicesManger.DivisionService.Search(options);
            if (result.Succeeded)
                return Ok(result.Result);

            return StatusCode(500, result.Errors);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var result = await _servicesManger.DivisionService.GetById(id);
            if (result.Succeeded)
                return Ok(result.Result);

            return StatusCode(500, result.Errors);
        }
    }
}