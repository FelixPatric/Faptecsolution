using FluentValidation;

namespace Faptecsolution.CaritasCRM.Application.Features.Lead.Queries.SearchLeads
{
    public class SearchLeadsQueryValidator : AbstractValidator<SearchLeadsQuery>
    {
        public SearchLeadsQueryValidator()
        {
            RuleFor(x => x.SearchTerm)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .MinimumLength(2).WithMessage("{PropertyName} must be at least 2 characters.")
                .MaximumLength(100).WithMessage("{PropertyName} cannot exceed 100 characters.");
        }
    }
}
