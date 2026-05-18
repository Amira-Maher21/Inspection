using Inspection.Application.Contracts.Dto.AccountingDtos.Payments.DebitNoteDTOs;
using Inspection.Application.Contracts.Managers;
using Microsoft.AspNetCore.Mvc;
using NDS.Shared.API.ControllersBase;
using NDS.Shared.Application.DataQuery;

namespace Inspection.API.Controllers.Controllers.Accounting.Payments.DebitNotes
{
    [Route("api/DebitNote/[action]")]
    [ApiController]
    public class DebitNoteController : InspectionControllerBase
    {
        private readonly IAccountsServicesManger _servicesManger;

        public DebitNoteController(IAccountsServicesManger servicesManger)
        {
            _servicesManger = servicesManger;
        }

        [HttpPost]
        public async Task<IActionResult> Create(DebitNoteCreateDto input)
        {
            var insertResult = await _servicesManger.DebitNoteService.Create(input);
            if (insertResult.Succeeded)
            {
                return Ok(insertResult.Result);
            }
            return StatusCode(500, insertResult.Errors);
        }

        [HttpPut]
        public async Task<IActionResult> Update(DebitNoteUpdateDto input)
        {
            var updateResult = await _servicesManger.DebitNoteService.Update(input);
            if (updateResult.Succeeded)
            {
                return Ok(updateResult.Result);
            }
            return StatusCode(500, updateResult.Errors);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var deleteResult = await _servicesManger.DebitNoteService.Delete(id);
            if (deleteResult.Succeeded)
            {
                return Ok(deleteResult.Result);
            }
            return StatusCode(500, deleteResult.Errors);
        }

        [HttpPost]
        public async Task<IActionResult> Search(SqlQueryOptions sqlQueryOptions)
        {
            var getResult = await _servicesManger.DebitNoteService.Search(sqlQueryOptions);
            if (getResult.Succeeded)
            {
                return Ok(getResult.Result);
            }
            return StatusCode(500, getResult.Errors);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var getResult = await _servicesManger.DebitNoteService.GetById(id);
            if (getResult.Succeeded)
            {
                return Ok(getResult.Result);
            }
            return StatusCode(500, getResult.Errors);
        }
    }
}