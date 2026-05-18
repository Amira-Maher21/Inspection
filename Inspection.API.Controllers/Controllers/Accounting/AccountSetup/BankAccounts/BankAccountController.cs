using Inspection.Application.Contracts.Dto.AccountingDtos.AccountingSetupDtos.BankAccountDTOs;
using Inspection.Application.Contracts.Managers;
using Microsoft.AspNetCore.Mvc;
using NDS.Shared.API.ControllersBase;
using NDS.Shared.Application.DataQuery;

namespace Inspection.API.Controllers.Controllers.Accounting.AccountSetup.BankAccounts
{
    [Route("api/[controller]")]
    [ApiController]

    public class BankAccountController : InspectionControllerBase
    {
        private readonly IAccountsServicesManger _servicesManger;

        public BankAccountController(IAccountsServicesManger servicesManger)
        {
            _servicesManger = servicesManger;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] BankAccountCreateDto dto)
        {
            var createResult = await _servicesManger.BankAccountService.Create(dto);

            if (createResult.Succeeded && createResult.Result != null)
            {
                return Ok(createResult.Result); // Flat JSON
            }

            return StatusCode(500, createResult.Errors);
        }


        [HttpPut]
        public async Task<IActionResult> Update([FromBody] BankAccountUpdateDto dto)
        {
            var updateResult = await _servicesManger.BankAccountService.Update(dto);

            if (updateResult.Succeeded && updateResult.Result != null)
            {
                return Ok(updateResult.Result);
            }

            return StatusCode(500, updateResult.Errors);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var deleteResult = await _servicesManger.BankAccountService.Delete(id);

            if (deleteResult.Succeeded && deleteResult.Result != null)
            {
                return Ok(deleteResult.Result);
            }

            return StatusCode(500, deleteResult.Errors);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var getResult = await _servicesManger.BankAccountService.GetById(id);

            if (getResult.Succeeded && getResult.Result != null)
            {
                return Ok(getResult.Result);
            }

            return NotFound();
        }





        [HttpPost("Search")]
        public async Task<IActionResult> Search(SqlQueryOptions sqlQueryOptions)
        {
            var getResult = await _servicesManger.BankAccountService.Search(sqlQueryOptions);
            if (getResult.Succeeded)
                return Ok(getResult.Result);
            return StatusCode(500, getResult.Errors);
        }
    }

}
