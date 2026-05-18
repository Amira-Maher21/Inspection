using Inspection.Application.Contracts.Dto.InspectionManagement.InspectorCategory;
using Inspection.Application.Contracts.Managers;
using Microsoft.AspNetCore.Mvc;
using NDS.Shared.Application.DataQuery;

namespace Inspection.API.Controllers.Controllers.InspectionManagement.InspectorCategory
{
    [Route("api/InspectorCategory/[action]")]
    [ApiController]
    public class InspectorCategoryController : ControllerBase
    {
        private readonly IAccountsServicesManger _servicesManger;
        public InspectorCategoryController(IAccountsServicesManger servicesManger)
        {
            _servicesManger = servicesManger;
        }

        [HttpPost]
        public async Task<IActionResult> Create(InspectorCategoryCreateDto input)
        {
            var insertResult = await _servicesManger.InspectorCategoryService.Create(input);
            if (insertResult.Succeeded)
            {
                return Ok(insertResult.Result);
            }
            return StatusCode(500, insertResult.Errors);
        }

        [HttpPut]
        public async Task<IActionResult> Update(InspectorCategoryUpdateDto input)
        {
            var updateResult = await _servicesManger.InspectorCategoryService.Update(input);
            if (updateResult.Succeeded)
            {
                return Ok(updateResult.Result);
            }
            return StatusCode(500, updateResult.Errors);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var deleteResult = await _servicesManger.InspectorCategoryService.Delete(id);
            if (deleteResult.Succeeded)
            {
                return Ok(deleteResult.Result);
            }
            return StatusCode(500, deleteResult.Errors);
        }

        [HttpPost]
        public async Task<IActionResult> Search(SqlQueryOptions sqlQueryOptions)
        {
            var getResult = await _servicesManger.InspectorCategoryService.Search(sqlQueryOptions);
            if (getResult.Succeeded)
            {
                return Ok(getResult.Result);
            }
            return StatusCode(500, getResult.Errors);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var getResult = await _servicesManger.InspectorCategoryService.GetById(id);
            if (getResult.Succeeded)
            {
                return Ok(getResult.Result);
            }
            return StatusCode(500, getResult.Errors);
        }


        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var result = await _servicesManger.InspectorCategoryService.GetInspectorCategoryGetListAsync();

            if (result.Succeeded)
            {
                return Ok(result.Result);
            }

            return StatusCode(500, result.Errors);
        }

    }
}