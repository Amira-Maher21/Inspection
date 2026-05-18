using NDS.Shared.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Contracts.Dto.MenuManagement
{
    public class MenuDto: IRootEntity
    {
        public string Menu_ID { get; set; }
        public string Menu_Name { get; set; }
        public string? Parent_ID { get; set; }
        public string? WebRoute { get; set; }
        public string? Icon { get; set; }
        public string? Program_ID { get; set; }
        public List<MenuDto> SubMenus { get; set; } = new List<MenuDto>();
    }
}
