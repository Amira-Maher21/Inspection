//using Inspection.Application.Contracts.Dto.InspectionManagement.InspectionRequestSubcontractorDetailF;
//using Inspection.Application.Contracts.Managers;
//using Microsoft.AspNetCore.Mvc;
//using NDS.Shared.API.ControllersBase;
//using NDS.Shared.Application.DataQuery;

//namespace Inspection.API.Controllers.Controllers.InspectionManagement.InspectionRequestDetailSubcontractorF
//{
 
//    [Route("api/InspectionRequestDetailSubcontractor/[action]")]
//    [ApiController]
//    public class InspectionRequestDetailSubcontractorController : InspectionControllerBase
//    {
//        private readonly IAccountsServicesManger _servicesManger;

//        public InspectionRequestDetailSubcontractorController(IAccountsServicesManger servicesManger)
//        {
//            _servicesManger = servicesManger;
//        }

//        [HttpPost]
//        public async Task<IActionResult> Create(CreateInspectionRequestSubcontractorDetailDto insertDto)
//        {
//            var insertResult = await _servicesManger.InspectionRequestDetailSubcontractorService.InsertInspectionRequestDetailSubcontractorAsync(insertDto);
//            if (insertResult.Succeeded)
//            {
//                return Ok(insertResult.Result);
//            }
//            return StatusCode(500, insertResult.Errors);
//        }
//        [HttpPost("{id}")]
//        public async Task<IActionResult> Update(UpdateInspectionRequestSubcontractorDetailDto updateDto, long id)
//        {
//            var updateResult = await _servicesManger.InspectionRequestDetailSubcontractorService.UpdateInspectionRequestDetailSubcontractorAsync(updateDto, id);
//            if (updateResult.Succeeded)
//            {
//                return Ok(updateResult.Result);
//            }
//            return StatusCode(500, updateResult.Errors);
//        }
//        [HttpPost("{id}")]
//        public async Task<IActionResult> Delete(long id)
//        {
//            var deleteResult = await _servicesManger.InspectionRequestDetailSubcontractorService.DeleteInspectionRequestDetailSubcontractorAsync(id);
//            if (deleteResult.Succeeded)
//            {
//                return Ok(deleteResult.Result);
//            }
//            return StatusCode(500, deleteResult.Errors);
//        }

//        //[HttpGet]
//        //public async Task<IActionResult> GetList()
//        //{
//        //    var list = await _servicesManger.InspectionRequestDetailSubcontractorService.GetListAsync();
//        //    return Ok(list);
//        //}


//        [HttpPost]
//        public async Task<IActionResult> Index(SqlQueryOptions sqlQueryOptions)
//        {
//            var getResult = await _servicesManger.InspectionRequestDetailSubcontractorService.GetInspectionRequestDetailSubcontractorListAsync(sqlQueryOptions);
//            if (getResult.Succeeded)
//            {
//                return Ok(getResult.Result);
//            }
//            return StatusCode(500, getResult.Errors);
//        }

//        [HttpGet("{id}")]
//        public async Task<IActionResult> GetById(long id)
//        {
//            var getResult = await _servicesManger.InspectionRequestDetailSubcontractorService.GetInspectionRequestDetailSubcontractorByIdAsync(id);
//            if (getResult.Succeeded)
//            {
//                return Ok(getResult.Result);
//            }
//            return StatusCode(500, getResult.Errors);
//        }

//        //[HttpGet]
//        //public async Task<IActionResult> LookUpInspectionRequestDetailSubcontractorForNames([FromQuery] SqlQueryOptions sqlQueryOptions)
//        //{
//        //    var getResult = await _servicesManger.InspectionRequestDetailSubcontractorService.GetLookUpInspectionRequestDetailSubcontractorForNamesAsync(sqlQueryOptions);
//        //    if (getResult.Succeeded)
//        //    {
//        //        return Ok(getResult.Result);
//        //    }
//        //    return StatusCode(500, getResult.Errors);
//        //}

//    }
//}
