using FluentValidation;
using Inspection.Application.Contracts.Dto.SampleDTOs.CurrencyExchangeRateDTOs;

namespace Inspection.API.Controllers.Validations.Sample
{
    public class SCurrencyExchangeRateUpdateValidator
      : AbstractValidator<SCurrencyExchangeRateUpdateDto>
    {
        public SCurrencyExchangeRateUpdateValidator()
        {
            RuleFor(x => x.BaseCurrencyId)
                .NotEmpty()
                .WithMessage("Property [BaseCurrencyId] is required.");

            RuleFor(x => x.Lines)
                .NotEmpty()
                .WithMessage("Currency exchange rate must have at least one target currency.");

            RuleForEach(x => x.Lines)
                .SetValidator(new CurrencyExchangeRateUpdateLineValidator());
        }

    }

    public class CurrencyExchangeRateUpdateLineValidator
        : AbstractValidator<SCurrencyExchangeRateUpdateDto.SCurrencyExchangeRateUpdateLine>
    {
        public CurrencyExchangeRateUpdateLineValidator()
        {

            RuleFor(x => x.TargetCurrencyId)
                .NotEmpty().WithMessage("Property [TargetCurrencyId] is required.");

            RuleFor(x => x.Rate)
                .GreaterThan(0).WithMessage("Rate must be greater than zero.");
        }
    }
}