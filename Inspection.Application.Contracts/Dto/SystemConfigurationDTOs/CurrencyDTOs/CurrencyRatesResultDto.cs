using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Contracts.Dto.SystemConfigurationDTOs.CurrencyDTOs
{
    public class CurrencyRatesResultDto
    {
        public decimal BaseRate { get; set; } = 1;
        public decimal OfficialRate { get; set; }
        public decimal ReportingRate { get; set; }

        public long BaseCurrencyId { get; set; }
        public long? OfficialCurrencyId { get; set; }
        public long? ReportingCurrencyId { get; set; }
    }
}
