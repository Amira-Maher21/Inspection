using FluentValidation;
using Inspection.Application.Contracts.Dto.SampleDTOs.CurrencyExchangeRateDTOs;

namespace Inspection.API.Controllers.Validations.Sample
{
    public class SCurrencyExchangeRateCreateValidator
      : AbstractValidator<SCurrencyExchangeRateCreateDto>
    {
        public SCurrencyExchangeRateCreateValidator()
        {
            RuleFor(x => x.BaseCurrencyId)
              .NotEmpty()
              .WithMessage("Property [BaseCurrencyId] is required.");


            RuleFor(x => x.Lines)
                .NotEmpty()
                .WithMessage("Currency exchange rate must have at least one target currency.");


            RuleForEach(x => x.Lines)
                .SetValidator(new CurrencyExchangeRateCreateLineValidator());
        }
    }

    public class CurrencyExchangeRateCreateLineValidator
        : AbstractValidator<SCurrencyExchangeRateCreateDto.SCurrencyExchangeRateCreateLine>
    {
        public CurrencyExchangeRateCreateLineValidator()
        {

            RuleFor(x => x.TargetCurrencyId)
                .NotEmpty().WithMessage("Property [TargetCurrencyId] is required.");

            RuleFor(x => x.Rate)
                .GreaterThan(0).WithMessage("Rate must be greater than zero.");
        }
    }
}