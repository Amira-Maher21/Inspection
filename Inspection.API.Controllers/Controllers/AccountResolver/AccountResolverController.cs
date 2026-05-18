using Inspection.Application.Contracts.Dto.AccountingDtos.AccountingSetupDtos.FiscalYearDTOs;
using Inspection.Application.Contracts.Managers;
using Inspection.Domain.Enums.AccountResolver;
using Inspection.Domain.Models.AccountResolution;
using Microsoft.AspNetCore.Mvc;
using NDS.Shared.API.ControllersBase;
using NDS.Shared.Application.DataQuery;

namespace Inspection.API.Controllers.Controllers.AccountResolver
{
    [Route("api/AccountResolver/[action]")]
    [ApiController]
    public class AccountResolverController : InspectionControllerBase
    {
        private readonly IAccountsServicesManger _servicesManger;

        public AccountResolverController(IAccountsServicesManger servicesManger)
        {
            _servicesManger = servicesManger;
        }

        [HttpPost]
        public async Task<IActionResult> GetAccountId(AccountResolverContext context)
        {
            var result = await _servicesManger.AccountResolverService
                .TryResolveAsync(context);

            if (result == null)
            {
                return NotFound(new
                {
                    Message = "No account found for given context and purpose."
                });
            }

            return Ok(result);
        }

    }
}