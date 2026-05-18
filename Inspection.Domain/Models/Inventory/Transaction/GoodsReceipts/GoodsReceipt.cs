using Inspection.Domain.Enums.Posting;
using Inspection.Domain.Event;
using Inspection.Domain.Models.Accounting.AccountingSetup.Branches;
using Inspection.Domain.Models.Inventory.InventorySetup;
using Inspection.Domain.Models.Inventory.Transaction.GoodsReceipts.GoodsReceiptLines;
using Inspection.Domain.Models.MenuManagement;
using NDS.Shared.Domain.Contracts;
using NDS.Shared.Domain.Contracts.EntityCommonData;
using NDS.Shared.Domain.Contracts.Multitenant;

namespace Inspection.Domain.Models.Inventory.Transaction.GoodsReceipts
{
    public class GoodsReceipt : IRootEntity, ITenantEntity, IAuditable, IPostingEntity
    {
        public long Id { get; private set; }

        public string GoodsReceiptNo { get; set; }
        public long CompanyId { get; set; }

        public long BranchId { get; private set; }
        public Branch Branch { get; private set; } = null!;
        public long? WarehouseId { get; set; }
        public Warehouse? Warehouse { get; private set; } = null!;



        public DateTime GoodsReceiptDate { get; private set; }

        public string? Notes { get; set; }
        public PostingEnum Posting { get; set; }

        public List<GoodsReceiptLine> GoodsReceiptLines { get; set; } = new List<GoodsReceiptLine>();


        // Series
        public Series Series { get; set; } = null!;
        public long? SeriesId { get; set; }
        public int RunningNumber { get; set; }

        public string Tenant_ID { get; set; } = string.Empty;
        public string In_User { get; set; } = string.Empty;
        public DateTime In_Date { get; set; }
        public string? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }


        public string DocumentCode { get; set; } = "GoodsReceipt";
        public long CurrencyId { get; set; }

        //public DateTime PostingDate { get; set; }
        //public long CurrencyId { get; set; }
        //public decimal TotalDebit { get; set; }
        //public decimal TotalCredit { get; set; }
        //public decimal ExchangeRate { get; set; }

    }
}