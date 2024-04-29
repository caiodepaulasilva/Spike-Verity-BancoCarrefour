using Domain;
using FluentValidation;

namespace API_Report.Validators
{
    public class QueryValidator : AbstractValidator<Query>
    {
        public QueryValidator()
        {
            RuleFor(release => release.Date)
               .NotNull()
               .NotEmpty();
        }
    }
}
