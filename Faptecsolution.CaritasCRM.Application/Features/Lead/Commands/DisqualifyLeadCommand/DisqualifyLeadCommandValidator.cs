using FluentValidation;

namespace Faptecsolution.CaritasCRM.Application.Features.Lead.Commands.DisqualifyLeadCommand
{
    public class DisqualifyLeadCommandValidator : AbstractValidator<DisqualifyLeadCommand>
    {
        public DisqualifyLeadCommandValidator()
        {
            RuleFor(x => x.LeadId)
                .NotEmpty().WithMessage("{PropertyName} is required.");

            RuleFor(x => x.Reason)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .MaximumLength(250).WithMessage("{PropertyName} cannot exceed 250 characters.");
        }
    }
}
