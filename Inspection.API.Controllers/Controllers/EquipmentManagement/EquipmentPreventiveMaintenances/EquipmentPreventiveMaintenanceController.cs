//using Inspection.Application.Contracts.Dto.EquipmentManagement.EquipmentPreventiveMaintenances;
//using Inspection.Application.Contracts.Managers;
//using Microsoft.AspNetCore.Mvc;
//using NDS.Shared.API.ControllersBase;
//using NDS.Shared.Application.DataQuery;

//namespace Inspection.API.Controllers.Controllers.EquipmentManagement.EquipmentPreventiveMaintenances
//{
 

//    [Route("api/EquipmentPreventiveMaintenance/[action]")]
//    [ApiController]
//    public class EquipmentPreventiveMaintenanceController : InspectionControllerBase
//    {
//        private readonly IAccountsServicesManger _servicesManger;

//        public EquipmentPreventiveMaintenanceController(IAccountsServicesManger servicesManger)
//        {
//            _servicesManger = servicesManger;
//        }

//        [HttpPost]
//        public async Task<IActionResult> Create(CreateEquipmentPreventiveMaintenanceDto insertDto)
//        {
//            var insertResult = await _servicesManger.EquipmentPreventiveMaintenanceService.InsertEquipmentPreventiveMaintenanceAsync(insertDto);
//            if (insertResult.Succeeded)
//            {
//                return Ok(insertResult.Result);
//            }
//            return StatusCode(500, insertResult.Errors);
//        }
//        [HttpPost("{id}")]
//        public async Task<IActionResult> Update(UpdateEquipmentPreventiveMaintenanceDto updateDto, long id)
//        {
//            var updateResult = await _servicesManger.EquipmentPreventiveMaintenanceService.UpdateEquipmentPreventiveMaintenanceAsync(updateDto, id);
//            if (updateResult.Succeeded)
//            {
//                return Ok(updateResult.Result);
//            }
//            return StatusCode(500, updateResult.Errors);
//        }
//        [HttpPost("{id}")]
//        public async Task<IActionResult> Delete(long id)
//        {
//            var deleteResult = await _servicesManger.EquipmentPreventiveMaintenanceService.DeleteEquipmentPreventiveMaintenanceAsync(id);
//            if (deleteResult.Succeeded)
//            {
//                return Ok(deleteResult.Result);
//            }
//            return StatusCode(500, deleteResult.Errors);
//        }

//        //[HttpGet]
//        //public async Task<IActionResult> GetList()
//        //{
//        //    var list = await _servicesManger.EquipmentPreventiveMaintenanceService.GetListAsync();
//        //    return Ok(list);
//        //}


//        [HttpPost]
//        public async Task<IActionResult> Index(SqlQueryOptions sqlQueryOptions)
//        {
//            var getResult = await _servicesManger.EquipmentPreventiveMaintenanceService.GetEquipmentPreventiveMaintenanceListAsync(sqlQueryOptions);
//            if (getResult.Succeeded)
//            {
//                return Ok(getResult.Result);
//            }
//            return StatusCode(500, getResult.Errors);
//        }

//        [HttpGet("{id}")]
//        public async Task<IActionResult> GetById(long id)
//        {
//            var getResult = await _servicesManger.EquipmentPreventiveMaintenanceService.GetEquipmentPreventiveMaintenanceByIdAsync(id);
//            if (getResult.Succeeded)
//            {
//                return Ok(getResult.Result);
//            }
//            return StatusCode(500, getResult.Errors);
//        }

//        //[HttpGet]
//        //public async Task<IActionResult> LookUpEquipmentPreventiveMaintenanceForNames([FromQuery] SqlQueryOptions sqlQueryOptions)
//        //{
//        //    var getResult = await _servicesManger.EquipmentPreventiveMaintenanceService.GetLookUpEquipmentPreventiveMaintenanceForNamesAsync(sqlQueryOptions);
//        //    if (getResult.Succeeded)
//        //    {
//        //        return Ok(getResult.Result);
//        //    }
//        //    return StatusCode(500, getResult.Errors);
//        //}

//    }
//}
