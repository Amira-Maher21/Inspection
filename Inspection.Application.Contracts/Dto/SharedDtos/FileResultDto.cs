namespace Inspection.Application.Contracts.Dto.SharedDtos
{
    public class FileResultDto
    {
        public byte[] Content { get; set; } = default!;
        public string FileName { get; set; } = string.Empty;
        public string ContentType { get; set; } =
            "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
    }
}