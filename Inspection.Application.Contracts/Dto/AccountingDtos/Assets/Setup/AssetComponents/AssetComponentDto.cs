using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Contracts.Dto.AccountingDtos.Assets.Setup.AssetComponents
{
    public class AssetComponentDto
    {
        public long Id { get; private set; }
        public long CompanyId { get;  set; }
        public string Tenant_ID { get; set; } = string.Empty;

        public long FixedAssetId { get;  set; }

        public string ComponentName { get; set; } = string.Empty;
        public decimal ComponentCost { get; set; }
        public int UsefulLifeMonths { get; set; }
        public decimal ResidualValue { get; set; }

        public long DepreciationMethodId { get; set; }

        public string? Notes { get; set; }

        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }
    }
}