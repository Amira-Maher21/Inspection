using Inspection.Application.Contracts.Dto.HRManagement.JobTitles;
using Inspection.Application.Contracts.Managers;
using Microsoft.AspNetCore.Mvc;
using NDS.Shared.API.ControllersBase;
using NDS.Shared.Application.DataQuery;

namespace Inspection.API.Controllers.Controllers.HRManagement.JobTitles
{
    [Route("api/JobTitle/[action]")]
    [ApiController]
    public class JobTitleController : InspectionControllerBase
    {
        private readonly IAccountsServicesManger _servicesManger;

        public JobTitleController(IAccountsServicesManger servicesManger)
        {
            _servicesManger = servicesManger;
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateJobTitleDto insertDto)
        {
            var insertResult = await _servicesManger.JobTitleService.InsertJobTitleAsync(insertDto);
            if (insertResult.Succeeded)
            {
                return Ok(insertResult.Result);
            }
            return StatusCode(500, insertResult.Errors);
        }
        [HttpPost("{id}")]
        public async Task<IActionResult> Update(UpdateJobTitleDto updateDto, long id)
        {
            var updateResult = await _servicesManger.JobTitleService.UpdateJobTitleAsync(updateDto, id);
            if (updateResult.Succeeded)
            {
                return Ok(updateResult.Result);
            }
            return StatusCode(500, updateResult.Errors);
        }
        [HttpPost("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var deleteResult = await _servicesManger.JobTitleService.DeleteJobTitleAsync(id);
            if (deleteResult.Succeeded)
            {
                return Ok(deleteResult.Result);
            }
            return StatusCode(500, deleteResult.Errors);
        }

        [HttpPost]
        public async Task<IActionResult> Index(SqlQueryOptions sqlQueryOptions)
        {
            var getResult = await _servicesManger.JobTitleService.GetJobTitleListAsync(sqlQueryOptions);
            if (getResult.Succeeded)
            {
                return Ok(getResult.Result);
            }
            return StatusCode(500, getResult.Errors);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var getResult = await _servicesManger.JobTitleService.GetJobTitleByIdAsync(id);
            if (getResult.Succeeded)
            {
                return Ok(getResult.Result);
            }
            return StatusCode(500, getResult.Errors);
        }
        [HttpGet]
        public async Task<IActionResult> LookUpJobTitleForNames([FromQuery] SqlQueryOptions sqlQueryOptions)
        {
            var getResult = await _servicesManger.JobTitleService.GetLookUpCompanyForNamesAsync(sqlQueryOptions);
            if (getResult.Succeeded)
            {
                return Ok(getResult.Result);
            }
            return StatusCode(500, getResult.Errors);
        }
    }
}
