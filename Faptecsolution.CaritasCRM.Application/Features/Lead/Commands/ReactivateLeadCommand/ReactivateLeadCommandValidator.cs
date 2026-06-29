using FluentValidation;

namespace Faptecsolution.CaritasCRM.Application.Features.Lead.Commands.ReactivateLeadCommand
{
    public class ReactivateLeadCommandValidator : AbstractValidator<ReactivateLeadCommand>
    {
        public ReactivateLeadCommandValidator()
        {
            RuleFor(x => x.LeadId)
                .NotEmpty().WithMessage("{PropertyName} is required.");

            RuleFor(x => x.ReactivationNote)
                .MaximumLength(250).WithMessage("{PropertyName} cannot exceed 250 characters.")
                .When(x => !string.IsNullOrEmpty(x.ReactivationNote));
        }
    }
}
