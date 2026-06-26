using FluentValidation;

namespace Faptecsolution.CaritasCRM.Application.Features.Notes.Commands.AddNoteCommand
{
    public class AddNoteCommandValidator : AbstractValidator<AddNoteCommand>
    {
        public AddNoteCommandValidator()
        {
            RuleFor(x => x.Subject)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .MaximumLength(200).WithMessage("{PropertyName} cannot exceed 200 characters.");

            RuleFor(x => x.Text)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .MaximumLength(4000).WithMessage("{PropertyName} cannot exceed 4000 characters.");

            RuleFor(x => x.RegardingObjectId)
                .NotNull().WithMessage("{PropertyName} is required.");

            RuleFor(x => x.RegardingObjectType)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .MaximumLength(100).WithMessage("{PropertyName} cannot exceed 100 characters.");

            RuleFor(x => x.FileName)
                .MaximumLength(255).WithMessage("{PropertyName} cannot exceed 255 characters.")
                .When(x => !string.IsNullOrWhiteSpace(x.FileName));

            RuleFor(x => x.FilePath)
                .MaximumLength(500).WithMessage("{PropertyName} cannot exceed 500 characters.")
                .When(x => !string.IsNullOrWhiteSpace(x.FilePath));

            RuleFor(x => x.ContentType)
                .MaximumLength(100).WithMessage("{PropertyName} cannot exceed 100 characters.")
                .When(x => !string.IsNullOrWhiteSpace(x.ContentType));

            RuleFor(x => x.FileSizeBytes)
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than zero.")
                .When(x => x.FileSizeBytes.HasValue);
        }
    }
}
