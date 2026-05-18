using ClosedXML.Excel;
using Inspection.Application.Contracts.Dto.SharedDtos;

namespace Inspection.Application.Shared.ImportFiles
{
    public class ExcelImportProcessor<T> where T : class
    {
        /// <summary>
        /// Runs the import: reads Excel file, maps each row using profile, returns valid DTOs and failed rows.
        /// </summary>
        /// <param name="file">IFormFile uploaded</param>
        /// <param name="profile">Mapping profile</param>
        /// <returns>Tuple of mapped items, import result, raw rows</returns>
        public async Task<(List<T> MappedItems, ImportResultDto Result, List<Dictionary<string, string>> RawRows)> RunAsync(
            Microsoft.AspNetCore.Http.IFormFile file,
            IImportProfile<T> profile)
        {
            var mappedItems = new List<T>();
            var rawRows = new List<Dictionary<string, string>>();
            var result = new ImportResultDto();

            using var stream = file.OpenReadStream();
            using var workbook = new XLWorkbook(stream);
            var ws = workbook.Worksheets.First();

            var headerRow = ws.FirstRowUsed()?.RowNumber() ?? 1;
            var firstDataRow = headerRow + 1;
            var lastRow = ws.LastRowUsed()?.RowNumber() ?? 0;
            int colCount = profile.ColumnOrder.Count;

            for (int r = firstDataRow; r <= lastRow; r++)
            {
                result.ProcessedCount++;

                var rawRow = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
                for (int c = 0; c < colCount; c++)
                {
                    rawRow[profile.ColumnOrder[c]] = ws.Cell(r, c + 1).GetString().Trim();
                }

                rawRows.Add(rawRow);

                var rowErrors = new List<string>();
                T dto;

                try
                {
                    dto = await profile.MapAsync(rawRow, rowErrors);
                    await profile.ValidateAsync(dto, rawRow, rowErrors);

                    if (rowErrors.Any())
                    {
                        result.FailedRows.Add(new ImportRowErrorDto
                        {
                            RowNumber = r,
                            RawRowData = string.Join(" | ", rawRow.Select(kv => $"{kv.Key}:{kv.Value}")),
                            Errors = rowErrors
                        });
                        continue;
                    }
                }
                catch (Exception ex)
                {
                    rowErrors.Add($"Mapping/Validation exception: {ex.Message}");
                    result.FailedRows.Add(new ImportRowErrorDto
                    {
                        RowNumber = r,
                        RawRowData = string.Join(" | ", rawRow.Select(kv => $"{kv.Key}:{kv.Value}")),
                        Errors = rowErrors
                    });
                    continue;
                }

                mappedItems.Add(dto);
            }

            result.CreatedCount = mappedItems.Count;
            return (mappedItems, result, rawRows);
        }
    }
}