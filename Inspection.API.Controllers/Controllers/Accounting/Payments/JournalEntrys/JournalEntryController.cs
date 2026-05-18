using Inspection.Application.Contracts.Dto.AccountingDtos.Payments.JournalEntrys;
using Inspection.Application.Contracts.Dto.SharedDtos;
using Inspection.Application.Contracts.Managers;
using Microsoft.AspNetCore.Mvc;
using NDS.Shared.API.ControllersBase;
using NDS.Shared.Application.DataQuery;

namespace Inspection.API.Controllers.Controllers.Accounting.Payments.JournalEntrys
{
    [Route("api/JournalEntry/[action]")]
    [ApiController]





    public class JournalEntryController : InspectionControllerBase
    {
        private readonly IAccountsServicesManger _servicesManger;

        public JournalEntryController(IAccountsServicesManger servicesManger)
        {
            _servicesManger = servicesManger;
        }



        [HttpPost]
        public async Task<IActionResult> Create([FromBody] JournalEntryCreateDto dto)
        {
            var result = await _servicesManger.IJournalEntryService.Create(dto);

            if (!result.Succeeded)
                return StatusCode(500, result.Errors);

            return Ok(result.Result);
        }





        [HttpPut]
        public async Task<IActionResult> Update([FromBody] JournalEntryUpdateDto dto)
        {
            var result = await _servicesManger.IJournalEntryService.Update(dto);
            if (!result.Succeeded)
                return BadRequest(result);

            return Ok(result.Result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var result = await _servicesManger.IJournalEntryService.Delete(id);
            if (!result.Succeeded)
                return BadRequest(result);

            return Ok(result.Result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var result = await _servicesManger.IJournalEntryService.GetById(id);
            if (!result.Succeeded)
                return NotFound(result);

            return Ok(result.Result);
        }

        [HttpPost]
        public async Task<IActionResult> Search([FromBody] SqlQueryOptions queryOptions)
        {
            var result = await _servicesManger.IJournalEntryService.Search(queryOptions);
            if (!result.Succeeded)
                return BadRequest(result);

            return Ok(result.Result);
        }

        #region Posting

        [HttpPost("{journalEntryId}")]
        public async Task<IActionResult> Post(long journalEntryId)
        {
            var result = await _servicesManger.IJournalEntryService.PostJournalEntry(journalEntryId);

            if (!result.Succeeded)
                return BadRequest(result.Errors);

            return Ok(result);
        }

        #endregion


        [HttpPatch("Import")]
        public async Task<IActionResult> Import([FromForm] ExcelImportRequestDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _servicesManger.IJournalEntryService.ImportJournalEntries(dto);

            if (!result.Succeeded)
                return StatusCode(500, result.Errors);

            return Ok(result.Result);
        }

        [HttpGet("DownloadTemplate")]
        public async Task<IActionResult> DownloadTemplate()
        {
            var result = await _servicesManger.IJournalEntryService.DownloadTemplate();

            if (!result.Succeeded)
                return BadRequest(result);

            var file = result.Result!;

            return File(
                file.Content,
                file.ContentType,
                file.FileName);
        }
    }
}