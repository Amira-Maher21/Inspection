using Microsoft.AspNetCore.Http;

namespace Inspection.Application.Contracts.Dto.SharedDtos
{
    public class ExcelImportRequestDto
    {
        // Excel file uploaded by user (.xlsx)
        public IFormFile File { get; set; } = default!;

        // Column ordering exactly as uploaded from UI
        public List<string> ColumnOrder { get; set; } = new();

        // Optional: custom header names in the Excel file (in same order),
        // useful for client-side display/preview only. Backend ignores them for mapping.
        public List<string>? CustomHeaderNames { get; set; }
    }
}