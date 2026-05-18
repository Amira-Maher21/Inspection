//using Inspection.Application.Contracts.Dto.EquipmentManagement.EquipmentsMoreInformations;
//using Inspection.Application.Contracts.Managers;
//using Microsoft.AspNetCore.Mvc;
//using NDS.Shared.Application.DataQuery;

//namespace Inspection.API.Controllers.Controllers.EquipmentManagement.EquipmentsMoreInformations
//{
//    [Route("api/Equipments-EquipmentsMoreInformations/[action]")]
//    [ApiController]
//    public class EquipmentsMoreInformationController : ControllerBase
//    {
//        private readonly IAccountsServicesManger _servicesManger;
//        public EquipmentsMoreInformationController(IAccountsServicesManger servicesManger)
//        {
//            _servicesManger = servicesManger;
//        }
//        [HttpPost]
//        public async Task<IActionResult> Index(SqlQueryOptions sqlQueryOptions)
//        {
//            var getResult = await _servicesManger.EquipmentsMoreInformationService.GetListByIncludeAsync(sqlQueryOptions);
//            if (getResult.Succeeded)
//            {
//                return Ok(getResult.Result);
//            }
//            return StatusCode(500, getResult.Errors);
//        }
//        //[HttpGet]
//        //public async Task<ActionResult<List<InspectorCategoryLookupDefualtDto>>> InspectorCategoryLookupDefualt([FromQuery] SqlQueryOptions sqlQueryOptions)
//        //{
//        //    var result = await _servicesManger.EquipmentsMoreInformationService.EquipmentsMoreInformationLookupDefualt(sqlQueryOptions);
//        //    if (result.Succeeded)
//        //        return Ok(result.Result);
//        //    return StatusCode(500, result.Errors);
//        //}
//        [HttpPost]
//        public async Task<IActionResult> Create([FromBody] CreateEquipmentsMoreInformationDto input)
//        {
//            var result = await _servicesManger.EquipmentsMoreInformationService.CreateAsync(input);
//            if (result.Succeeded)
//                return Ok(result.Result);
//            return StatusCode(500, result.Errors);
//        }

//        [HttpPost("{id}")]
//        public async Task<IActionResult> Update(long id, [FromBody] UpdateEquipmentsMoreInformationDto input)
//        {
//            if (id != input.Id)
//                return BadRequest("ID mismatch");

//            var result = await _servicesManger.EquipmentsMoreInformationService.UpdateAsync(id, input);
//            if (result.Succeeded)
//                return Ok(result.Result);
//            return StatusCode(500, result.Errors);
//        }

//        [HttpPost("{id}")]
//        public async Task<IActionResult> Delete(long id)
//        {
//            var result = await _servicesManger.EquipmentsMoreInformationService.DeleteAsync(id);
//            if (result.Succeeded)
//                return Ok();
//            return StatusCode(500, result.Errors);
//        }

//        [HttpGet("{id}")]
//        public async Task<ActionResult<EquipmentsMoreInformationDto>> GetById(long id)
//        {
//            var result = await _servicesManger.EquipmentsMoreInformationService.GetAsync(id);
//            if (result.Succeeded)
//                return Ok(result.Result);
//            return StatusCode(500, result.Errors);
//        }


//        [HttpGet]
//        public async Task<ActionResult<List<EquipmentsMoreInformationDto>>> GetList()
//        {
//            var result = await _servicesManger.EquipmentsMoreInformationService.GetListAsync();
//            if (result.Succeeded)
//                return Ok(result.Result);
//            return StatusCode(500, result.Errors);
//        }
//    }
//}
