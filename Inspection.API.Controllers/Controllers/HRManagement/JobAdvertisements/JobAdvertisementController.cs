using Inspection.Application.Contracts.Dto.HRManagement.JobAdvertisements;
using Inspection.Application.Contracts.Managers;
using Microsoft.AspNetCore.Mvc;
using NDS.Shared.API.ControllersBase;
using NDS.Shared.Application.DataQuery;

namespace Inspection.API.Controllers.Controllers.HRManagement.JobAdvertisements
{
    [Route("api/JobAdvertisement/[action]")]
    [ApiController]
    public class JobAdvertisementController : InspectionControllerBase
    {
        private readonly IAccountsServicesManger _servicesManger;

        public JobAdvertisementController(IAccountsServicesManger servicesManger)
        {
            _servicesManger = servicesManger;
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateJobAdvertisementDto insertDto)
        {
            var insertResult = await _servicesManger.JobAdvertisementService.InsertJobAdvertisementTypeAsync(insertDto);
            if (insertResult.Succeeded)
            {
                return Ok(insertResult.Result);
            }
            return StatusCode(500, insertResult.Errors);
        }
        [HttpPost("{id}")]
        public async Task<IActionResult> Update(UpdateJobAdvertisementDto updateDto, long id)
        {
            var updateResult = await _servicesManger.JobAdvertisementService.UpdateJobAdvertisementTypeAsync(updateDto, id);
            if (updateResult.Succeeded)
            {
                return Ok(updateResult.Result);
            }
            return StatusCode(500, updateResult.Errors);
        }
        [HttpPost("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var deleteResult = await _servicesManger.JobAdvertisementService.DeleteJobAdvertisementTypeAsync(id);
            if (deleteResult.Succeeded)
            {
                return Ok(deleteResult.Result);
            }
            return StatusCode(500, deleteResult.Errors);
        }



        [HttpPost]
        public async Task<IActionResult> Index(SqlQueryOptions sqlQueryOptions)
        {
            var getResult = await _servicesManger.JobAdvertisementService.GetJobAdvertisementTypeListAsync(sqlQueryOptions);
            if (getResult.Succeeded)
            {
                return Ok(getResult.Result);
            }
            return StatusCode(500, getResult.Errors);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var getResult = await _servicesManger.JobAdvertisementService.GetJobAdvertisementTypeByIdAsync(id);
            if (getResult.Succeeded)
            {
                return Ok(getResult.Result);
            }
            return StatusCode(500, getResult.Errors);
        }
        [HttpGet]
        public async Task<IActionResult> LookUpJobAdvertisementForNames([FromQuery] SqlQueryOptions sqlQueryOptions)
        {
            var getResult = await _servicesManger.JobAdvertisementService.GetLookUpCompanyForNamesAsync(sqlQueryOptions);
            if (getResult.Succeeded)
            {
                return Ok(getResult.Result);
            }
            return StatusCode(500, getResult.Errors);
        }
    }
}
