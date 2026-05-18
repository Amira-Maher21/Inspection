namespace Inspection.API.Controllers.Extensions
{
    public static class ValidationExtensions
    {
        public static List<Models.ValidationError> GetValidationErrors(this FluentValidation.Results.ValidationResult validationResult)
        {
            var errors = new List<Models.ValidationError>();
            foreach (var failure in validationResult.Errors)
            {
                errors.Add(new Models.ValidationError
                {
                    Field = failure.PropertyName,
                    ErrorMessage = failure.ErrorMessage
                });
            }
            return errors;
        }
    }
}