using Inspection.Application.Contracts.Dto.ContractingDTOs.Setup.BOQDTOs;
using Inspection.Application.Contracts.Managers;
using Microsoft.AspNetCore.Mvc;
using NDS.Shared.API.ControllersBase;
using NDS.Shared.Application.DataQuery;

namespace Inspection.API.Controllers.Controllers.Contracting.Setup.BOQs
{
    [Route("api/BOQ/[action]")]
    [ApiController]
    public class BOQController : InspectionControllerBase
    {
        private readonly IAccountsServicesManger _servicesManger;

        public BOQController(IAccountsServicesManger servicesManger)
        {
            _servicesManger = servicesManger;
        }

        [HttpPost]
        public async Task<IActionResult> Create(BOQCreateDto input)
        {
            var insertResult = await _servicesManger.BOQService.Create(input);
            if (insertResult.Succeeded)
            {
                return Ok(insertResult.Result);
            }
            return StatusCode(500, insertResult.Errors);
        }

        [HttpPut]
        public async Task<IActionResult> Update(BOQUpdateDto input)
        {
            var updateResult = await _servicesManger.BOQService.Update(input);
            if (updateResult.Succeeded)
            {
                return Ok(updateResult.Result);
            }
            return StatusCode(500, updateResult.Errors);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var deleteResult = await _servicesManger.BOQService.Delete(id);
            if (deleteResult.Succeeded)
            {
                return Ok(deleteResult.Result);
            }
            return StatusCode(500, deleteResult.Errors);
        }

        [HttpPost]
        public async Task<IActionResult> Search(SqlQueryOptions sqlQueryOptions)
        {
            var getResult = await _servicesManger.BOQService.Search(sqlQueryOptions);
            if (getResult.Succeeded)
            {
                return Ok(getResult.Result);
            }
            return StatusCode(500, getResult.Errors);
        }

        [HttpPost]
        public async Task<IActionResult> SearchBOQLine(SqlQueryOptions sqlQueryOptions)
        {
            var getResult = await _servicesManger.BOQService.SearchBOQLines(sqlQueryOptions);
            if (getResult.Succeeded)
            {
                return Ok(getResult.Result);
            }
            return StatusCode(500, getResult.Errors);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var getResult = await _servicesManger.BOQService.GetById(id);
            if (getResult.Succeeded)
            {
                return Ok(getResult.Result);
            }
            return StatusCode(500, getResult.Errors);
        }
    }
}