//using Inspection.Application.Contracts.Dto.InspectionManagement.InspectionRequestDetailF;
//using Inspection.Application.Contracts.Managers;
//using Microsoft.AspNetCore.Mvc;
//using NDS.Shared.API.ControllersBase;
//using NDS.Shared.Application.DataQuery;

//namespace Inspection.API.Controllers.Controllers.InspectionManagement.InspectionRequestDetailF
//{
 
//    [Route("api/InspectionRequestDetail/[action]")]
//    [ApiController]
//    public class InspectionRequestDetailController : InspectionControllerBase
//    {
//        private readonly IAccountsServicesManger _servicesManger;

//        public InspectionRequestDetailController(IAccountsServicesManger servicesManger)
//        {
//            _servicesManger = servicesManger;
//        }

//        [HttpPost]
//        public async Task<IActionResult> Create(CreateInspectionRequestDetailDto insertDto)
//        {
//            var insertResult = await _servicesManger.InspectionRequestDetailService.InsertInspectionRequestDetailAsync(insertDto);
//            if (insertResult.Succeeded)
//            {
//                return Ok(insertResult.Result);
//            }
//            return StatusCode(500, insertResult.Errors);
//        }
//        [HttpPost("{id}")]
//        public async Task<IActionResult> Update(UpdateInspectionRequestDetailDto updateDto, long id)
//        {
//            var updateResult = await _servicesManger.InspectionRequestDetailService.UpdateInspectionRequestDetailAsync(updateDto, id);
//            if (updateResult.Succeeded)
//            {
//                return Ok(updateResult.Result);
//            }
//            return StatusCode(500, updateResult.Errors);
//        }
//        [HttpPost("{id}")]
//        public async Task<IActionResult> Delete(long id)
//        {
//            var deleteResult = await _servicesManger.InspectionRequestDetailService.DeleteInspectionRequestDetailAsync(id);
//            if (deleteResult.Succeeded)
//            {
//                return Ok(deleteResult.Result);
//            }
//            return StatusCode(500, deleteResult.Errors);
//        }

//        //[HttpGet]
//        //public async Task<IActionResult> GetList()
//        //{
//        //    var list = await _servicesManger.InspectionRequestDetailService.GetListAsync();
//        //    return Ok(list);
//        //}


//        [HttpPost]
//        public async Task<IActionResult> Index(SqlQueryOptions sqlQueryOptions)
//        {
//            var getResult = await _servicesManger.InspectionRequestDetailService.GetInspectionRequestDetailListAsync(sqlQueryOptions);
//            if (getResult.Succeeded)
//            {
//                return Ok(getResult.Result);
//            }
//            return StatusCode(500, getResult.Errors);
//        }

//        [HttpGet("{id}")]
//        public async Task<IActionResult> GetById(long id)
//        {
//            var getResult = await _servicesManger.InspectionRequestDetailService.GetInspectionRequestDetailByIdAsync(id);
//            if (getResult.Succeeded)
//            {
//                return Ok(getResult.Result);
//            }
//            return StatusCode(500, getResult.Errors);
//        }

//        //[HttpGet]
//        //public async Task<IActionResult> LookUpInspectionRequestDetailForNames([FromQuery] SqlQueryOptions sqlQueryOptions)
//        //{
//        //    var getResult = await _servicesManger.InspectionRequestDetailService.GetLookUpInspectionRequestDetailForNamesAsync(sqlQueryOptions);
//        //    if (getResult.Succeeded)
//        //    {
//        //        return Ok(getResult.Result);
//        //    }
//        //    return StatusCode(500, getResult.Errors);
//        //}

//    }
//}
