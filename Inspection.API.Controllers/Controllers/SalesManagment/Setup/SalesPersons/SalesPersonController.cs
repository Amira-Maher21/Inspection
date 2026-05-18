using Inspection.Application.Contracts.Dto.SalesManagment.Setup.SalesPerson;
using Inspection.Application.Contracts.Managers;
using Microsoft.AspNetCore.Mvc;
using NDS.Shared.API.ControllersBase;
using NDS.Shared.Application.DataQuery;

namespace Inspection.API.Controllers.Controllers.SalesManagment.Setup.SalesPersons
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesPersonController : InspectionControllerBase
    {
        private readonly IAccountsServicesManger _servicesManger;

        public SalesPersonController(IAccountsServicesManger servicesManger)
        {
            _servicesManger = servicesManger;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] SalesPersonCreateDto dto)
        {
            var result = await _servicesManger.SalesPerson.Create(dto);

            if (!result.Succeeded)
                return StatusCode(500, result.Errors);

            return Ok(result.Result);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] SalesPersonUpdateDto dto)
        {
            var result = await _servicesManger.SalesPerson.Update(dto);

            if (!result.Succeeded)
                return StatusCode(500, result.Errors);

            return Ok(result.Result);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var result = await _servicesManger.SalesPerson.Delete(id);

            if (!result.Succeeded)
                return StatusCode(500, result.Errors);

            return Ok(result.Result);
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var result = await _servicesManger.SalesPerson.GetById(id);

            if (!result.Succeeded)
                return StatusCode(500, result.Errors);

            return Ok(result.Result);
        }



        [HttpPost("Search")]
        public async Task<IActionResult> Search(SqlQueryOptions sqlQueryOptions)
        {
            var result = await _servicesManger.SalesPerson.Search(sqlQueryOptions);

            if (!result.Succeeded)
                return StatusCode(500, result.Errors);

            return Ok(result.Result);
        }
    }
}
