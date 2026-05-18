using Inspection.Application.Contracts.Dto.SystemDto.TaxCategorys;
using Inspection.Application.Contracts.Managers;
using Microsoft.AspNetCore.Mvc;
using NDS.Shared.API.ControllersBase;
using NDS.Shared.Application.DataQuery;

namespace Inspection.API.Controllers.System.TaxCategorys
{
    [Route("api/TaxCategory/[action]")]

    [ApiController]
    public class TaxCategoryController : InspectionControllerBase
    {
        private readonly IAccountsServicesManger _servicesManger;

        public TaxCategoryController(IAccountsServicesManger servicesManger)
        {
            _servicesManger = servicesManger;
        }

        [HttpPost]
        public async Task<IActionResult> Create(TaxCategoryCreateDto dto)
        {
            var result = await _servicesManger.TaxCategory.Create(dto);

            if (!result.Succeeded)
                return BadRequest(result.Errors);

            return Ok(result.Result);
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] TaxCategoryUpdateDto dto)
        {
            var result = await _servicesManger.TaxCategory.Update(dto);

            if (!result.Succeeded)
                return BadRequest(result.Errors);

            return Ok(result.Result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var result = await _servicesManger.TaxCategory.Delete(id);

            if (!result.Succeeded)
                return BadRequest(result.Errors);

            return Ok(result.Result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var result = await _servicesManger.TaxCategory.GetById(id);

            if (!result.Succeeded)
                return NotFound(result.Errors);

            return Ok(result.Result);
        }

        [HttpPost]
        public async Task<IActionResult> Search(SqlQueryOptions sqlQueryOptions)
        {
            var result = await _servicesManger.TaxCategory.Search(sqlQueryOptions);

            if (!result.Succeeded)
                return BadRequest(result.Errors);

            return Ok(result.Result);
        }
    }

}
