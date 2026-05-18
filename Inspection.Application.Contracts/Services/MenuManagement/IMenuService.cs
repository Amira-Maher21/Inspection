using Inspection.Application.Contracts.Dto.MenuManagement;
using NDS.Shared.Kernel.BaseReturnTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Contracts.Services.MenuManagement
{
    public interface IMenuService: IAccountServiceBase
    {
        Task<ReturnBase<IEnumerable<MenuDto>>> GetMenuListAsync(MenuRequest requestDto);
    }
}
