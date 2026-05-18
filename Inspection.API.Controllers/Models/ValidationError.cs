namespace Inspection.API.Controllers.Models
{
    public class ValidationError
    {
        public string Field { get; set; } = string.Empty;
        public string ErrorMessage { get; set; } = string.Empty;
    }
}