using Domain;
using FluentValidation;

namespace API_Releases.Validators
{
    public class ReleaseValidator : AbstractValidator<Release>
    {
        public ReleaseValidator()
        {
            RuleFor(release => release.Description)
               .NotNull()
               .NotEmpty();

            RuleFor(release => release.Amount)
                .NotNull()
                .GreaterThan(decimal.Zero);

            RuleFor(release => release.TransactionType)
               .NotNull()
                .Must(p => p.GetType().IsEnum);
        }
    }
}
