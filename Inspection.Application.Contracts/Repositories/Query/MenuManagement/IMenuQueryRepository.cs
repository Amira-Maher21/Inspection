using Inspection.Application.Contracts.Dto.MenuManagement;
using Inspection.Domain.Models.MenuManagement;
using NDS.Shared.Kernel.BaseReturnTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Contracts.Repositories.Query.MenuManagement
{
    public interface IMenuQueryRepository
    {
        //Task<Menu?> GetSerialNumberByIdAsync(string id);
        Task<Menu?> GetByIdAsync(string id);

        Task<ReturnBase<IEnumerable<MenuDto>>> GetMenuListAsync(MenuRequest requestDto);

    }
}
