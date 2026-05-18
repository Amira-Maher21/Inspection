using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Contracts.Dto.LocalizationDto
{
    public class CreateLocalizationDto
    {
        public string Translate { get; set; } = null!;
        public string LocaleCode { get; set; } = null!;
        public string? Caption { get; set; }
        public string? Tooltip { get; set; }
        public bool? System { get; set; }
    }
}
