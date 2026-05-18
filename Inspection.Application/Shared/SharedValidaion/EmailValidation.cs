using global::Inspection.Application.Shared.GlobalExceptionHandler;
using System.Text.RegularExpressions;

namespace Inspection.Application.Shared.SharedValidaion
{
    //public static class EmailValidator
    //{
    //    private const int MaxLength = 200;
    //    private static readonly Regex EmailRegex =
    //        new(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.Compiled);

    //    public static List<ReturnBaseError> Validate(string email)
    //    {
    //        var errors = new List<ReturnBaseError>();

    //        if (string.IsNullOrWhiteSpace(email))
    //        {
    //            errors.Add(new ReturnBaseError
    //            {
    //                ErrorCode = "400",
    //                ErrorMessage = "Email is required"
    //            });
    //        }
    //        else
    //        {
    //            if (email.Length > MaxLength)
    //                errors.Add(new ReturnBaseError
    //                {
    //                    ErrorCode = "400",
    //                    ErrorMessage = $"Email max length is {MaxLength}"
    //                });

    //            if (!EmailRegex.IsMatch(email))
    //                errors.Add(new ReturnBaseError
    //                {
    //                    ErrorCode = "400",
    //                    ErrorMessage = "Invalid email format"
    //                });
    //        }

    //        return errors;
    //    }
    //}


    public static class EmailValidator
    {
        private const int MaxLength = 200;
        private static readonly Regex EmailRegex =
            new(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.Compiled);

        public static void Validate(string email)
        {
            //if (string.IsNullOrWhiteSpace(email))
            //    throw new ValidationException("Email is required");

            if (email.Length > MaxLength)
                throw new ValidationException($"Email max length is {MaxLength}");

            if (!EmailRegex.IsMatch(email))
                throw new ValidationException("Invalid email format");
        }
    }


}
