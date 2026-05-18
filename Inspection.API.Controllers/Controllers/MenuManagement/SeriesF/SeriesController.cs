using Inspection.Application.Contracts.Dto.EquipmentManagement.Series;
using Inspection.Application.Contracts.Managers;
using Microsoft.AspNetCore.Mvc;

namespace Inspection.API.Controllers.Controllers.MenuManagement.SeriesF
{
    [Route("api/setting-Series/[action]")]
    [ApiController]
    public class SeriesController : ControllerBase
    {
        private readonly IAccountsServicesManger _servicesManger;
        public SeriesController(IAccountsServicesManger servicesManger)
        {
            _servicesManger = servicesManger;
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var result = await _servicesManger.SeriesService.GetAsync(id);
            if (result.Succeeded)
                return Ok(result.Result);
            return StatusCode(500, result.Errors);
        }

        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var result = await _servicesManger.SeriesService.GetListAsync();
            if (result.Succeeded)
                return Ok(result.Result);
            return StatusCode(500, result.Errors);
        }


        [HttpGet]
        public async Task<IActionResult> GetSeriesAndNumberAction([FromQuery] string TableName, [FromQuery] string SeriesTableColumn, [FromQuery] string Screen_ID)
        {
            var result = await _servicesManger.SeriesService.GetSeriesAndNumber(TableName, SeriesTableColumn, Screen_ID);
            if (result.Succeeded)
                return Ok(result.Result);
            return StatusCode(500, result.Errors);
        }
        //[HttpGet]
        //public async Task<IActionResult> GetSerialNumber([FromQuery]  string menuid )
        //{
        //    var result = await _servicesManger.SeriesService.GetSerialNumberAsync (menuid );
        //    if (result.Succeeded)
        //        return Ok(result.Result);
        //    return StatusCode(500, result.Errors);
        //}

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateSeriesDto input)
        {
            var result = await _servicesManger.SeriesService.CreateAsync(input);
            if (result.Succeeded)
                return Ok(result.Result);
            return StatusCode(500, result.Errors);
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> Update(long id, [FromBody] UpdateSeriesDto input)
        {
            var result = await _servicesManger.SeriesService.UpdateAsync(id, input);
            if (result.Succeeded)
                return Ok(result.Result);
            return StatusCode(500, result.Errors);
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var result = await _servicesManger.SeriesService.DeleteAsync(id);
            if (result.Succeeded)
                return Ok();
            return StatusCode(500, result.Errors);
        }

        [HttpGet]
        public async Task<IActionResult> GetScreenList()
        {
            var result = await _servicesManger.SeriesService.GetScreenListListAsync();
            if (result.Succeeded)
                return Ok(result.Result);
            return StatusCode(500, result.Errors);
        }

        [HttpGet]
        public async Task<IActionResult> GetSeriesPattern([FromQuery] string screenCode)
        {
            var result = await _servicesManger.SeriesService.GetSeriesPatternByScreenCodeAsync(screenCode);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetMaxCode(
                [FromQuery] string tableName,
                [FromQuery] string fieldName,
                [FromQuery] string groupFieldName = null,
                [FromQuery] string groupFieldValue = null,
                [FromQuery] int paddingLength = 5)
        {
            try
            {
                var result = await _servicesManger.SeriesService.GetMaxCodeAsync(
                   tableName, fieldName, groupFieldName, groupFieldValue, paddingLength
               );

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { ex.Message });
            }
        }

    }
}
