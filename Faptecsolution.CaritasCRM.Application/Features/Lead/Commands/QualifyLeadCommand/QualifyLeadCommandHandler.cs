using Faptecsolution.CaritasCRM.Application.Contracts.Services;
using MediatR;

namespace Faptecsolution.CaritasCRM.Application.Features.Lead.Commands.QualifyLeadCommand
{
    public class QualifyLeadCommandHandler : IRequestHandler<QualifyLeadCommand, Guid>
    {
        private readonly ILeadQualificationService _leadQualificationService;

        public QualifyLeadCommandHandler(ILeadQualificationService leadQualificationService)
        {
            _leadQualificationService = leadQualificationService;
        }

        public async Task<Guid> Handle(QualifyLeadCommand request, CancellationToken cancellationToken)
        {
            return await _leadQualificationService.QualifyLeadAsync(
                request.LeadId,
                request.AccountId,
                request.ContactId,
                request.CreateAccount,
                request.CreateContact,
                request.CreateOpportunity,
                request.AccountName,
                request.AccountEmail,
                request.AccountPhone,
                request.AccountWebsite,
                request.AccountIndustry,
                request.AccountBusinessType,
                request.ContactFirstName,
                request.ContactLastName,
                request.ContactEmail,
                request.ContactPhone,
                request.ContactJobTitle,
                request.ContactDepartment,
                request.OpportunityName,
                cancellationToken);
        }
    }
}
