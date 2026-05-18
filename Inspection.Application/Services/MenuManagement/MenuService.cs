using AutoMapper;
using Inspection.Application.Contracts.Dto.MenuManagement;
using Inspection.Application.Contracts.Managers;
using Inspection.Application.Contracts.Services.MenuManagement;
using Inspection.Application.Contracts.UnitOfWork;
using Inspection.Application.Services.ServicesBase;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Services.MenuManagement
{
    public class MenuService : AccountsServiceBase, IMenuService
    {
        public MenuService(IAccountUnitOfWork accountUoW, IAccountsQueriesManager queriesManager, IMapper mapper, IExceptionManager exceptionManager) : base(accountUoW, queriesManager, mapper, exceptionManager)
        {
        }

        private List<MenuDto> BuildMenuTree(IEnumerable<MenuDto> flatMenuList)
        {
            Dictionary<string, MenuDto> menuMap = flatMenuList.ToDictionary(x => x.Menu_ID);
            List<MenuDto> rootMenus = [];
            foreach (var menu in flatMenuList)
            {
                if(string.IsNullOrEmpty(menu.Parent_ID))
                {
                    rootMenus.Add(menu);
                }
                else if(menuMap.TryGetValue(menu.Parent_ID, out MenuDto parentMenu))
                {
                     parentMenu.SubMenus.Add(menu);
                }
            }
            return rootMenus;
        }
        public async Task<ReturnBase<IEnumerable<MenuDto>>> GetMenuListAsync(MenuRequest requestDto)
        {
            try
            {
                var result = await _queriesManager.Menu.GetMenuListAsync(requestDto);
                if(!result.Succeeded)
                {
                    return ReturnBase<IEnumerable<MenuDto>>.Fail(result.Errors);
                }

                var updatedMenu = BuildMenuTree(result.Result);
            
                return ReturnBase<IEnumerable<MenuDto>>.Success(updatedMenu);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<MenuDto>>.Fail(ex, _exceptionManager);
            }
        }
    }
}
