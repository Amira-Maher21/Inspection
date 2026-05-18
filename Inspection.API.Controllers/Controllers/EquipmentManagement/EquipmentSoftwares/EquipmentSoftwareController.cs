//using Inspection.Application.Contracts.Dto.EquipmentManagement.EquipmentSoftwares;
//using Inspection.Application.Contracts.Managers;
//using Microsoft.AspNetCore.Mvc;
//using NDS.Shared.API.ControllersBase;
//using NDS.Shared.Application.DataQuery;

//namespace Inspection.API.Controllers.Controllers.EquipmentManagement.EquipmentSoftwares
//{
  
//    [Route("api/EquipmentSoftware/[action]")]
//    [ApiController]
//    public class EquipmentSoftwareController : InspectionControllerBase
//    {
//        private readonly IAccountsServicesManger _servicesManger;

//        public EquipmentSoftwareController(IAccountsServicesManger servicesManger)
//        {
//            _servicesManger = servicesManger;
//        }

//        [HttpPost]
//        public async Task<IActionResult> Create(CreateEquipmentSoftwareDto insertDto)
//        {
//            var insertResult = await _servicesManger.EquipmentSoftwareService.InsertEquipmentSoftwareAsync(insertDto);
//            if (insertResult.Succeeded)
//            {
//                return Ok(insertResult.Result);
//            }
//            return StatusCode(500, insertResult.Errors);
//        }
//        [HttpPost("{id}")]
//        public async Task<IActionResult> Update(UpdateEquipmentSoftwareDto updateDto, long id)
//        {
//            var updateResult = await _servicesManger.EquipmentSoftwareService.UpdateEquipmentSoftwareAsync(updateDto, id);
//            if (updateResult.Succeeded)
//            {
//                return Ok(updateResult.Result);
//            }
//            return StatusCode(500, updateResult.Errors);
//        }
//        [HttpPost("{id}")]
//        public async Task<IActionResult> Delete(long id)
//        {
//            var deleteResult = await _servicesManger.EquipmentSoftwareService.DeleteEquipmentSoftwareAsync(id);
//            if (deleteResult.Succeeded)
//            {
//                return Ok(deleteResult.Result);
//            }
//            return StatusCode(500, deleteResult.Errors);
//        }

//        //[HttpGet]
//        //public async Task<IActionResult> GetList()
//        //{
//        //    var list = await _servicesManger.EquipmentSoftwareService.GetListAsync();
//        //    return Ok(list);
//        //}


//        [HttpPost]
//        public async Task<IActionResult> Index(SqlQueryOptions sqlQueryOptions)
//        {
//            var getResult = await _servicesManger.EquipmentSoftwareService.GetEquipmentSoftwareListAsync(sqlQueryOptions);
//            if (getResult.Succeeded)
//            {
//                return Ok(getResult.Result);
//            }
//            return StatusCode(500, getResult.Errors);
//        }

//        [HttpGet("{id}")]
//        public async Task<IActionResult> GetById(long id)
//        {
//            var getResult = await _servicesManger.EquipmentSoftwareService.GetEquipmentSoftwareByIdAsync(id);
//            if (getResult.Succeeded)
//            {
//                return Ok(getResult.Result);
//            }
//            return StatusCode(500, getResult.Errors);
//        }

//        //[HttpGet]
//        //public async Task<IActionResult> LookUpEquipmentSoftwareForNames([FromQuery] SqlQueryOptions sqlQueryOptions)
//        //{
//        //    var getResult = await _servicesManger.EquipmentSoftwareService.GetLookUpEquipmentSoftwareForNamesAsync(sqlQueryOptions);
//        //    if (getResult.Succeeded)
//        //    {
//        //        return Ok(getResult.Result);
//        //    }
//        //    return StatusCode(500, getResult.Errors);
//        //}

//    }
//}

