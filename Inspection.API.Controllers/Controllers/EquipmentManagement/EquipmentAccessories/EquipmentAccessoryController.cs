//using Inspection.Application.Contracts.Dto.EquipmentManagement.EquipmentAccessories;
// using Inspection.Application.Contracts.Managers;
//using Microsoft.AspNetCore.Mvc;
//using NDS.Shared.API.ControllersBase;
//using NDS.Shared.Application.DataQuery;

//namespace Inspection.API.Controllers.Controllers.EquipmentManagement.EquipmentAccessories
//{
   
 
//    [Route("api/EquipmentAccessory/[action]")]
//    [ApiController]
//    public class EquipmentAccessoryController : InspectionControllerBase
//    {
//        private readonly IAccountsServicesManger _servicesManger;

//        public EquipmentAccessoryController(IAccountsServicesManger servicesManger)
//        {
//            _servicesManger = servicesManger;
//        }

//        [HttpPost]
//        public async Task<IActionResult> Create(CreateEquipmentAccessoryDto insertDto)
//        {
//            var insertResult = await _servicesManger.EquipmentAccessoriesService.InsertEquipmentAccessoryAsync(insertDto);
//            if (insertResult.Succeeded)
//            {
//                return Ok(insertResult.Result);
//            }
//            return StatusCode(500, insertResult.Errors);
//        }
//        [HttpPost("{id}")]
//        public async Task<IActionResult> Update(UpdateEquipmentAccessoryDto updateDto, long id)
//        {
//            var updateResult = await _servicesManger.EquipmentAccessoriesService.UpdateEquipmentAccessoryAsync(updateDto, id);
//            if (updateResult.Succeeded)
//            {
//                return Ok(updateResult.Result);
//            }
//            return StatusCode(500, updateResult.Errors);
//        }
//        [HttpPost("{id}")]
//        public async Task<IActionResult> Delete(long id)
//        {
//            var deleteResult = await _servicesManger.EquipmentAccessoriesService.DeleteEquipmentAccessoryAsync(id);
//            if (deleteResult.Succeeded)
//            {
//                return Ok(deleteResult.Result);
//            }
//            return StatusCode(500, deleteResult.Errors);
//        }

//        //[HttpGet]
//        //public async Task<IActionResult> GetList()
//        //{
//        //    var list = await _servicesManger.EquipmentAccessoriesService.GetListAsync();
//        //    return Ok(list);
//        //}


//        [HttpPost]
//        public async Task<IActionResult> Index(SqlQueryOptions sqlQueryOptions)
//        {
//            var getResult = await _servicesManger.EquipmentAccessoriesService.GetEquipmentAccessoryListAsync(sqlQueryOptions);
//            if (getResult.Succeeded)
//            {
//                return Ok(getResult.Result);
//            }
//            return StatusCode(500, getResult.Errors);
//        }

//        [HttpGet("{id}")]
//        public async Task<IActionResult> GetById(long id)
//        {
//            var getResult = await _servicesManger.EquipmentAccessoriesService.GetEquipmentAccessoryByIdAsync(id);
//            if (getResult.Succeeded)
//            {
//                return Ok(getResult.Result);
//            }
//            return StatusCode(500, getResult.Errors);
//        }

//        //[HttpGet]
//        //public async Task<IActionResult> LookUpEquipmentAccessoryForNames([FromQuery] SqlQueryOptions sqlQueryOptions)
//        //{
//        //    var getResult = await _servicesManger.EquipmentAccessoriesService.GetLookUpEquipmentAccessoryForNamesAsync(sqlQueryOptions);
//        //    if (getResult.Succeeded)
//        //    {
//        //        return Ok(getResult.Result);
//        //    }
//        //    return StatusCode(500, getResult.Errors);
//        //}

//    }
//}
