using Inspection.Application.Contracts.Dto.AccountingDtos.PR.MasterData.Suppliers;
using Inspection.Application.Contracts.Managers;
using Microsoft.AspNetCore.Mvc;
using NDS.Shared.API.ControllersBase;
using NDS.Shared.Application.DataQuery;

namespace Inspection.API.Controllers.Controllers.Accounting.PR.MasterData
{
    [Route("api/Suppliers/[action]")]
    [ApiController]
    public class SuppliersController : InspectionControllerBase
    {
        private readonly IAccountsServicesManger _servicesManger;

        public SuppliersController(IAccountsServicesManger servicesManger)
        {
            _servicesManger = servicesManger;
        }

        [HttpPost]
        public async Task<IActionResult> Create(SuppliersCreateDTOs input)
        {
            var insertResult = await _servicesManger.SupplierService.Create(input);
            if (insertResult.Succeeded)
            {
                return Ok(insertResult.Result);
            }
            return StatusCode(500, insertResult.Errors);
        }

        [HttpPut]
        public async Task<IActionResult> Update(SupplierUdateDTOs input)
        {
            var updateResult = await _servicesManger.SupplierService.Update(input);
            if (updateResult.Succeeded)
            {
                return Ok(updateResult.Result);
            }
            return StatusCode(500, updateResult.Errors);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var deleteResult = await _servicesManger.SupplierService.Delete(id);

            if (deleteResult.Succeeded)
            {
                return Ok(deleteResult.Result);
            }

            if (deleteResult.Errors.Any(e => e.ErrorCode == "404"))
                return NotFound(deleteResult.Errors);

            return StatusCode(500, deleteResult.Errors);
        }


        [HttpPost]
        public async Task<IActionResult> Search(SqlQueryOptions sqlQueryOptions)
        {
            var getResult = await _servicesManger.SupplierService.Search(sqlQueryOptions);
            if (getResult.Succeeded)
            {
                return Ok(getResult.Result);
            }
            return StatusCode(500, getResult.Errors);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var getResult = await _servicesManger.SupplierService.GetById(id);
            if (getResult.Succeeded)
            {
                return Ok(getResult.Result);
            }
            return StatusCode(500, getResult.Errors);
        }
    }
}
