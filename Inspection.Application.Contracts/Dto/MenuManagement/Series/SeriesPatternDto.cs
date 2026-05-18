using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Contracts.Dto.MenuManagement.Series
{
    public class SeriesPatternDto
    {
        public long Id { get; set; }
        public string Pattern { get; set; } = string.Empty;
    }

}
