using Inspection.Application.Contracts.Dto.InspectionManagement.InspectionReports;
using Inspection.Application.Contracts.Dto.InspectionManagement.InspectionRequests;
using Inspection.Application.Contracts.Managers;
using Microsoft.AspNetCore.Mvc;
using NDS.Shared.API.ControllersBase;

namespace Inspection.API.Controllers.Controllers.InspectionManagement.InspectionReports
{
    [ApiController]
    [Route("api/inspection-report/[action]")]
    public class InspectionReportController : InspectionControllerBase
    {
         private readonly IAccountsServicesManger _servicesManger;
        public InspectionReportController(IAccountsServicesManger servicesManger)
        {
             _servicesManger = servicesManger;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateInspectionReportDto dto)
        {
            var id = await _servicesManger.InspectionReportService.CreateAsync(dto);
            return Ok(new { Id = id });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var result = await _servicesManger.InspectionReportService.GetByIdAsync(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var result = await _servicesManger.InspectionReportService.GetListAsync();
            return Ok(result);
        }
    }
}
