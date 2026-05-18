using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspection.Application.Contracts.Dto.AccountingDtos.Assets.Setup.AssetComponents
{
    public class AssetComponentCreateDto
    {
        public long CompanyId { get; set; }
        public long FixedAssetId { get; set; }
        public string ComponentName { get; set; } = string.Empty;
        public decimal ComponentCost { get; set; }
        public int UsefulLifeMonths { get; set; }
        public decimal ResidualValue { get; set; }
        public long DepreciationMethodId { get; set; }
        public string? Notes { get; set; }
    }
}