namespace Inspection.Application.Contracts.Dto.SharedDtos
{
    public class ImportResultDto
    {
        public int ProcessedCount { get; set; } = 0;
        public int CreatedCount { get; set; } = 0;
        public List<ImportRowErrorDto> FailedRows { get; set; } = new List<ImportRowErrorDto>();
    }

    public class ImportRowErrorDto
    {
        public int RowNumber { get; set; }
        public string RawRowData { get; set; } = string.Empty;
        public List<string> Errors { get; set; } = new List<string>();
    }
}