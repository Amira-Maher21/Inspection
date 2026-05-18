//using Inspection.Application.Contracts.Dto.EquipmentManagement.EquipmentCalibrationHistorys;
//using Inspection.Application.Contracts.Managers;
//using Microsoft.AspNetCore.Mvc;
//using NDS.Shared.API.ControllersBase;
//using NDS.Shared.Application.DataQuery;

//namespace Inspection.API.Controllers.Controllers.EquipmentManagement.EquipmentCalibrationHistorys
//{


//    [Route("api/EquipmentCalibrationHistory/[action]")]
//    [ApiController]
//    public class EquipmentCalibrationHistoryController : InspectionControllerBase
//    {
//        private readonly IAccountsServicesManger _servicesManger;

//        public EquipmentCalibrationHistoryController(IAccountsServicesManger servicesManger)
//        {
//            _servicesManger = servicesManger;
//        }

//        [HttpPost]
//        public async Task<IActionResult> Create(CreateEquipmentCalibrationHistoryDto insertDto)
//        {
//            var insertResult = await _servicesManger.EquipmentCalibrationHistoryService.InsertEquipmentCalibrationHistoryAsync(insertDto);
//            if (insertResult.Succeeded)
//            {
//                return Ok(insertResult.Result);
//            }
//            return StatusCode(500, insertResult.Errors);
//        }
//        [HttpPost("{id}")]
//        public async Task<IActionResult> Update(UpdateEquipmentCalibrationHistoryDto updateDto, long id)
//        {
//            var updateResult = await _servicesManger.EquipmentCalibrationHistoryService.UpdateEquipmentCalibrationHistoryAsync(updateDto, id);
//            if (updateResult.Succeeded)
//            {
//                return Ok(updateResult.Result);
//            }
//            return StatusCode(500, updateResult.Errors);
//        }
//        [HttpPost("{id}")]
//        public async Task<IActionResult> Delete(long id)
//        {
//            var deleteResult = await _servicesManger.EquipmentCalibrationHistoryService.DeleteEquipmentCalibrationHistoryAsync(id);
//            if (deleteResult.Succeeded)
//            {
//                return Ok(deleteResult.Result);
//            }
//            return StatusCode(500, deleteResult.Errors);
//        }

//        //[HttpGet]
//        //public async Task<IActionResult> GetList()
//        //{
//        //    var list = await _servicesManger.EquipmentCalibrationHistoryService.GetListAsync();
//        //    return Ok(list);
//        //}


//        [HttpPost]
//        public async Task<IActionResult> Index(SqlQueryOptions sqlQueryOptions)
//        {
//            var getResult = await _servicesManger.EquipmentCalibrationHistoryService.GetEquipmentCalibrationHistoryListAsync(sqlQueryOptions);
//            if (getResult.Succeeded)
//            {
//                return Ok(getResult.Result);
//            }
//            return StatusCode(500, getResult.Errors);
//        }

//        [HttpGet("{id}")]
//        public async Task<IActionResult> GetById(long id)
//        {
//            var getResult = await _servicesManger.EquipmentCalibrationHistoryService.GetEquipmentCalibrationHistoryByIdAsync(id);
//            if (getResult.Succeeded)
//            {
//                return Ok(getResult.Result);
//            }
//            return StatusCode(500, getResult.Errors);
//        }

//        //[HttpGet]
//        //public async Task<IActionResult> LookUpEquipmentCalibrationHistoryForNames([FromQuery] SqlQueryOptions sqlQueryOptions)
//        //{
//        //    var getResult = await _servicesManger.EquipmentCalibrationHistoryService.GetLookUpEquipmentCalibrationHistoryForNamesAsync(sqlQueryOptions);
//        //    if (getResult.Succeeded)
//        //    {
//        //        return Ok(getResult.Result);
//        //    }
//        //    return StatusCode(500, getResult.Errors);
//        //}

//    }
//}
