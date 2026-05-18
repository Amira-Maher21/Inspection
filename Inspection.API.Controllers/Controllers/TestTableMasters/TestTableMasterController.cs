using Inspection.Application.Contracts.Dto.TestTableMasters;
using Inspection.Application.Contracts.Managers;
using Microsoft.AspNetCore.Mvc;
using NDS.Shared.API.ControllersBase;

namespace Inspection.API.Controllers.Controllers.TestTableMasters
{

    [Route("api/testTable/[action]")]
    [ApiController]
    public class TestTableMasterController : InspectionControllerBase
    {
        private readonly IAccountsServicesManger _servicesManger;

        public TestTableMasterController(IAccountsServicesManger servicesManger)
        {
            _servicesManger = servicesManger;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateTestTableMasterDto insertDto)
        {
            var insertResult = await _servicesManger.TestTableMasterService.InsertTestTableMasterAsync(insertDto);
            if (insertResult.Succeeded)
            {
                return Ok(insertResult.Result);
            }
            return StatusCode(500, insertResult.Errors);
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateTestTableMasterDto updateDto)
        {
            var updateResult = await _servicesManger.TestTableMasterService.UpdateTestTableMasterAsync(updateDto);
            if (updateResult.Succeeded)
            {
                return Ok(updateResult.Result);
            }
            return StatusCode(500, updateResult.Errors);
        }
        //[HttpPost("{id}")]
        //public async Task<IActionResult> Delete(long id)
        //{
        //    var deleteResult = await _servicesManger.TestTableMasterService.DeleteTestTableMasterAsync(id);
        //    if (deleteResult.Succeeded)
        //    {
        //        return Ok(deleteResult.Result);
        //    }
        //    return StatusCode(500, deleteResult.Errors);
        //}

        //[HttpGet]
        //public async Task<IActionResult> GetList()
        //{
        //    var list = await _servicesManger.TestTableMasterService.GetListAsync();
        //    return Ok(list);
        //}



        //[HttpPost]
        //public async Task<IActionResult> Index(SqlQueryOptions sqlQueryOptions)
        //{
        //    var getResult = await _servicesManger.TestTableMasterService.GetTestTableMasterListByIncludeAsync(sqlQueryOptions);
        //    if (getResult.Succeeded)
        //    {
        //        return Ok(getResult.Result);
        //    }
        //    return StatusCode(500, getResult.Errors);
        //}

        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetById(long id)
        //{
        //    var getResult = await _servicesManger.TestTableMasterService.GetTestTableMasterByIdAsync(id);
        //    if (getResult.Succeeded)
        //    {
        //        return Ok(getResult.Result);
        //    }
        //    return StatusCode(500, getResult.Errors);
        //}

    }
}
