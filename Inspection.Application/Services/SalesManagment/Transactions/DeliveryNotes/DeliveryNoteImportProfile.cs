using Inspection.Application.Contracts.Dto.SalesManagment.sales.Transactions.DeliveryNotes;
using Inspection.Application.Shared.ImportFiles;
using Inspection.Domain.Enums.Accounting.AR.SalesInvoices;
using Inspection.Domain.Enums.Posting;

namespace Inspection.Application.Services.SalesManagment.Transactions.DeliveryNotes
{
    public class DeliveryNoteImportProfile : IImportProfile<DeliveryNoteCreateDto>
    {
        public IReadOnlyList<string> ColumnOrder { get; }

        public DeliveryNoteImportProfile()
        {
            ColumnOrder = new List<string>
                {
                "CompanyId",
                "BranchCode",
                "CustomerCode",
                "DeliveryNoteDate",
                "CurrencyCode",
                "PaymentTermsCode",
                "TotalAmount",
                "TaxAmount",
                "NetAmount",
                "Posting",
                "Notes",
                "WarehouseCode",
                "SalesOrderCode",
                "CustomerPurchaseOrder",
                "CustomerPurchaseOrderDate",
                "DeliveryPersonName",
                "AdditionalDiscountType",
                "AdditionalDiscountValue",
                "AdditionalDiscountAmount",
                "ShipmentAmount",
                "ShipmentAddress",
                "ShipmentStatus",
                "ShipmentMethod",
                "TotalDiscount"
            }.AsReadOnly();
        }

        public Task<DeliveryNoteCreateDto> MapAsync(
     Dictionary<string, string> row,
     List<string> errors)
        {
            var dto = new DeliveryNoteCreateDto
            {
                CompanyId = ParseLong(row, "CompanyId"),
                DeliveryNoteDate = ParseDate(row, "DeliveryNoteDate"),

                TotalAmount = ParseDecimal(row, "TotalAmount"),
                NetAmount = ParseDecimal(row, "NetAmount"),
                TaxAmount = ParseNullableDecimal(row, "TaxAmount"),

                Posting = ParseEnum<PostingEnum>(row, "Posting") ?? default,

                Notes = row.GetValueOrDefault("Notes")?.Trim(),

                CustomerPurchaseOrder = row.GetValueOrDefault("CustomerPurchaseOrder")?.Trim(),
                CustomerPurchaseOrderDate = ParseNullableDate(row, "CustomerPurchaseOrderDate"),

                DeliveryPersonName = row.GetValueOrDefault("DeliveryPersonName")?.Trim(),

                AdditionalDiscountType = ParseEnum<AdditionalDiscountType>(row, "AdditionalDiscountType"),
                AdditionalDiscountValue = ParseNullableDecimal(row, "AdditionalDiscountValue"),
                AdditionalDiscountAmount = ParseNullableDecimal(row, "AdditionalDiscountAmount"),

                ShipmentAmount = ParseNullableDecimal(row, "ShipmentAmount"),
                ShipmentAddress = row.GetValueOrDefault("ShipmentAddress")?.Trim(),
                ShipmentMethod = ParseEnum<ShipmentMethod>(row, "ShipmentMethod") ?? default,
                ShipmentStatus = ParseEnum<ShipmentStatus>(row, "ShipmentStatus") ?? default,

                TotalDiscount = ParseNullableDecimal(row, "TotalDiscount"),

                ApprovalStatus = 0
            };

            return Task.FromResult(dto);
        }

        public Task ValidateAsync(
            DeliveryNoteCreateDto dto,
            Dictionary<string, string> row,
            List<string> errors)
        {
            if (dto.CompanyId <= 0)
                errors.Add("CompanyId is required.");

            if (dto.DeliveryNoteDate == default)
                errors.Add("DeliveryNoteDate is required.");

            if (dto.TotalAmount <= 0)
                errors.Add("TotalAmount must be greater than zero.");

            if (dto.NetAmount < 0)
                errors.Add("NetAmount cannot be negative.");


            return Task.CompletedTask;
        }

        // ================= Helpers =================
        private DateTime? ParseNullableDate(Dictionary<string, string> row, string key)
        {
            return DateTime.TryParse(row.GetValueOrDefault(key), out var value) ? value : null;
        }
        private decimal ParseDecimal(Dictionary<string, string> row, string key)
        {
            return decimal.TryParse(row.GetValueOrDefault(key), out var value) ? value : 0;
        }

        private decimal? ParseNullableDecimal(Dictionary<string, string> row, string key)
        {
            return decimal.TryParse(row.GetValueOrDefault(key), out var value) ? value : null;
        }

        private long ParseLong(Dictionary<string, string> row, string key)
        {
            return long.TryParse(row.GetValueOrDefault(key), out var value) ? value : 0;
        }

        private DateTime ParseDate(Dictionary<string, string> row, string key)
        {
            return DateTime.TryParse(row.GetValueOrDefault(key), out var value) ? value : default;
        }

        private TEnum? ParseEnum<TEnum>(Dictionary<string, string> row, string key)
            where TEnum : struct
        {
            return Enum.TryParse<TEnum>(row.GetValueOrDefault(key), true, out var value)
                ? value
                : null;
        }
    }
}