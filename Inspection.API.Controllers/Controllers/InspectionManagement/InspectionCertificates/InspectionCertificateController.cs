using Inspection.Application.Contracts.Dto.InspectionManagement.InspectionCertificates;
using Inspection.Application.Contracts.Managers;
using Microsoft.AspNetCore.Mvc;
using NDS.Shared.API.ControllersBase;
using NDS.Shared.Application.DataQuery;

namespace Inspection.API.Controllers.Controllers.InspectionManagement.InspectionCertificates
{

    //    private readonly IAccountsServicesManger _servicesManger;

    //    public InspectionCertificateController(IAccountsServicesManger servicesManger)
    //    {
    //        _servicesManger = servicesManger;
    //    }

    //    [HttpPost]
    //    public async Task<IActionResult> Create([FromBody] InspectionCertificateCreateDto input)
    //    {
    //        var result = await _servicesManger.InspectionCertificateService.CreateAsync(input);
    //        if (result.Succeeded)
    //            return Ok(result.Result);

    //        return StatusCode(500, result.Errors);
    //    }

    //    [HttpPost("{id}")]
    //    public async Task<IActionResult> Update(long id, [FromBody] InspectionCertificateUpdateDto input)
    //    {
    //        if (id != input.Id)
    //            return BadRequest("ID mismatch");

    //        var result = await _servicesManger.InspectionCertificateService.UpdateAsync(id, input);
    //        if (result.Succeeded)
    //            return Ok(result.Result);

    //        return StatusCode(500, result.Errors);
    //    }

    //    [HttpPost("{id}")]
    //    public async Task<IActionResult> Delete(long id)
    //    {
    //        var result = await _servicesManger.InspectionCertificateService.DeleteAsync(id);
    //        if (result.Succeeded)
    //            return Ok();

    //        return StatusCode(500, result.Errors);
    //    }

    //    [HttpGet("{id}")]
    //    public async Task<ActionResult<InspectionCertificateDto>> GetById(long id)
    //    {
    //        var result = await _servicesManger.InspectionCertificateService.GetAsync(id);
    //        if (result.Succeeded)
    //            return Ok(result.Result);

    //        return StatusCode(500, result.Errors);
    //    }

    //    [HttpGet]
    //    public async Task<ActionResult<List<InspectionCertificateDto>>> GetList()
    //    {
    //        var result = await _servicesManger.InspectionCertificateService.GetListAsync();
    //        if (result.Succeeded)
    //            return Ok(result.Result);

    //        return StatusCode(500, result.Errors);
    //    }
    //    [HttpPost]
    //    public async Task<ActionResult<List<InspectionCertificateDtoByInclude>>> Index(SqlQueryOptions sqlQueryOptions)
    //    {
    //        var result = await _servicesManger.InspectionCertificateService.GetListByIncludeAsync(sqlQueryOptions);
    //        if (result.Succeeded)
    //            return Ok(result.Result);

    //        return StatusCode(500, result.Errors);
    //    }
    //}


    //////
    ///using Inspection.Application.Contracts.Dto.InspectionManagement.InspectionCertificates;



    [ApiController]
    [Route("api/Inspection-Certificate/[action]")]
    public class InspectionCertificateController : InspectionControllerBase
    {
        private readonly IAccountsServicesManger _servicesManger;
        public InspectionCertificateController(IAccountsServicesManger servicesManger)
        {
            _servicesManger = servicesManger;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var result = await _servicesManger.InspectionCertificateService.GetAsync(id);
            if (result.Succeeded)
                return Ok(result.Result);
            return StatusCode(500, result.Errors);
        }
        [HttpPost]
        public async Task<IActionResult> Index(SqlQueryOptions sqlQueryOptions)
        {
            var getResult = await _servicesManger.InspectionCertificateService.GetListByIncludeAsync(sqlQueryOptions);
            if (getResult.Succeeded)
            {
                return Ok(getResult.Result);
            }
            return StatusCode(500, getResult.Errors);
        }

        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var result = await _servicesManger.InspectionCertificateService.GetListAsync();
            if (result.Succeeded)
                return Ok(result.Result);
            return StatusCode(500, result.Errors);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] InspectionCertificateCreateDto input)
        {
            var result = await _servicesManger.InspectionCertificateService.CreateAsync(input);
            if (result.Succeeded)
                return Ok(result.Result);
            return StatusCode(500, result.Errors);
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> Update(long id, [FromBody] InspectionCertificateUpdateDto input)
        {
            var result = await _servicesManger.InspectionCertificateService.UpdateAsync(id, input);
            if (result.Succeeded)
                return Ok(result.Result);
            return StatusCode(500, result.Errors);
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var result = await _servicesManger.InspectionCertificateService.DeleteAsync(id);
            if (result.Succeeded)
                return Ok();
            return StatusCode(500, result.Errors);
        }



    }
}

