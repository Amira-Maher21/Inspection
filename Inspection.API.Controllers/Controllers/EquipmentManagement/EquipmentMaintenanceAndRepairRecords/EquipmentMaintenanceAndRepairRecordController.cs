//using Inspection.Application.Contracts.Dto.EquipmentManagement.EquipmentMaintenanceAndRepairRecords;
//using Inspection.Application.Contracts.Managers;
//using Microsoft.AspNetCore.Mvc;
//using NDS.Shared.API.ControllersBase;
//using NDS.Shared.Application.DataQuery;

//namespace Inspection.API.Controllers.Controllers.EquipmentManagement.EquipmentMaintenanceAndRepairRecords
//{
 

//    [Route("api/EquipmentMaintenanceAndRepairRecord/[action]")]
//    [ApiController]
//    public class EquipmentMaintenanceAndRepairRecordController : InspectionControllerBase
//    {
//        private readonly IAccountsServicesManger _servicesManger;

//        public EquipmentMaintenanceAndRepairRecordController(IAccountsServicesManger servicesManger)
//        {
//            _servicesManger = servicesManger;
//        }

//        [HttpPost]
//        public async Task<IActionResult> Create(CreateEquipmentMaintenanceAndRepairRecordDto insertDto)
//        {
//            var insertResult = await _servicesManger.EquipmentMaintenanceAndRepairRecordService.InsertEquipmentMaintenanceAndRepairRecordAsync(insertDto);
//            if (insertResult.Succeeded)
//            {
//                return Ok(insertResult.Result);
//            }
//            return StatusCode(500, insertResult.Errors);
//        }
//        [HttpPost("{id}")]
//        public async Task<IActionResult> Update(UpdateEquipmentMaintenanceAndRepairRecordDto updateDto, long id)
//        {
//            var updateResult = await _servicesManger.EquipmentMaintenanceAndRepairRecordService.UpdateEquipmentMaintenanceAndRepairRecordAsync(updateDto, id);
//            if (updateResult.Succeeded)
//            {
//                return Ok(updateResult.Result);
//            }
//            return StatusCode(500, updateResult.Errors);
//        }
//        [HttpPost("{id}")]
//        public async Task<IActionResult> Delete(long id)
//        {
//            var deleteResult = await _servicesManger.EquipmentMaintenanceAndRepairRecordService.DeleteEquipmentMaintenanceAndRepairRecordAsync(id);
//            if (deleteResult.Succeeded)
//            {
//                return Ok(deleteResult.Result);
//            }
//            return StatusCode(500, deleteResult.Errors);
//        }

//        //[HttpGet]
//        //public async Task<IActionResult> GetList()
//        //{
//        //    var list = await _servicesManger.EquipmentMaintenanceAndRepairRecordService.GetListAsync();
//        //    return Ok(list);
//        //}


//        [HttpPost]
//        public async Task<IActionResult> Index(SqlQueryOptions sqlQueryOptions)
//        {
//            var getResult = await _servicesManger.EquipmentMaintenanceAndRepairRecordService.GetEquipmentMaintenanceAndRepairRecordListAsync(sqlQueryOptions);
//            if (getResult.Succeeded)
//            {
//                return Ok(getResult.Result);
//            }
//            return StatusCode(500, getResult.Errors);
//        }

//        [HttpGet("{id}")]
//        public async Task<IActionResult> GetById(long id)
//        {
//            var getResult = await _servicesManger.EquipmentMaintenanceAndRepairRecordService.GetEquipmentMaintenanceAndRepairRecordByIdAsync(id);
//            if (getResult.Succeeded)
//            {
//                return Ok(getResult.Result);
//            }
//            return StatusCode(500, getResult.Errors);
//        }

//        //[HttpGet]
//        //public async Task<IActionResult> LookUpEquipmentMaintenanceAndRepairRecordForNames([FromQuery] SqlQueryOptions sqlQueryOptions)
//        //{
//        //    var getResult = await _servicesManger.EquipmentMaintenanceAndRepairRecordService.GetLookUpEquipmentMaintenanceAndRepairRecordForNamesAsync(sqlQueryOptions);
//        //    if (getResult.Succeeded)
//        //    {
//        //        return Ok(getResult.Result);
//        //    }
//        //    return StatusCode(500, getResult.Errors);
//        //}

//    }
//}
