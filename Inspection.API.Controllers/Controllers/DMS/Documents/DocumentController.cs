using Inspection.Application.Contracts.Dto.DMSDTOs.DocumentDTOs;
using Inspection.Application.Contracts.Dto.DMSDTOs.DocumentDTOs.DocumentEntityLinkDTOs;
using Inspection.Application.Contracts.Managers;
using Microsoft.AspNetCore.Mvc;
using NDS.Shared.API.ControllersBase;
using NDS.Shared.Application.DataQuery;

namespace Inspection.API.Controllers.Controllers.DMS.Documents
{
    [Route("api/Document/[action]")]
    [ApiController]
    public class DocumentController : InspectionControllerBase
    {
        private readonly IAccountsServicesManger _servicesManger;

        public DocumentController(IAccountsServicesManger servicesManger)
        {
            _servicesManger = servicesManger;
        }

        [HttpPost]
        public async Task<IActionResult> Create(DocumentCreateDto input)
        {
            var insertResult = await _servicesManger.DocumentService.Create(input);
            if (insertResult.Succeeded)
            {
                return Ok(insertResult.Result);
            }
            return StatusCode(500, insertResult.Errors);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDocumentEntityLink(DocumentEntityLinkCreateWithOutDocumentIdDto input)
        {
            var insertResult = await _servicesManger.DocumentService.CreateDocumentEntityLink(input);
            if (insertResult.Succeeded)
            {
                return Ok(insertResult.Result);
            }
            return StatusCode(500, insertResult.Errors);
        }

        [HttpPut]
        public async Task<IActionResult> Update(DocumentUpdateDto input)
        {
            var updateResult = await _servicesManger.DocumentService.Update(input);
            if (updateResult.Succeeded)
            {
                return Ok(updateResult.Result);
            }
            return StatusCode(500, updateResult.Errors);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var deleteResult = await _servicesManger.DocumentService.Delete(id);
            if (deleteResult.Succeeded)
            {
                return Ok(deleteResult.Result);
            }
            return StatusCode(500, deleteResult.Errors);
        }

        [HttpPost]
        public async Task<IActionResult> Search(SqlQueryOptions sqlQueryOptions)
        {
            var getResult = await _servicesManger.DocumentService.Search(sqlQueryOptions);
            if (getResult.Succeeded)
            {
                return Ok(getResult.Result);
            }
            return StatusCode(500, getResult.Errors);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var getResult = await _servicesManger.DocumentService.GetById(id);
            if (getResult.Succeeded)
            {
                return Ok(getResult.Result);
            }
            return StatusCode(500, getResult.Errors);
        }

    }
}
