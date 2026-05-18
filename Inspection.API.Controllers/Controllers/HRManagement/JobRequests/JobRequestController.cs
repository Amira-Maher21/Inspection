using Inspection.Application.Contracts.Dto.HRManagement.ApplicantCVs;
using Inspection.Application.Contracts.Dto.HRManagement.JobRequests;
using Inspection.Application.Contracts.Managers;
using Microsoft.AspNetCore.Mvc;
using NDS.Shared.API.ControllersBase;
using NDS.Shared.Application.DataQuery;

namespace Inspection.API.Controllers.Controllers.HRManagement.JobRequests
{
    [Route("api/JobRequest/[action]")]
    [ApiController]
    public class JobRequestController : InspectionControllerBase
    {
        private readonly IAccountsServicesManger _servicesManger;

        public JobRequestController(IAccountsServicesManger servicesManger)
        {
            _servicesManger = servicesManger;
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateJobRequestDto insertDto)
        {
            var insertResult = await _servicesManger.JobRequestService.InsertJobRequestAsync(insertDto);
            if (insertResult.Succeeded)
            {
                return Ok(insertResult.Result);
            }
            return StatusCode(500, insertResult.Errors);
        }
        [HttpPost("{id}")]
        public async Task<IActionResult> Update(UpdateJobRequestDto updateDto, long id)
        {
            var updateResult = await _servicesManger.JobRequestService.UpdateJobRequestAsync(updateDto, id);
            if (updateResult.Succeeded)
            {
                return Ok(updateResult.Result);
            }
            return StatusCode(500, updateResult.Errors);
        }
        [HttpPost("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var deleteResult = await _servicesManger.JobRequestService.DeleteJobRequestAsync(id);
            if (deleteResult.Succeeded)
            {
                return Ok(deleteResult.Result);
            }
            return StatusCode(500, deleteResult.Errors);
        }

        [HttpPost]
        public async Task<IActionResult> Index(SqlQueryOptions sqlQueryOptions)
        {
            var getResult = await _servicesManger.JobRequestService.GetJobRequestListAsync(sqlQueryOptions);
            if (getResult.Succeeded)
            {
                return Ok(getResult.Result);
            }
            return StatusCode(500, getResult.Errors);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var getResult = await _servicesManger.JobRequestService.GetJobRequestByIdAsync(id);
            if (getResult.Succeeded)
            {
                return Ok(getResult.Result);
            }
            return StatusCode(500, getResult.Errors);
        }
        [HttpGet]
        public async Task<IActionResult> LookUpJobRequestForNames([FromQuery] SqlQueryOptions sqlQueryOptions)
        {
            var getResult = await _servicesManger.JobRequestService.GetLookUpCompanyForNamesAsync(sqlQueryOptions);
            if (getResult.Succeeded)
            {
                return Ok(getResult.Result);
            }
            return StatusCode(500, getResult.Errors);
        }
        [HttpPost]
        public async Task<IActionResult> ChangeStatus([FromQuery] long id, [FromBody] ChangejobRequestStatus input)
        {
            var result = await _servicesManger.JobRequestService.ChangeStatus(id, input);
            if (result.Succeeded)
                return Ok(result.Result);
            return StatusCode(500, result.Errors);
        }
    }
}
