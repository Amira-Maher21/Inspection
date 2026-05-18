using Inspection.Application.Contracts.Dto.AccountingDtos.AR.MasterData;
using Inspection.Application.Contracts.Dto.AccountingDtos.AR.MasterData.CustomerContacts;
using Inspection.Application.Contracts.Dto.InspectionManagement.CustomerLocations;
using Inspection.Application.Contracts.Dto.InspectionManagement.CustomerProjects;
using Inspection.Application.Contracts.Managers;
using Microsoft.AspNetCore.Mvc;
using NDS.Shared.API.ControllersBase;
using NDS.Shared.Application.DataQuery;

namespace Inspection.API.Controllers.Controllers.Accounting.AR.MasterData
{
    [Route("api/Customers/[action]")]
    [ApiController]
    public class CustomerController : InspectionControllerBase
    {
        private readonly IAccountsServicesManger _servicesManger;

        public CustomerController(IAccountsServicesManger servicesManger)
        {
            _servicesManger = servicesManger;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CustomerCreateDto input)
        {
            var insertResult = await _servicesManger.CustomerService.Create(input);
            if (insertResult.Succeeded)
            {
                return Ok(insertResult.Result);
            }
            return StatusCode(500, insertResult.Errors);
        }

        [HttpPut]
        public async Task<IActionResult> Update(CustomerUpdateDto input)
        {
            var updateResult = await _servicesManger.CustomerService.Update(input);
            if (updateResult.Succeeded)
            {
                return Ok(updateResult.Result);
            }
            return StatusCode(500, updateResult.Errors);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var deleteResult = await _servicesManger.CustomerService.Delete(id);

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
            var getResult = await _servicesManger.CustomerService.Search(sqlQueryOptions);
            if (getResult.Succeeded)
            {
                return Ok(getResult.Result);
            }
            return StatusCode(500, getResult.Errors);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var getResult = await _servicesManger.CustomerService.GetById(id);
            if (getResult.Succeeded)
            {
                return Ok(getResult.Result);
            }
            return StatusCode(500, getResult.Errors);
        }


        //Add List

        [HttpPost]
        public async Task<IActionResult> AddLocations([FromBody] List<CreateCustomerLocationDto> locations)
        {
            var result = await _servicesManger.CustomerService.AddLocations(locations);

            if (result.Succeeded)
                return Ok(result.Result);

            if (result.Errors.Any(e => e.ErrorCode == "404"))
                return NotFound(result.Errors);

            return StatusCode(500, result.Errors);
        }

        [HttpPost]
        public async Task<IActionResult> AddProjects([FromBody] List<CreateCustomerProjectDto> projects)
        {
            var result = await _servicesManger.CustomerService.AddProjects(projects);

            if (result.Succeeded)
                return Ok(result.Result);

            if (result.Errors.Any(e => e.ErrorCode == "404"))
                return NotFound(result.Errors);

            return StatusCode(500, result.Errors);
        }

        [HttpPost]
        public async Task<IActionResult> AddContacts([FromBody] List<CustomerContactCreateDto> contacts)
        {
            var result = await _servicesManger.CustomerService.AddContacts(contacts);

            if (result.Succeeded)
                return Ok(result.Result);

            if (result.Errors.Any(e => e.ErrorCode == "404"))
                return NotFound(result.Errors);

            return StatusCode(500, result.Errors);
        }




    }
}
