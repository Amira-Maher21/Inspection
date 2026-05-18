using ClosedXML.Excel;
using System.Reflection;

namespace Inspection.Application.Shared.ExcelTemplate
{
    public sealed class ExcelTemplateGenerator : IExcelTemplateGenerator
    {
        public Task<byte[]> GenerateTemplateAsync<TTemplate>(string sheetName)
            where TTemplate : class, new()
        {
            using var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add(sheetName);

            var properties = typeof(TTemplate)
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(p => !Attribute.IsDefined(p, typeof(ExcelIgnoreAttribute)))
                .ToList();

            for (int i = 0; i < properties.Count; i++)
            {
                worksheet.Cell(1, i + 1).Value = properties[i].Name;
                worksheet.Cell(1, i + 1).Style.Font.Bold = true;
            }

            worksheet.Columns().AdjustToContents();

            using var stream = new MemoryStream();
            workbook.SaveAs(stream);

            return Task.FromResult(stream.ToArray());
        }
    }
}
