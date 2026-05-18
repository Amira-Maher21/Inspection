namespace Inspection.Application.Shared.ImportFiles
{
    public interface IImportProfile<T>
    {
        // Order of columns coming from the Frontend (kept original).
        IReadOnlyList<string> ColumnOrder { get; }

        // Maps raw string values (from Excel row) into a CreateDto.
        Task<T> MapAsync(Dictionary<string, string> row, List<string> errors);

        // Performs validation for each row after mapping.
        Task ValidateAsync(T dto, Dictionary<string, string> row, List<string> errors);
    }
}