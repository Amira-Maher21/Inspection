using Inspection.Domain.Enums.AccountResolver;
using Inspection.Domain.Models.AccountResolution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Contracts.Services.AccountResolution
{
    public interface IAccountResolverService
    {

        //bool CanResolve(AccountResolverPurpose purpose, AccountResolverContext context);

        Task<AccountResolutionResult?> TryResolveAsync(AccountResolverContext context);
    }
}
