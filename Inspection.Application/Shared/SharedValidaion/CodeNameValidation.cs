using System.Text.RegularExpressions;

namespace Inspection.Application.Shared.SharedValidation
{
    public static class ValidationExtensions
    {
        private static readonly Regex _containsLetterRegex =
            new Regex(@".*[a-zA-Z\u0600-\u06FF].*", RegexOptions.Compiled);

        private static readonly Regex _containsLetterOrDigitRegex =
           new Regex(@".*[a-zA-Z\u0600-\u06FF0-9].*", RegexOptions.Compiled);

        public static void ValidateAsCode(this string? code)
        {

            if (string.IsNullOrWhiteSpace(code) || !_containsLetterOrDigitRegex.IsMatch(code))
            {
                throw new BusinessException("Busniss Error Code must contain at least one English or Arabic letter");
            }
        }

        public static void ValidateAsName(this string? name)
        {
            if (string.IsNullOrWhiteSpace(name) || !_containsLetterRegex.IsMatch(name))
            {
                throw new BusinessException(

                    "Busniss Error Name must contain at least one English or Arabic letter"
                );
            }
        }
    }
}