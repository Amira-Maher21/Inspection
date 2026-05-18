using Inspection.Application.Contracts.Dto.AccountingDtos.Payments.JournalEntrys;
using Inspection.Application.Shared.ImportFiles;
using System.Globalization;

namespace Inspection.Application.Services.Accounting.Payments.JournalEntrys
{
    public class JournalEntryImportProfile : IImportProfile<JournalEntryCreateDto>
    {
        public IReadOnlyList<string> ColumnOrder { get; }

        public JournalEntryImportProfile()
        {
            ColumnOrder = new List<string>
            {
                "JournalNo",
                "FiscalYearCode",
                "JournalDate",
                "PostingDate",
                "BranchCode",
                "CurrencyCode",
                "JournalEntryTemplateNumber",
                "IsReverseJournal",
                "ReversalOfJournalEntryId",
                "TotalDebit",
                "TotalCredit",
                "ReferenceNumber",
                "ReferenceDate",
                "BillNo",
                "BillDate",
                "DueDate",
                "ModeOfPaymentCode",
                "DocumentStatus",
                "ApprovalStatus",
                "Description"
            }.AsReadOnly();
        }

        public Task<JournalEntryCreateDto> MapAsync(
            Dictionary<string, string> row,
            List<string> errors)
        {
            var dto = new JournalEntryCreateDto
            {
                JournalNo = row.GetValueOrDefault("JournalNo") ?? string.Empty,

                JournalDate = ParseDate(row.GetValueOrDefault("JournalDate")),
                PostingDate = ParseDate(row.GetValueOrDefault("PostingDate")),

                TotalDebit = ParseDecimal(row.GetValueOrDefault("TotalDebit")),
                TotalCredit = ParseDecimal(row.GetValueOrDefault("TotalCredit")),

                ReferenceNumber = row.GetValueOrDefault("ReferenceNumber") ?? string.Empty,
                ReferenceDate = ParseNullableDate(row.GetValueOrDefault("ReferenceDate")),

                //BillNo = row.GetValueOrDefault("BillNo") ?? string.Empty,
                //BillDate = ParseNullableDate(row.GetValueOrDefault("BillDate")),

                //DueDate = ParseNullableDate(row.GetValueOrDefault("DueDate")),

                IsReverseJournal = ParseNullableBool(row.GetValueOrDefault("IsReverseJournal")),
                ReversalOfJournalEntryId = ParseNullableLong(row.GetValueOrDefault("ReversalOfJournalEntryId")),

                Description = Normalize(row.GetValueOrDefault("Description")) ?? string.Empty
            };

            return Task.FromResult(dto);
        }

        public Task ValidateAsync(
            JournalEntryCreateDto dto,
            Dictionary<string, string> row,
            List<string> errors)
        {
            if (string.IsNullOrWhiteSpace(dto.JournalNo))
                errors.Add("JournalNo is required.");

            if (dto.JournalDate == default)
                errors.Add("JournalDate is required.");

            if (dto.PostingDate == default)
                errors.Add("PostingDate is required.");

            if (dto.TotalDebit <= 0 && dto.TotalCredit <= 0)
                errors.Add("TotalDebit or TotalCredit must be greater than zero.");

            if (string.IsNullOrWhiteSpace(row.GetValueOrDefault("FiscalYearCode")))
                errors.Add("FiscalYearCode is required.");

            if (string.IsNullOrWhiteSpace(row.GetValueOrDefault("BranchCode")))
                errors.Add("BranchCode is required.");

            if (string.IsNullOrWhiteSpace(row.GetValueOrDefault("CurrencyCode")))
                errors.Add("CurrencyCode is required.");

            return Task.CompletedTask;
        }

        private static string? Normalize(string? value)
            => string.IsNullOrWhiteSpace(value) ? null : value.Trim();

        private static bool ParseBool(string? value, bool defaultValue = false)
        {
            if (string.IsNullOrWhiteSpace(value)) return defaultValue;
            return value.Trim().ToLowerInvariant() is "1" or "true" or "yes" or "y";
        }

        private static bool? ParseNullableBool(string? value)
        {
            if (string.IsNullOrWhiteSpace(value)) return null;
            return ParseBool(value);
        }

        private static DateTime ParseDate(string? value)
        {
            if (DateTime.TryParse(value, out var result))
                return result;

            return default;
        }

        private static DateTime? ParseNullableDate(string? value)
        {
            if (DateTime.TryParse(value, out var result))
                return result;

            return null;
        }

        private static decimal ParseDecimal(string? value)
        {
            if (decimal.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out var result))
                return result;

            return 0;
        }

        private static long? ParseNullableLong(string? value)
        {
            if (long.TryParse(value, out var result))
                return result;

            return null;
        }
    }
}