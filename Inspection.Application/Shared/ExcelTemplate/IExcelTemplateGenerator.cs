namespace Inspection.Application.Shared.ExcelTemplate
{
    public interface IExcelTemplateGenerator
    {
        Task<byte[]> GenerateTemplateAsync<TTemplate>(string sheetName)
            where TTemplate : class, new();
    }
}