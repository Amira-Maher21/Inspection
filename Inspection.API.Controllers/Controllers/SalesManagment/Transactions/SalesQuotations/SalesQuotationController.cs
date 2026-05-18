using Inspection.Application.Contracts.Dto.SalesManagment.sales.Transactions.SalesQuotationDTOs;
using Inspection.Application.Contracts.Managers;
using Inspection.Domain.Models.SalesManagment.Transaction.DTOs;
using Microsoft.AspNetCore.Mvc;
using NDS.Shared.API.ControllersBase;
using NDS.Shared.Application.DataQuery;

namespace Inspection.API.Controllers.Controllers.SalesManagment.Transactions.SalesQuotations
{
    [Route("api/SalesQuotation/[action]")]
    [ApiController]
    public class SalesQuotationController : InspectionControllerBase
    {
        private readonly IAccountsServicesManger _servicesManger;

        public SalesQuotationController(IAccountsServicesManger servicesManger)
        {
            _servicesManger = servicesManger;
        }

        [HttpPost]
        public async Task<IActionResult> Create(SalesQuotationCreateDto input)
        {
            var insertResult = await _servicesManger.SalesQuotationService.Create(input);
            if (insertResult.Succeeded)
            {
                return Ok(insertResult.Result);
            }
            return StatusCode(500, insertResult.Errors);
        }

        [HttpPut]
        public async Task<IActionResult> Update(SalesQuotationUpdateDto input)
        {
            var updateResult = await _servicesManger.SalesQuotationService.Update(input);
            if (updateResult.Succeeded)
            {
                return Ok(updateResult.Result);
            }
            return StatusCode(500, updateResult.Errors);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var deleteResult = await _servicesManger.SalesQuotationService.Delete(id);
            if (deleteResult.Succeeded)
            {
                return Ok(deleteResult.Result);
            }
            return StatusCode(500, deleteResult.Errors);
        }

        [HttpPost]
        public async Task<IActionResult> Search(SqlQueryOptions sqlQueryOptions)
        {
            var getResult = await _servicesManger.SalesQuotationService.Search(sqlQueryOptions);
            if (getResult.Succeeded)
            {
                return Ok(getResult.Result);
            }
            return StatusCode(500, getResult.Errors);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var getResult = await _servicesManger.SalesQuotationService.GetById(id);
            if (getResult.Succeeded)
            {
                return Ok(getResult.Result);
            }
            return StatusCode(500, getResult.Errors);
        }
        [HttpPatch()]
        public async Task<IActionResult> ChangeDocumentStatus(ChangeSalesQuotationDocumentStatusDto dto)
        {
            var result = await _servicesManger.SalesQuotationService.ChangeDocumentStatusAsync(dto);

            if (!result.Succeeded)
                return BadRequest(result);

            return Ok(result);
        }
    }
}