using Inspection.Application.Contracts.Dto.AccountingDtos.Payments.CashReceiptDTOs;
using Inspection.Application.Contracts.Managers;
using Microsoft.AspNetCore.Mvc;
using NDS.Shared.API.ControllersBase;
using NDS.Shared.Application.DataQuery;

namespace Inspection.API.Controllers.Controllers.Accounting.Payments.CashReceipts
{
    [Route("api/CashReceipt/[action]")]
    [ApiController]
    public class CashReceiptController : InspectionControllerBase
    {
        private readonly IAccountsServicesManger _servicesManger;

        public CashReceiptController(IAccountsServicesManger servicesManger)
        {
            _servicesManger = servicesManger;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CashReceiptCreateDto input)
        {
            var insertResult = await _servicesManger.CashReceiptService.Create(input);
            if (insertResult.Succeeded)
            {
                return Ok(insertResult.Result);
            }
            return StatusCode(500, insertResult.Errors);
        }

        [HttpPut]
        public async Task<IActionResult> Update(CashReceiptUpdateDto input)
        {
            var updateResult = await _servicesManger.CashReceiptService.Update(input);
            if (updateResult.Succeeded)
            {
                return Ok(updateResult.Result);
            }
            return StatusCode(500, updateResult.Errors);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var deleteResult = await _servicesManger.CashReceiptService.Delete(id);
            if (deleteResult.Succeeded)
            {
                return Ok(deleteResult.Result);
            }
            return StatusCode(500, deleteResult.Errors);
        }

        [HttpPost]
        public async Task<IActionResult> Search(SqlQueryOptions sqlQueryOptions)
        {
            var getResult = await _servicesManger.CashReceiptService.Search(sqlQueryOptions);
            if (getResult.Succeeded)
            {
                return Ok(getResult.Result);
            }
            return StatusCode(500, getResult.Errors);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var getResult = await _servicesManger.CashReceiptService.GetById(id);
            if (getResult.Succeeded)
            {
                return Ok(getResult.Result);
            }
            return StatusCode(500, getResult.Errors);
        }
    }
}