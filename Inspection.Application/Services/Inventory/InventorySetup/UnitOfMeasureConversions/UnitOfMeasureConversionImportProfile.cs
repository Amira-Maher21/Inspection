using Inspection.Application.Contracts.Dto.Inventory.InventorySetup.UnitOfMeasureConversion;
using Inspection.Application.Shared.ImportFiles;

namespace Inspection.Application.Services.Inventory.InventorySetup.UnitOfMeasureConversions
{
    public class UnitOfMeasureConversionImportProfile
        : IImportProfile<UnitOfMeasureConversionCreateDto>
    {
        public IReadOnlyList<string> ColumnOrder { get; }

        public UnitOfMeasureConversionImportProfile()
        {
            ColumnOrder = new List<string>
            {
                "FromUoMId",
                "ToUoMId",
                "ConversionFactor"
            }.AsReadOnly();
        }

        public Task<UnitOfMeasureConversionCreateDto?> MapAsync(
            Dictionary<string, string> row,
            List<string> errors)
        {
            var fromStr = row.GetValueOrDefault("FromUoMId")?.Trim();
            var toStr = row.GetValueOrDefault("ToUoMId")?.Trim();
            var factorStr = row.GetValueOrDefault("ConversionFactor")?.Trim();

            if (!long.TryParse(fromStr, out var fromUoMId))
                errors.Add("FromUoMId must be a valid number.");

            if (!long.TryParse(toStr, out var toUoMId))
                errors.Add("ToUoMId must be a valid number.");

            if (!decimal.TryParse(factorStr, out var conversionFactor))
                errors.Add("ConversionFactor must be a valid decimal number.");

            if (errors.Any())
                return Task.FromResult<UnitOfMeasureConversionCreateDto?>(null);

            return Task.FromResult<UnitOfMeasureConversionCreateDto?>(new UnitOfMeasureConversionCreateDto
            {
                FromUoMId = fromUoMId,
                ToUoMId = toUoMId,
                ConversionFactor = conversionFactor
            });
        }

        public Task ValidateAsync(
            UnitOfMeasureConversionCreateDto dto,
            Dictionary<string, string> row,
            List<string> errors)
        {
            if (dto.FromUoMId <= 0)
                errors.Add("FromUoMId is required.");

            if (dto.ToUoMId <= 0)
                errors.Add("ToUoMId is required.");

            if (dto.FromUoMId == dto.ToUoMId)
                errors.Add("FromUoMId and ToUoMId cannot be the same.");

            if (dto.ConversionFactor <= 0)
                errors.Add("ConversionFactor must be greater than zero.");

            return Task.CompletedTask;
        }
    }
}
