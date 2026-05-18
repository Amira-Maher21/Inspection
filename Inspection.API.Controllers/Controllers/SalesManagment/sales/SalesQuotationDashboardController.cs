using Inspection.Application.Contracts.Dto.SalesManagment.sales.SalesQuotationF.SalesQuotationDashboard;
using Inspection.Application.Contracts.Managers;
using Microsoft.AspNetCore.Mvc;
using NDS.Shared.API.ControllersBase;

namespace Inspection.API.Controllers.Controllers.SalesManagment.sales
{
    [Route("api/sales-dashboard/[action]")]
    [ApiController]
    public class SalesQuotationDashboardController : InspectionControllerBase
    {
        private readonly IAccountsServicesManger _servicesManger;

        public SalesQuotationDashboardController(
            IAccountsServicesManger servicesManger)
        {
            _servicesManger = servicesManger;
        }

        [HttpPost]
        public async Task<IActionResult> GetDashboard(
            [FromBody] SalesQuotationDashboardFilterDto filter)
        {
            var result = await _servicesManger
                .ISalesQuotationDashboardService
                .GetDashboardAsync(filter);

            if (result.Succeeded)
                return Ok(result.Result);

            return StatusCode(500, result.Errors);
        }
    }
}
