using Inspection.Application.Contracts.Dto.SalesManagment.sales.Transactions.DeliveryNotes;
using Inspection.Application.Contracts.Dto.SharedDtos;
using Inspection.Application.Contracts.Managers;
using Microsoft.AspNetCore.Mvc;
using NDS.Shared.Application.DataQuery;

namespace Inspection.API.Controllers.Controllers.SalesManagment.Transactions.DeliveryNotes
{
    [Route("api/DeliveryNote/[action]")]
    [ApiController]
    public class DeliveryNoteController : ControllerBase
    {
        private readonly IAccountsServicesManger _servicesManger;

        public DeliveryNoteController(IAccountsServicesManger servicesManger)
        {
            _servicesManger = servicesManger;
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] DeliveryNoteCreateDto dto)
        {
            var result = await _servicesManger.DeliveryNote.Create(dto);

            if (result.Succeeded)
                return Ok(result.Result);

            return StatusCode(500, result.Errors);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] DeliveryNoteUpdateDto dto)
        {
            var result = await _servicesManger.DeliveryNote.Update(dto);

            if (result.Succeeded)
                return Ok(result.Result);

            return StatusCode(500, result.Errors);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var result = await _servicesManger.DeliveryNote.Delete(id);

            if (result.Succeeded)
                return Ok(result.Result);

            return StatusCode(500, result.Errors);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var result = await _servicesManger.DeliveryNote.GetById(id);

            if (result.Succeeded)
                return Ok(result.Result);

            return StatusCode(404, result.Errors);
        }

        [HttpPost]
        public async Task<IActionResult> Search([FromBody] SqlQueryOptions options)
        {
            var result = await _servicesManger.DeliveryNote.Search(options);

            if (result.Succeeded)
                return Ok(result.Result);

            return StatusCode(500, result.Errors);
        }

        [HttpGet]
        public async Task<IActionResult> DownloadTemplate()
        {
            var result = await _servicesManger.DeliveryNote.DownloadDeliveryNoteTemplate();

            if (!result.Succeeded)
                return StatusCode(500, result.Errors);

            return File(
                result.Result.Content,
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                result.Result.FileName
            );
        }

        [HttpPost]
        public async Task<IActionResult> Import([FromForm] ExcelImportRequestDto dto)
        {
            var result = await _servicesManger.DeliveryNote.ImportDeliveryNote(dto);

            if (result.Succeeded)
                return Ok(result.Result);

            return StatusCode(500, result.Errors);
        }
    }
}