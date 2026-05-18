using Inspection.Application.Contracts.Dto.AccountingDtos.PR.PurchaseInvoices;
using Inspection.Application.Shared.ImportFiles;
using Inspection.Domain.Enums.Accounting.AR.SalesInvoices;
using Inspection.Domain.Enums.Posting;

namespace Inspection.Application.Services.Accounting.PR.PurchaseInvoices
{
    public class PurchaseInvoiceImportProfile : IImportProfile<PurchaseInvoiceCreateDto>
    {
        public IReadOnlyList<string> ColumnOrder { get; }

        public PurchaseInvoiceImportProfile()
        {
            ColumnOrder = new List<string>
            {
                "CompanyId",
                "BranchCode",
                "SupplierCode",
                "InvoiceDate",
                "PaymentDueDate",
                "CurrencyCode",
                "PaymentTermsCode",
                "TotalAmount",
                "TaxAmount",
                "NetAmount",
                "Posting",
                 "Notes",
                "WarehouseCode",
                "SalesPersonCode",
                "SalesOrderCode",
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

        public Task<PurchaseInvoiceCreateDto> MapAsync(
            Dictionary<string, string> row,
            List<string> errors)
        {
            var dto = new PurchaseInvoiceCreateDto
            {
                CompanyId = ParseLong(row, "CompanyId"),
                InvoiceDate = ParseDate(row, "InvoiceDate"),
                PaymentDueDate = ParseDate(row, "PaymentDueDate"),

                TotalAmount = ParseDecimal(row, "TotalAmount"),
                NetAmount = ParseDecimal(row, "NetAmount"),
                TaxAmount = ParseNullableDecimal(row, "TaxAmount"),

                Posting = ParseEnum<PostingEnum>(row, "Posting") ?? default(PostingEnum),

                Notes = row.GetValueOrDefault("Notes")?.Trim(),



                AdditionalDiscountType = ParseEnum<AdditionalDiscountType>(row, "AdditionalDiscountType"),
                AdditionalDiscountValue = ParseNullableDecimal(row, "AdditionalDiscountValue"),
                AdditionalDiscountAmount = ParseNullableDecimal(row, "AdditionalDiscountAmount"),
                ShipmentAmount = ParseNullableDecimal(row, "ShipmentAmount"),
                ShipmentAddress = row.GetValueOrDefault("ShipmentAddress")?.Trim(),
                ShipmentStatus = ParseEnum<ShipmentStatus>(row, "ShipmentStatus"),
                ShipmentMethod = ParseEnum<ShipmentMethod>(row, "ShipmentMethod"),
                TotalDiscount = ParseNullableDecimal(row, "TotalDiscount"),

                // Default
                ApprovalStatus = 0
            };

            return Task.FromResult(dto);
        }

        public Task ValidateAsync(
            PurchaseInvoiceCreateDto dto,
            Dictionary<string, string> row,
            List<string> errors)
        {
            if (dto.CompanyId <= 0)
                errors.Add("CompanyId is required.");

            if (dto.InvoiceDate == default)
                errors.Add("InvoiceDate is required.");

            if (dto.PaymentDueDate == default)
                errors.Add("PaymentDueDate is required.");

            if (dto.TotalAmount <= 0)
                errors.Add("TotalAmount must be greater than zero.");

            if (dto.NetAmount < 0)
                errors.Add("NetAmount cannot be negative.");

            return Task.CompletedTask;
        }

        // ================= Helpers =================

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
            return Enum.TryParse<TEnum>(row.GetValueOrDefault(key), true, out var value) ? value : null;
        }
    }
}