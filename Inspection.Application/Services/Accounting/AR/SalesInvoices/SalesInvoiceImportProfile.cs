using Inspection.Application.Contracts.Dto.AccountingDtos.AR.SalesInvoices;
using Inspection.Application.Shared.ImportFiles;
using Inspection.Domain.Enums.Posting;

namespace Inspection.Application.Services.Accounting.AR.SalesInvoices
{

    public class SalesInvoiceImportProfile : IImportProfile<SalesInvoiceCreateDto>
    {
        public IReadOnlyList<string> ColumnOrder { get; }

        public SalesInvoiceImportProfile()
        {
            ColumnOrder = new List<string>
            {
                "CompanyId",
                "BranchCode",
                "CustomerCode",
                "InvoiceDate",
                "PaymentDueDate",
                "CurrencyCode",
                "PaymentTermsCode",
                "TotalAmount",
                "TaxAmount",
                "NetAmount",
                "Posting",
                "Notes",
                "CustomersPurchaseOrder",
                "CustomersPurchaseOrderDate"
            }.AsReadOnly();
        }

        public Task<SalesInvoiceCreateDto> MapAsync(
            Dictionary<string, string> row,
            List<string> errors)
        {
            var dto = new SalesInvoiceCreateDto
            {

                CompanyId = long.TryParse(row.GetValueOrDefault("CompanyId"), out var cid) ? cid : 0,
                InvoiceDate = ParseDate(row, "InvoiceDate"),
                PaymentDuesDate = ParseDate(row, "PaymentDueDate"),
                TotalAmount = ParseDecimal(row, "TotalAmount"),
                NetAmount = ParseDecimal(row, "NetAmount"),
                TaxAmount = ParseNullableDecimal(row, "TaxAmount"),

                Posting = ParseEnum<PostingEnum>(row, "Posting"),

                Notes = row.GetValueOrDefault("Notes")?.Trim(),

                CustomersPurchaseOrder = row.GetValueOrDefault("CustomersPurchaseOrder"),

                CustomersPurchaseOrderDate = ParseNullableDate(row, "CustomersPurchaseOrderDate"),

                // Default
                ApprovalStatus = 0
            };

            return Task.FromResult(dto);
        }

        public Task ValidateAsync(
            SalesInvoiceCreateDto dto,
            Dictionary<string, string> row,
            List<string> errors)
        {


            if (dto.InvoiceDate == default)
                errors.Add("InvoiceDate is required.");

            if (dto.PaymentDuesDate == default)
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
            return decimal.TryParse(row.GetValueOrDefault(key), out var value)
                ? value
                : 0;
        }

        private decimal? ParseNullableDecimal(Dictionary<string, string> row, string key)
        {
            return decimal.TryParse(row.GetValueOrDefault(key), out var value)
                ? value
                : null;
        }

        private DateTime ParseDate(Dictionary<string, string> row, string key)
        {
            return DateTime.TryParse(row.GetValueOrDefault(key), out var value)
                ? value
                : default;
        }

        private DateTime? ParseNullableDate(Dictionary<string, string> row, string key)
        {
            return DateTime.TryParse(row.GetValueOrDefault(key), out var value)
                ? value
                : null;
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