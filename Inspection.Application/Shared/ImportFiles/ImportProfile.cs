namespace Inspection.Application.Shared.ImportFiles
{
    public abstract class ImportProfile<T> : IImportProfile<T>
    {
        public IReadOnlyList<string> ColumnOrder { get; }

        protected ImportProfile(IReadOnlyList<string> columnOrder)
        {
            ColumnOrder = columnOrder;
        }

        public abstract Task<T> MapAsync(
            Dictionary<string, string> row,
            List<string> errors
        );

        public abstract Task ValidateAsync(
            T dto,
            Dictionary<string, string> row,
            List<string> errors
        );
    }
}