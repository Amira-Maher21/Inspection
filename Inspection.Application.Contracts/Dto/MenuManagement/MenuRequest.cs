using NDS.Shared.Application.DataQuery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Contracts.Dto.MenuManagement
{
    public class MenuRequest
    {
        public SqlQueryOptions SqlQueryOptions { get; set; }
        public object[] FunctionParameters { get; set; }
    }
}
