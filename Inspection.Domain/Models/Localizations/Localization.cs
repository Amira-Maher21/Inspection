using NDS.Shared.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Domain.Models.Localizations
{
    public class Localization: IRootEntity
    {
        public string Translate { get; set; } = null!;
        public string LocaleCode { get; set; } = null!;
        public string? Caption { get; set; }
        public string? Tooltip { get; set; }
        public bool? System { get; set; }
    }
}
