using Inspection.Application.Contracts.Dto.HRManagement.InterviewEvaluations;
using Inspection.Application.Contracts.Managers;
using Microsoft.AspNetCore.Mvc;
using NDS.Shared.API.ControllersBase;
using NDS.Shared.Application.DataQuery;

namespace Inspection.API.Controllers.Controllers.HRManagement.InterviewEvaluations
{
    [Route("api/InterviewEvaluation/[action]")]
    [ApiController]
    public class InterviewEvaluationController : InspectionControllerBase
    {
        private readonly IAccountsServicesManger _servicesManger;

        public InterviewEvaluationController(IAccountsServicesManger servicesManger)
        {
            _servicesManger = servicesManger;
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateInterviewEvaluationDto insertDto)
        {
            var insertResult = await _servicesManger.InterviewEvaluationService.InsertInterviewEvaluationTypeAsync(insertDto);
            if (insertResult.Succeeded)
            {
                return Ok(insertResult.Result);
            }
            return StatusCode(500, insertResult.Errors);
        }
        [HttpPost("{id}")]
        public async Task<IActionResult> Update(UpdateInterviewEvaluationDto updateDto, long id)
        {
            var updateResult = await _servicesManger.InterviewEvaluationService.UpdateInterviewEvaluationTypeAsync(updateDto, id);
            if (updateResult.Succeeded)
            {
                return Ok(updateResult.Result);
            }
            return StatusCode(500, updateResult.Errors);
        }
        [HttpPost("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var deleteResult = await _servicesManger.InterviewEvaluationService.DeleteInterviewEvaluationTypeAsync(id);
            if (deleteResult.Succeeded)
            {
                return Ok(deleteResult.Result);
            }
            return StatusCode(500, deleteResult.Errors);
        }



        [HttpPost]
        public async Task<IActionResult> Index(SqlQueryOptions sqlQueryOptions)
        {
            var getResult = await _servicesManger.InterviewEvaluationService.GetInterviewEvaluationTypeListAsync(sqlQueryOptions);
            if (getResult.Succeeded)
            {
                return Ok(getResult.Result);
            }
            return StatusCode(500, getResult.Errors);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var getResult = await _servicesManger.InterviewEvaluationService.GetInterviewEvaluationTypeByIdAsync(id);
            if (getResult.Succeeded)
            {
                return Ok(getResult.Result);
            }
            return StatusCode(500, getResult.Errors);
        }
        [HttpGet]
        public async Task<IActionResult> LookUpInterviewEvaluationForNames([FromQuery] SqlQueryOptions sqlQueryOptions)
        {
            var getResult = await _servicesManger.InterviewEvaluationService.GetLookUpCompanyForNamesAsync(sqlQueryOptions);
            if (getResult.Succeeded)
            {
                return Ok(getResult.Result);
            }
            return StatusCode(500, getResult.Errors);
        }
    }
}
