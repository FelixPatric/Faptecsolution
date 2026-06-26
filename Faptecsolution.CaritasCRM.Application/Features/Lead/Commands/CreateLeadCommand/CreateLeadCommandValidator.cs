using Faptecsolution.CaritasCRM.Application.Contracts.Persistence;
using FluentValidation;

namespace Faptecsolution.CaritasCRM.Application.Features.Lead.Commands.CreateLeadCommand
{
    public class CreateLeadCommandValidator : AbstractValidator<CreateLeadCommand>
    {
        private readonly ILeadRepository _leadRepository;

        public CreateLeadCommandValidator(ILeadRepository leadRepository)
        {
            _leadRepository = leadRepository;

            RuleFor(l => l.Topic)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .MaximumLength(100).WithMessage("{PropertyName} cannot exceed 100 characters.");

            RuleFor(l => l.FirstName)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .MaximumLength(50).WithMessage("{PropertyName} cannot exceed 50 characters.");

            RuleFor(l => l.LastName)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .MaximumLength(50).WithMessage("{PropertyName} cannot exceed 50 characters.");

            RuleFor(l => l.Email)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .EmailAddress().WithMessage("{PropertyName} is not a valid email address.")
                .MaximumLength(100).WithMessage("{PropertyName} cannot exceed 100 characters.")
                .MustAsync(IsEmailUniqueAsync).WithMessage("{PropertyName} already exists.");

            RuleFor(l => l.Phone)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .Matches(@"^\+?[0-9\s\-\(\)]{7,20}$").WithMessage("{PropertyName} is not valid.")
                .MaximumLength(20).WithMessage("{PropertyName} cannot exceed 20 characters.");

            RuleFor(l => l.JobTitle)
                .MaximumLength(50).WithMessage("{PropertyName} cannot exceed 50 characters.");

            RuleFor(l => l.Department)
                .MaximumLength(50).WithMessage("{PropertyName} cannot exceed 50 characters.");

            RuleFor(l => l.Company)
                .MaximumLength(100).WithMessage("{PropertyName} cannot exceed 100 characters.");
        }

        private async Task<bool> IsEmailUniqueAsync(CreateLeadCommand command, string email, CancellationToken token)
        {
            var isUnique = await _leadRepository.IsEmailUniqueAsync(email);
            return isUnique;
        }
    }
}
